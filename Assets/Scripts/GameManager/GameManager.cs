using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //create a designated space to store your prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnTransform;

    //public variables...the lists batman.
    public List<PlayerController> players;

    //utilize the keyword static to make it global and accessible form anywhere.
    public static GameManager instance;

    private void Start()
    {
        // for testing purposes we will have the spawn happen as soon as the game starts
        SpawnPlayer();
    }

    //the keyword awake is called when the object is first created.
    private void Awake()
    {
        if (instance == null)
        {
            //It is called a singleton because there can only be one...
            instance = this;
            //Don't destroy it if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Otherwise, there is already an instance, so destroy this gameObject
            Destroy(gameObject);
        }
    }

    //One thing the game manager will control is where the player starts in the game.
    public void SpawnPlayer()
    {
        //break it down into steps barney.
        //1. Spawn the controller, this is how we control
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        //2. spawn the pawn, this is what we control.
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
        //3. get your components of the what and how.
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //4. link them together for the pawn-controller methodology discussed in class.
        newController.pawn = newPawn;

    }
}
