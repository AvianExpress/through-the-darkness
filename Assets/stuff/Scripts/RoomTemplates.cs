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
    public GameObject enemy;
    public GameObject Item;
    public float difficulty = 50f;  
    public float randomOnItems= 50f;

    void Awake(){

    }
    void Update(){
        if (waitTime <=0 && spawnedAntenna == false){
            for (int  i = 0; i<rooms.Count; i++){
                if (i==rooms.Count -1 ){
                    Instantiate(antenna, rooms[i].transform.position, Quaternion.identity);
                    spawnedAntenna = true;
                }
                   
            }
            for (int  i = 0; i<rooms.Count-1; i++){
                 float random = Random.Range(0f, 100f);
                 Vector3 randomOffset = new Vector3 (Random.Range(-60f, 60f),Random.Range(-60f, 60f),0);
                    if (random <=difficulty){
                         Instantiate(enemy, rooms[i].transform.position + randomOffset, Quaternion.identity);
                    }

            }
            for (int  i = 0; i<rooms.Count-1; i++){
                 float random2 = Random.Range(0f, 100f);
                 Vector3 randomOffset = new Vector3 (Random.Range(-60f, 60f),Random.Range(-60f, 60f),0);
                    if (random2 <=randomOnItems){
                         Instantiate(Item, rooms[i].transform.position + randomOffset, Quaternion.identity);
                    }

            }
        }else {
            waitTime -=Time.deltaTime;
        }
    }
}
