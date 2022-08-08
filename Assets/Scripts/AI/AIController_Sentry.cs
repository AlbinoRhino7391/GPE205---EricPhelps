using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Sentry : AIController
{
    // From the start of the game, start in the Idle class.
    public override void Start()
    {
        ChangeState(AIStates.Idle);
    }

    //run the make descisions function every frame.
    public override void Update()
    {
        MakeDecisions();
    }

    public override void MakeDecisions()
    {
        //FSM
        //Based on our current state
        //a switch statement is similar to doing a long list of if else statements but runs faster.
        switch (currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if (IsTimePassed(5))
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
            case AIStates.Patrol:
                DoPatrolState();
              
                //check conditions.
                break;
        }
    }
}
