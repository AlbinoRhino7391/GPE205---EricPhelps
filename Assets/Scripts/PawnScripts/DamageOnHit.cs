using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This component will make it so any object that this component is on will damage anything it runs in to that has a Health component.

public class DamageOnHit : MonoBehaviour
{
    //what data do we need to make this work?
    public float damageDone;
    public Pawn owner;

    //we do not need a start or update, our projectile will not exist in the game until fired.
    //but we do need an overlap trigger.
    public void OnTriggerEnter(Collider other)
    {
        // Get the Health component from the Game Object that has the Collider that we are overlapping
        Health otherHealth = other.gameObject.GetComponent<Health>();
        // Only damage if it has a Health component
        if (otherHealth != null)
        {
            // Do damage
            otherHealth.TakeDamage(damageDone, owner);
        }

        // Destroy the bullet, whether we did damage or not
        Destroy(gameObject);
    }
}
