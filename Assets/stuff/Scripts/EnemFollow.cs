using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Vector3 tragetPos;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        tragetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position= Vector3.MoveTowards(transform.position, tragetPos, speed*Time.deltaTime);
    }
}
