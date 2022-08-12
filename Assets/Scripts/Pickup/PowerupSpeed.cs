using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PowerupSpeed : Powerup
{
    public float speedToApply;

    public override void Apply(PowerupManager target)
    {
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.moveSpeed += speedToApply;
        }
    }
    public override void Remove(PowerupManager target)
    {
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();
        if(targetPawn != null)
        {
            targetPawn.moveSpeed -= speedToApply;
        }
    }
}
