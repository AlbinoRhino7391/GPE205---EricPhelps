using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates { Idle, Chase, Attack, Flee, ChooseTarget, Patrol, NearestTarget, ReturnToPost }
    public AIStates currentState;
    public float timeEnteredCurrentState;
    public GameObject AITarget;
    public List<Transform> waypoints;
    public int currentWaypoint;
    public int distanceToPoint;
    public int minFleeDistance;
    public int maxFleeDistance;

    //data for senses
    public float hearingRadius;
    public float fieldOfView;
    public float viewDistance;
    

    public override void Start()
    {
        //left blank intentionally
    }
    public override void Update()
    {
        //left blank intentionally
    }

    public abstract void MakeDecisions();
    public virtual void ChangeState(AIStates newState)
    {
        //remember the time we changed states.
        timeEnteredCurrentState = Time.time;
        //change our state.
        currentState = newState;

        //Debug.Log("Changed State to "+newState.ToString() );

    }
    public virtual void DoIdleState()
    {
        //Do nothing, this is so other programmer know it was left blank intentionally.
        //Debug.Log("I am Idling!");
    }

    public virtual void DoPatrolState()
    {
        //create a temp target location.
        Vector3 tempTargetlocation = waypoints[currentWaypoint].position;
        //adjust this temp location, so that the y is the same as the y as my pawn.
        tempTargetlocation = new Vector3(tempTargetlocation.x, pawn.transform.position.y, tempTargetlocation.z);

        //Move to current waypoint
        Chase(tempTargetlocation);
        //if close enough, then increment 0ur rwaypoint.
        if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) <= distanceToPoint)
        {
            currentWaypoint++;
        }
        //if we get to the last waypoint
        if (currentWaypoint >= waypoints.Count)
        {
            //go back to the first waitpoint.
            currentWaypoint = 0;
        }
    }

    public virtual void DoReturnToPostState()
    {
        //this will be the same as the patrol state but with only 1 waypoint.

        //create a temp target location.
        Vector3 tempTargetlocation = waypoints[currentWaypoint].position;
        //adjust this temp location, so that the y is the same as the y as my pawn.
        tempTargetlocation = new Vector3(tempTargetlocation.x, pawn.transform.position.y, tempTargetlocation.z);

        Chase(tempTargetlocation);

        if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) <= distanceToPoint)
        {
            DoIdleState(); ;
        }
    }

    public virtual void DoFleeState()
    {
        //TODO: set speed to max
        //do the flee action!
        Flee(AITarget);
        //Debug.Log("Flee")
    }


    public virtual void DoChaseState()
    {
        //TODO: set speed to max speed for AI

        //DO the chase action!
        Chase(AITarget);

       //Debug.Log("Chase");
    }

    public virtual void DoChooseTargetState()
    {
        AITarget = GameManager.instance.players[0].pawn.gameObject;
        //instance of the game manager,player one from the seriealized list, then get that players pawn not the controller, and target the gameobject of that pawn.
        //Debug.Log("Choosing Target");
    }

    public virtual void DoAttackState()
    {
        //Chase the player
        //Shoot action!
    }

    public virtual void DoTargetNearestPlayerState()
    {
        AITarget = GetNearestPlayer();
    }

    public virtual GameObject GetNearestPlayer()
    {
        //this function assumes player 0 is the closest.
        GameObject nearestPlayer = GameManager.instance.players[0].pawn.gameObject;
        float nearestPlayerDistance = Vector3.Distance(pawn.transform.position, GameManager.instance.players[0].pawn.transform.position);

        //check the rest of the players to see if any of them is closer.
        for(int index = 1; index < GameManager.instance.players.Count; index++)
        {
            float tempDistance = Vector3.Distance(pawn.transform.position, GameManager.instance.players[index].pawn.transform.position);

            if(tempDistance < nearestPlayerDistance)
            {
                nearestPlayer = GameManager.instance.players[index].pawn.gameObject;
                nearestPlayerDistance = tempDistance;
            }
        }
        return nearestPlayer;
    }

    public virtual void Chase(Vector3 chaseTarget)
    {
        //turn towards a target
        pawn.TurnTowards(chaseTarget);
        //Move forwards
        pawn.MoveForward();
    }

    public virtual void Chase(Controller chaseTarget)
    {
        Chase(chaseTarget.pawn.gameObject);
    }

    public virtual void Chase(Transform chaseTarget)
    {
        Chase(chaseTarget.gameObject);
    }

    public virtual void Chase(GameObject chaseTarget)
    {
        if (chaseTarget != null)
        {
            Chase(chaseTarget.transform.position);
        }
        else
        {
            Debug.Log("Chase was passed a null target.");
        }

    }

    public virtual void Flee(Vector3 fleeTarget)
    {
        //turn towards
        pawn.TurnTowards(fleeTarget);
        //run away
        pawn.MoveBackward();

    }
    public virtual void Flee(GameObject fleeTarget)
    {
        if (fleeTarget != null)
        {
            Flee(fleeTarget.transform.position);
        }
        else
        {
            Debug.Log("Flee was passed a null target.");
        }

    }


    public virtual bool IsTimePassed(float amountOfTime)
    {
        if(Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }

    

    public virtual bool IsCanSee (GameObject target)
    {
        //check if in FoV
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        float angleToTarget = Vector3.Angle(pawn.transform.forward, vectorToTarget);
        if (angleToTarget > fieldOfView)
        {
            return false;
        }
        //check if in LoS
        Ray tempRay = new Ray(pawn.transform.position, vectorToTarget);
        RaycastHit hitInfo;
        if(Physics.Raycast(tempRay, out hitInfo,viewDistance))
        {
            //check if hit item is the target
            if(hitInfo.collider.gameObject == target)
            {
                return true; // we can see our target
            }
        }
        // if we made it this far, something is in the way.
        return false; // we cant see shit.
    }
    public virtual bool IsCanHear(GameObject target)
    {
        //Get the noisemaker component
        NoiseMaker targetNoiseMaker = target.GetComponent<NoiseMaker>();
        //if it does not exist
        if (targetNoiseMaker == null)
        {
            //then we are not making sound- return false
            return false;
        }
        else
        {
            float sumOfRadii = targetNoiseMaker.noiseDistance + hearingRadius;
            // check if the distance is the less than the sum of the two radii.
            //if it less than the sum, we can hear them - return true
            if(Vector3.Distance(target.transform.position, pawn.transform.position) <= sumOfRadii)
            {
                return true;
            }
            //else
            //we cant hear them - return false.
            else
            {
                return false;
            }
        }


    }
}
