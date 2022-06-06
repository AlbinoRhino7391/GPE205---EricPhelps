using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode rotateClockwise;
    public KeyCode rotateCounterClockwise;
    public KeyCode shoot;


    // Start is called before the first frame update
    public override void Start()
    {
        //runs the start function from the parent class.
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Processes our make decisions function.
        MakeDecisions();
    }

    //describes the function.
    public override void MakeDecisions()
    {
        if (Input.GetKey(moveForward))
        {
            pawn.MoveForward();   
        }
        if (Input.GetKey(moveBackward))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(rotateClockwise))
        {
            pawn.RotateClockwise();
        }
        if (Input.GetKey(rotateCounterClockwise))
        {
            pawn.RotateCounterClockwise();
        }
        if (Input.GetKey(shoot))
        {
            pawn.Shoot();
        }
    }
}
