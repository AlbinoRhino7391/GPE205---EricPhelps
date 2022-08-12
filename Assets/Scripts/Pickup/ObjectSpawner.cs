using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float timeBetweenSpawns;
    public bool isSpawnedAtStart;
    private GameObject spawnedObject;
    private float spawnCountdown;


    // Start is called before the first frame update
    void Start()
    {
        if(isSpawnedAtStart)
        {
            spawnCountdown = 0;
        }
        else
        {
            spawnCountdown = timeBetweenSpawns;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnedObject != null)
        {
            //object exists do nothing.

        }
        else
        {
            //the object does not exist, set the time to run real time.
            spawnCountdown -= Time.deltaTime;
            //when the time reaches zero, spawn object.
            if(spawnCountdown <= 0)
            {
                spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
                spawnCountdown = timeBetweenSpawns;

            }
        }
    }
}
