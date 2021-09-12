using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByRayscan : MonoBehaviour
{
   
    public float speed;
    private Transform target;
    public Vector3 targetPos;

    private float criticalRange;

    void Start(){
        criticalRange = 80f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPos = transform.position;
        Debug.Log(targetPos);
    }

    void Update(){
        RaycastHit2D[] raycastHit2Ddarray = Physics2D.CircleCastAll(transform.position, criticalRange, Vector2.zero);
        foreach (RaycastHit2D raycastHit2d in raycastHit2Ddarray){
            if (raycastHit2d.collider.gameObject.CompareTag("Player") == true){
                targetPos = target.position;
            }
        }
        // Debug.Log("Targeting" + Vector3.Distance(tragetPos,transform.position));
        transform.position= Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
}
