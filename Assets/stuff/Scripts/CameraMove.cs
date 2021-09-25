using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform pfRadarPing;
    private float movementSpeed;
    public Canvas canvas;
    private Vector3 pointA;
    private Vector3 pointB;
    private bool isMoving = false;
    void Awake(){
        movementSpeed = 20f;
        pointB=gameObject.transform.position;
    }
    void Update()
    {
        // var movementX = Input.GetAxis("Horizontal");
        // var movementY = Input.GetAxis("Vertical");
        //  transform.position += new Vector3(movementX, movementY, 0f) * Time.deltaTime * movementSpeed;
        if (Input.GetMouseButton(0)){
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z+400f));
            pointA = gameObject.transform.position;
            if (pointB.x-pointA.x >= 15f || pointB.y-pointA.y >= 15f || pointB.x-pointA.x <= -15f || pointB.y-pointA.y <= -15f){
            isMoving = true;
            Transform radarPingTransform = Instantiate(pfRadarPing, pointB, Quaternion.identity);
            RadarPing radarPing = radarPingTransform.GetComponent<RadarPing>();
            radarPing.SetColor(new Color(1, 1, 1));
            radarPing.gameObject.transform.localScale = new Vector3(10f, 10f, -5f);
            radarPing.SetDisTimer(1f);
            } else isMoving = false;
            // Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObject.transform.position.z));
            // transform.position = touchPosition;
            // Debug.Log(touchPosition);
        }
        if (isMoving){
        var dir = pointB-pointA;
        var angle = Mathf.Atan2(dir.y, dir.x) *Mathf.Rad2Deg;
        var rotateto = Quaternion.AngleAxis(angle + 270f, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateto, 7f );
        transform.position= Vector3.MoveTowards(transform.position, pointB, movementSpeed*Time.deltaTime);
        }
    }
}
