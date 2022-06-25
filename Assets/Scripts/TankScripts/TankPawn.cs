using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a child class so we need to declare what we are inheriting from.
public class TankPawn : Pawn
{
    //private var for timer
    private float nextTimeYouCanShoot;

    // For right Now nothing changes from the parent so use base. command.
    public override void Start()
    {
        nextTimeYouCanShoot = Time.time + fireRate;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Time.time >= nextTimeYouCanShoot) 
        {
            nextTimeYouCanShoot = Time.time + fireRate;
        }
        base.Start();
    }
    
    //now we can remove the debugs as we implement movement.
    public override void MoveForward()
    {
        //use a branch to Make Your Code Safe from Null Reference Exceptions
        if (mover != null)
        {
            mover.Move(transform.forward, moveSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveForward()!");
        }
    }

    public override void MoveBackward()
    {
        if (mover != null)
        {
            mover.Move(transform.forward, -moveSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveBackward()!");
        }
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
        //Debug.Log("Turn Right");
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
        //Debug.Log("Turn Left");
    }

    public override void Shoot()
    {
        if (shooter != null)
        {
            //always remember to error proof everything that you can...take the extra 2 minutes to do so, less you want to break the game and start from scratch...again.
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
        }
        else
        {
            Debug.LogWarning("WARNING: No Shooter in TankPawn.Shoot()!");
        }
    }
}

