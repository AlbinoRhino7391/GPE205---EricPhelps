using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates { Idle, Chase, Attack, Flee, ChooseTarget,Patrol }
    public AIStates currentState;
    public float timeEnteredCurrentState;
    public GameObject AITarget;
    public List<Transform> waypoints;
    public int currentWaypoint;
    public int distanceToPoint;

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
            //turn towards a target
            pawn.TurnTowards(chaseTarget.transform.position);
            //Move forwards
            pawn.MoveForward();
        }
        else
        {
            Debug.Log("Chase was passed a null target.");
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

    public virtual void DoPatrolState()
    {
        //Move to current waypoint
        Chase(waypoints[currentWaypoint]);
        //if close enought, then increment cur rwaypoint.
        if(Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) <=  distanceToPoint)
        {
            currentWaypoint++;
        }
        //if we get to the last waypoint
        if(currentWaypoint >= waypoints.Count)
        {
            //go back to the first waitpoint.
            currentWaypoint = 0;
        }
    }

    public virtual bool IsCanHear(GameObject target)
    {
        //Get the noisemaker component
        //if it does not exist
        //then we are not making sound- return false
        return false;
        //else
        // check if the distance is the less than the sum of the two radii.
        //if it less than the sum, we can hear them - return true
        //else
        //we cant hear them - return false.
    }
}
