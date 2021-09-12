using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms; 
    public float waitTime;
    public bool spawnedAntenna;
    public GameObject antenna;
    void Update(){
        if (waitTime <=0 && spawnedAntenna == false){
            for (int  i = 0; i<rooms.Count; i++){
                if (i==rooms.Count -1 ){
                    Instantiate(antenna, rooms[i].transform.position, Quaternion.identity);
                    spawnedAntenna = true;
                }
            }
            
        }else {
            waitTime -=Time.deltaTime;
        }
    }
}
