using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : MonoBehaviour
{
    //leave monobehavior because this is a component.
    public PowerupSpeed powerup;

    public void OnTriggerEnter(Collider other)
    {
        PowerupManager otherPowerupManager = other.GetComponent<PowerupManager>();

        if (otherPowerupManager != null)
        {
            otherPowerupManager.Apply(powerup);
            Destroy(gameObject);
        }
    }
}
