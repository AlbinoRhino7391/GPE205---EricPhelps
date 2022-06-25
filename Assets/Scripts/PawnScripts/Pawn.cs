using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the parent class for all future pawns
//abstract means that this will always be overridden by the child.
// We will never have a Pawn class created, only the children will ever be created.(example Pawn vs TankPawn)
//REMEMBER EVERYTHING EDITABLE IS STORED IN THE PAWN.

public abstract class Pawn : MonoBehaviour
{
    // Start is called before the first frame update
    // First and foremost we will need variables for move and turn speed that will need to be public to make them changable by the design team.

    //public variables for mover
    public float moveSpeed; 
    public float turnSpeed;
    public Mover mover;

    // public vars for shooter
    public Shooter shooter;
    public GameObject shellPrefab;
    public float fireForce;
    public float damageDone;
    public float shellLifespan;


    // Start and Updates, MIGHT be overridden, so we use the keyword Vritual
    public virtual void Start()
    {
        //on start we need to get our mover component to "hook it up".
        mover = GetComponent<Mover>();
        //get and hook up the component.
        shooter = GetComponent<Shooter>();
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
    public abstract void Shoot();
}
