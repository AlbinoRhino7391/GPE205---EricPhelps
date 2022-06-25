using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles health / death
//This will go on any object that has health and can be damaged. It doesn't matter if it is a tank.
//It will have a function to "TakeDamage()"
//It will have a function to "Die()" if it takes enough damage.

public class Health : MonoBehaviour
{
    //what variables will I control here?
    public float currentHealth;
    public float maxHealth;


    // Start is called before the first frame update
    public void Start()
    {
        //what do we want to do with our health before the game starts?
        //set current health to max health.
        currentHealth = maxHealth; 
        
    }

    public void Heal(float amount, Pawn source)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth = currentHealth + amount;
        //Debug.log(source.name + "healed for " + healAmount);
    }
    // we removed the update function
    public void TakeDamage(float damageDone, Pawn source)
    {
        //set the range for what the health can be.
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //this function does the math for us, subtracting the amount of damage from the current health of an object.
        // the debug is so we can see what is happening while the game runs.
        currentHealth = currentHealth - damageDone;
        //Debug.log(source.name + "did " + damageAmount + " damage to " + gameObject.name);

        if (currentHealth <= 0)
        {
            Die(source);
        }
    }

    //create the DIe function.
    public void Die(Pawn source)
    {
        Destroy(gameObject);
    }
}
