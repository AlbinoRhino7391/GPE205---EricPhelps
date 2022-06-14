using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //what are we shooting, how fast are we shooting it, and how much damage does the projectile do.
    public void Shoot(GameObject shellPrefab, float shootForce, float damageDone, Pawn shooter, Vector3 shootOffset)
    {
        
        //create the bullet
        GameObject theShell = Instantiate(shellPrefab, transform.position + shootOffset, transform.rotation);

        //give it the data.
        Projectile projectile = theShell.GetComponent<Projectile>();
        
        if (projectile != null)
        {
            projectile.damageDone = damageDone;
            projectile.owner = shooter;
        }

        //push the bullet
        Rigidbody shellRb = theShell.GetComponent<Rigidbody>();
        if (shellRb != null)
        {
            shellRb.AddForce(transform.forward * shootForce);
        }
    }
}
