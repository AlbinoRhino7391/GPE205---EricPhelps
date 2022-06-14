using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
   

    // Start is called before the first frame update
    public override void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }

    public override void MoveForward()
    {
        mover.MoveForward(moveSpeed);
        base.MoveForward();
        Debug.Log("Forward!");
    }

    public override void MoveBackward()
    {
        mover.MoveForward(-moveSpeed);
        base.MoveBackward();
        Debug.Log("Reverse!");
    }

    public override void RotateClockwise()
    {
        mover.Rotate(-rotationSpeed);
        base.RotateClockwise();
        Debug.Log("Starboard!");
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(rotationSpeed);
        base.RotateCounterClockwise();
        Debug.Log("Port!");
    }

    public override void Shoot()
    {
        shooter.Shoot(shellPrefab, shootForce, damageDone, this, shootOffset);
        base.Shoot();
        Debug.Log("Fire!");
    }

}
