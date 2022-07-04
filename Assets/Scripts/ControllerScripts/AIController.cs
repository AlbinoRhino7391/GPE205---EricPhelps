using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    //make a variable for our target.
    public GameObject target;
    // Start is called before the first frame update
    public override void Start()
    {
        //default to the parent.
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Make decisions
        MakeDecisions();
        // Run the parent (base) Update
        base.Update();
    }
    //define MakeDescisions.
    public void MakeDecisions()
    {
         // Seek our target
        Seek(target);
        //Debug.Log("Making Decisions");
    }
    //use your god abilities to overload and make multiple versions of seek, to take different types of parameters.
    public void Seek (GameObject target) //seek by target
    {
        // RotateTowards the Funciton
        pawn.RotateTowards(target.transform.position);
        // Move Forward
        pawn.MoveForward();
    }
    public void Seek(Vector3 targetPosition) // seek by position
    {
        // RotateTowards the Funciton
        pawn.RotateTowards(targetPosition);
        // Move Forward
        pawn.MoveForward();
    }
    public void Seek(Transform targetTransform)//seek by transform.
    {
        // Seek the position of our target Transform
        Seek(targetTransform.position);
    }
    public void Seek(Pawn targetPawn)//seek by pawn.
    {
        // Seek the pawn's transform!
        Seek(targetPawn.transform);
    }

}
