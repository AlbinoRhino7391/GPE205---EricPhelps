using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //variable to hold our pawn and to be passed down to the children.
    public Pawn pawn;

    // Start is called before the first frame update
    // these parameters shoudl always be private unless they cant be.
    // if they cant be private make them protected.
    //virtual means that it can be overwritten by the child class.
    public virtual void Start()
    {
    }
    // Update is called once per frame
    public virtual void Update()
    {   
    }

    public virtual void MakeDecisions()
    {
    }

}
