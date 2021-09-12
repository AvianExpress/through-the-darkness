using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float movementSpeed;
    void Awake(){
        movementSpeed = 20f;
    }
    void Update()
    {
        var movementX = Input.GetAxis("Horizontal");
        var movementY = Input.GetAxis("Vertical");
         transform.position += new Vector3(movementX, movementY, 0f) * Time.deltaTime * movementSpeed;
    }
}
