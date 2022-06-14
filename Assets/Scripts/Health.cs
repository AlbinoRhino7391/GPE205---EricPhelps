using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currHealth;

    public void Start()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(float amount, Pawn owner)
    {
        currHealth = currHealth - amount;

        if (currHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
