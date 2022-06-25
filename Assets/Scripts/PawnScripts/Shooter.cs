using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is an abstract parent for any component that can shoot.

public abstract class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
    }
    // Update is called once per frame
    public virtual void Update()
    {
    }

    //we nee a command that will be in charge of allowing our pawns to be able to shoot.
    public virtual void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        // what do we need to make this happen.
        // shell prefab, what are we "shooting"
        // how fast are wew moving it?
        // how hard will it hit?
        // how long will it exist in the world?
    }
}
