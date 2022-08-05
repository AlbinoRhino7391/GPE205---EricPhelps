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

//we need to make things serialized if we want them to show up in the inspector.
[System.Serializable]
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
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // And it tracks the players
            if (GameManager.instance.players != null)
            {
                // add them to the list robin.
                GameManager.instance.players.Add(this);
            }
        }
        // Run the Start() function from the parent (base) class
        //base.Start();
    }

    //after we add the ability to add players to the list, now we need to be able to delete them from the lists...planning and organization is key.
    public void OnDestroy()
    {
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // And it tracks the player(s)
            if (GameManager.instance.players != null)
            {
                // Deregister with the GameManager
                GameManager.instance.players.Remove(this);
            }
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        // Process our Keyboard Inputs
        ProcessInputs();

        // Run the Update() function from the parent (base) class
        //base.Update();
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
