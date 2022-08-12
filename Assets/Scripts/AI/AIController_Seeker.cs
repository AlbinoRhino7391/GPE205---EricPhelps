using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Seeker : AIController
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

    public override void MakeDecisions()
    {
        //FSM
        //Based on our current state
        //a switch statement is similar to doing a long list of if else statements but runs faster.
        switch (currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                AITarget = GameManager.instance.players[0].pawn.gameObject;
                if (IsCanSee (AITarget))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
            case AIStates.Chase:
                DoChaseState();
                //check conditions.
                if (IsTimePassed(5))
                {
                    ChangeState(AIStates.ReturnToPost);
                }
                break;
            case AIStates.ReturnToPost:
                DoReturnToPostState();
                break;
        }
    }
}