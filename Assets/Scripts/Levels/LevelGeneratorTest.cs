using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelGenerator levelGen = GetComponent<LevelGenerator>();
        levelGen.GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
