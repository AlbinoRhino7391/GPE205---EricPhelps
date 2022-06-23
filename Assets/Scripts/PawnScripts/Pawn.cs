using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the parent class for all future pawns
//abstract means that this will always be overridden by the child.
// We will never have a Pawn class created, only the children will ever be created.(example Pawn vs TankPawn)
public abstract class Pawn : MonoBehaviour
{
    // Start is called before the first frame update
    // First and foremost we will need variables for move and turn speed that will need to be public to make them changable by the design team.

    //public variables
    public float moveSpeed;
    public float turnSpeed;

    // Start and Updates, MIGHT be overridden, so we use the keyword Vritual
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    //remember abstract will always be overridden by the child.
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}
