using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this child class shoots the way our tanks shoot (instantiate a shell at a a fire point, push forward with physics)
//this is a child class that inherits from "Shooter"
public class TankShooter : Shooter
{
    //we need a variable to store where we will be shooting from, so its not just appearing in the middle of our tank.
    public Transform firepointTransform;
    // Start is called before the first frame update
    public override void Start()
    {
        //no data needed before the game starts.
    }

    // Update is called once per frame
    public override void Update()
    {
        // nodata will be needed every frame check.
    }
    //when overrideing, or utilizing inheritence, make sure the arguments are the same.
    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        //we need to spawn our projectile through instantiate.
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        //now we need to get our DamageOnHit component, rememeber this is where we stored the public var for damageDone. This step is where we start to link things together for dealing damage.
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();
        //dont forget to error-proof
        if (doh != null)
        {
            //set the value to be passed in
            doh.damageDone = damageDone;
            //set the owner as the pawn that fired the shell.
            doh.owner = GetComponent<Pawn>();
        }
        //more get components to link everything together....C# is confusing, i prefer unreal and C++...
        //get the rigid body of the shell.
        Rigidbody rb = newShell.GetComponent<Rigidbody>();
        //error proof the get
        if (rb != null)
        {
            // use the force luke, this is how we make the object move.
            rb.AddForce(firepointTransform.forward * fireForce);
        }
        //destroy the projectile after a set time, we dont want the object floating around forever.
        Destroy(newShell, lifespan);
    }
}
