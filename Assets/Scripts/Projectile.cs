using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public variables--what will the bullet affect.
    public float damageDone;
    public Pawn owner;

    public void OnTriggerEnter(Collider other)
    {
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone, owner);
        }
        //this function is to destroy itself
        Destroy(gameObject);
    }
}
   
