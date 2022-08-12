using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //let designers be able to change the type of maps.
    public enum MapType { Random, MapOfTheDay, Seed };
    public MapType type;

    //where are we going to store after creation.
    public Room[,] grid;

    //we need a list of all rooms to choose from.
    public List<Room> possibleRooms;

    //data about the map
    private float roomWidth = 50.0f;
    private float roomHeight = 50.0f;

    public int numberOfRows;
    public int numberOfCols;

    public int randomSeed;


    // Start is called before the first frame update
    void Start()
    {
        //setup the grid 2D array
        grid = new Room[numberOfCols, numberOfRows];
    }

    public void GenerateLevel()
    {
        //seed the RNG based on the esigner choice.
        if(type == MapType.Random)
        {
            //seed the RNG with a random number!
            System.DateTime time;
            time = System.DateTime.Now;
            Random.InitState((int)time.Ticks);
        }
        else if(type == MapType.Seed)
        {
            Random.InitState(randomSeed);
        }
        else
        {
            // seed the RNG for map of the day.
            Random.InitState((int)System.DateTime.Today.Ticks);

        }

        //clear our grid array
        grid = new Room[numberOfCols, numberOfRows];
        //one row at a time
        for(int currentRow = 0; currentRow < numberOfRows; currentRow++)
        {
            //for each row go through one col at a time.
            for(int currentCol = 0; currentCol < numberOfCols; currentCol++)
            {
                // instantiate a random room
                Room newRoom = Instantiate(GetNextRoom()) as Room;
                //move it to the correct position.
                Vector3 newPosition = new Vector3(currentCol * roomWidth, 0.0f, currentRow * roomHeight);
                newRoom.transform.position = newPosition;
                //give it a meaningful name.
                newRoom.gameObject.name = "Room(" + currentCol + "," + currentRow + ")";
                //TODO:Organize our heirarchy
                newRoom.gameObject.transform.parent = this.transform;

                //save it to the grid.
                grid[currentCol, currentRow] = newRoom;
                //TODO: open the correct door.
                if(currentRow != 0)
                {
                    newRoom.doorSouth.SetActive(false);
                }
                if(currentRow != numberOfRows - 1)
                {
                    newRoom.doorNorth.SetActive(false);
                }
                if(currentCol != numberOfCols - 1)
                {
                    newRoom.doorEast.SetActive(false);
                }
                if(currentCol != 0)
                {
                    newRoom.doorWest.SetActive(false);
                }

            }
        }




    }

    public Room GetNextRoom()
    {
        //for now just a stub
        return possibleRooms[Random.Range(0, possibleRooms.Count)];
    }
}
