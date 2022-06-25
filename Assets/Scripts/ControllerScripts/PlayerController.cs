using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For learning focus on the AGile process, make one feature at a time. For right now focus on the Player controller.
/*what do we need
 * inherit from the Controller
 * store variables for our input "KeyCodes"
 * nothing will change for the start or inputs
 */
//THis script will be our first instance of branching utilizing if/else statements.

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;

    // Start is called before the first frame update
    public override void Start()
    {
        // Run the Start() function from the parent (base) class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Process our Keyboard Inputs
        ProcessInputs();

        // Run the Update() function from the parent (base) class
        base.Update();
    }

    public void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }
}
