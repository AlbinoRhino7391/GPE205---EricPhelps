using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//we need to inherit from mover
public class TankMover : Mover
{
    //we need a variable to store rigidbody only for this object
    private Rigidbody rigidbodyComponent;

    //public variable for the rotation of the tank.

    // Start is called before the first frame update
    public override void Start()
    {
        //now to get the rb component, this is loading the components into the variable,
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    //How will we move/Rotate the object?
    public override void MoveForward(float moveSpeed)
    {
        rigidbodyComponent.MovePosition(transform.position + (transform.forward * (moveSpeed * Time.deltaTime)));
    }
    public override void Rotate(float rotationSpeed)
    {
        transform.Rotate(0, (rotationSpeed * Time.deltaTime), 0);
    }


    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
