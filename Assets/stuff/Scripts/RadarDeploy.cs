using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarDeploy : MonoBehaviour
{
    public RadarPulse pfRadarPulse;
    private float delay;
    private float delayMax;
    // public float movementSpeed;
    public float rangeMax = 200f;
    public AudioSource boop;
    public bool sonarEnabled = false;
    void Awake()
    {
        delayMax = 5f;
        delay = 0f;
        // movementSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        // var movementX = Input.GetAxis("Horizontal");
        // var movementY = Input.GetAxis("Vertical");
        // transform.position += new Vector3(movementX, movementY, 0f) * Time.deltaTime * movementSpeed;
        if (sonarEnabled == true)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                pfRadarPulse.rangeMax = rangeMax;
                delayMax = (rangeMax * 2) / 100f;
                delay = delayMax;
                Instantiate(pfRadarPulse, this.transform.position, Quaternion.identity);
                boop.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            sonarEnabled =!sonarEnabled;
            delay = 0;
        }
    }
}
