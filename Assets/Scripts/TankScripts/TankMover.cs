using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this child class moves things the way a tank moves (move forward and rotate).
/*It needs to inherit from Mover
 * We need to access the Rigidbody component, so we need a variable and get it on Start.
 * We need to normalize the direction and multiply by speed to move at the correct speed. 
 * We need to use Time.deltaTime to be framerate independent.
 * We need to add vectors to find the position to move to.
 */

public class TankMover : Mover //inherit from the mover parent class.
{
    //remember our public floats for move and turn speed are already created in the Pawn parent class.
    //first create a variable to hold the rigid body that was added to our tank pawn.
    private Rigidbody rb;

    // override from the parent.
    public override void Start()
    {
        //get the rb before the game starts.
        rb = GetComponent<Rigidbody>();        
    }
    //remove the update for now.
    //create the move function, and override form the parent class.
    public override void Move(Vector3 direction, float moveSpeed)
    {
        Vector3 moveVector = (direction.normalized * (moveSpeed * Time.deltaTime));
        rb.MovePosition(rb.position + moveVector);
    }
    //create the Rotate() function with only one float to measure the turn speed in degrees per second so do not forget to multiply by Time.deltaTime.
    public override void Rotate(float turnSpeed)
    {
        transform.Rotate(0, (turnSpeed * Time.deltaTime), 0);
    }
}
