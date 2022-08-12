using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PowerupHealth : Powerup
{
    public float healthToApply;

    public override void Apply(PowerupManager target)
    {
        GameObject targetObject = target.gameObject;
        Health targetHealth = targetObject.GetComponent<Health>();

        if(targetHealth != null)
        {
            targetHealth.Heal(healthToApply);
        }
    }
    public override void Remove(PowerupManager target)
    {
        //left blank intentionally.
    }
}
