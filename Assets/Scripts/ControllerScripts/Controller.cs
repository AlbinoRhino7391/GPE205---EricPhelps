using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the parent class for all future pawns
//abstract means that this will always be overridden by the child.
// We will never have a Pawn class created, only the children will ever be created.(example Controller vs PlayerController vs aiController)

[System.Serializable]
public class Controller : MonoBehaviour
{
    //what are we controlling with the controllers?
    //create a variable for what will be controlled.
    public Pawn pawn;

    // Start is called before the first frame update
    public virtual void Start()
    {   
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }
}
