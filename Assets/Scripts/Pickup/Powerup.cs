using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public abstract class Powerup
{
    public float lifespan;

    public abstract void Apply(PowerupManager target);
    public abstract void Remove(PowerupManager target);
}
