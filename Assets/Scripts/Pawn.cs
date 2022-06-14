using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract means that this class will always be overwritten, makes it easier to add extra classes later.
//virtual means it might be overwritten.
public class Pawn : MonoBehaviour
{
    protected Mover mover;
    protected Health health;
    protected Shooter shooter;

    //public variables
    public float moveSpeed;
    public float rotationSpeed;
    public GameObject shellPrefab;
    public float damageDone;
    public float shootForce;
    public Vector3 shootOffset;




    // Start is called before the first frame update
    public virtual void Start()
    {
        //load the mover in at start.
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();

    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    public virtual void MoveForward()
    {
    }

    public virtual void MoveBackward()
    {
    }

    public virtual void RotateClockwise()
    {
    }

    public virtual void RotateCounterClockwise()
    {
    }

    public virtual void Shoot()
    {
    }

}
