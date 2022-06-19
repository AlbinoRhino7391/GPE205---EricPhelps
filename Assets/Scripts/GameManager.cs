using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //I am making an arrow that points to this singleton.
    public static GameManager instance;
    public List<KeyboardController> players;

    public GameObject pawnPrefab;


    //what does this object do before the first frame is called
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //what am I supposed to be doing every frame.
    void Update()
    {
        //for testing purposes only
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPlayer(0);
        }

    }

    public void SpawnPlayer(int playerNumber)
    {
        GameObject newPawn = Instantiate(pawnPrefab, Vector3.zero, Quaternion.identity);
        pawnPrefab newPawnScript = newPawn.GetComponent<Pawn>();
        if (newPawnScript != null)
        {
            if (players.Count > playerNumber)
            {
                players[0].pawn = newPawnScript;
            }
        }
    }
}
