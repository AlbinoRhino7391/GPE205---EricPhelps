using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Simple : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        //start the game in idle state.
        ChangeState(AIStates.Idle);

        //TODO: this AI targets player 1
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }

    public override void ChangeState(AIStates newState)
    {
        base.ChangeState(newState);
        //I left the override in here becasue I might change it later for the final.
    }

    public override void MakeDecisions()
    {
        //FSM
        //Based on our current state
        //a switch statement is similar to doing a long list of if else statements but runs faster.
        switch(currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if(IsTimePassed(1))
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
            case AIStates.Patrol:
                DoPatrolState();
                //check conditions.
                break;
            case AIStates.Chase:
                DoChaseState();
                if(IsTimePassed(3))
                {
                    ChangeState(AIStates.Idle);
                }
                break;
            case AIStates.ChooseTarget:
                DoChooseTargetState();
                //No conditions
                ChangeState(AIStates.Chase);
                break;
            

        }
    }
    
    
    
}
