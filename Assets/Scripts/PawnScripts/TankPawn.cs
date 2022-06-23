using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a child class so we need to declare what we are inheriting from.
public class TankPawn : Pawn
{
    // For right Now nothing changes from the parent so use base. command.
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }

    public override void MoveForward()
    {
        Debug.Log("Move Forward");
    }

    public override void MoveBackward()
    {
        Debug.Log("Move Backward");
    }

    public override void RotateClockwise()
    {
        Debug.Log("Turn Right");
    }

    public override void RotateCounterClockwise()
    {
        Debug.Log("Turn Left");
    }

}

