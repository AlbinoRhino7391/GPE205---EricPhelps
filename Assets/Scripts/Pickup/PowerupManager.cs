using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    public List<Powerup> powerups;


    // Start is called before the first frame update
    void Start()
    {
        //create the list of powerups
        powerups = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        CountdownPowerups();
    }

    private void CountdownPowerups()
    {
        List<Powerup> removalQueue = new List<Powerup>();

        foreach (Powerup powerup in powerups)
        {
            powerup.lifespan -= Time.deltaTime;

            if(powerup.lifespan <= 0)
            {
                //queue for removal
                removalQueue.Add(powerup);
            }
        }

        //Now that we are done iterating for the queue, remove everythihng.
        foreach(Powerup powerupToRemove in removalQueue)
        {
            //remove them one at a time.
            Remove(powerupToRemove);
        }
    }

    public void Apply(Powerup powerupToApply)
    {
        //TODO: apply the powerup.
        powerupToApply.Apply(this);

        if(powerupToApply.lifespan < 0)
        {
            // Do nothing
        }
        else
        {
            //add to list
            powerups.Add(powerupToApply);
        }
        

    }

    public void Remove(Powerup powerupToRemove)
    {
        //un apply the powerup
        powerupToRemove.Remove(this);

        //remove from the list
        powerups.Remove(powerupToRemove);
    }
}
