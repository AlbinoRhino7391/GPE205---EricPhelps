using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is an abstract parent for any component that moves objects in the world
/*what do we need
 * make it abstract, only the child will have an instance in the game.
 * contain a function to move and to rotate..
 * make it loosely coupled, it shouldnt require other components to work. 
 * we need to know the direction and the speed.
 */

public abstract class Mover : MonoBehaviour
{
    public abstract void Start(); // abstract because it will always be changed by the child.
    public abstract void Move(Vector3 direction, float moveSpeed);
    public abstract void Rotate(float turnSpeed);
}
