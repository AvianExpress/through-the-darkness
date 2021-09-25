using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RadarDeploy : MonoBehaviour
{
    public RadarPulse pfRadarPulse;
    private float delay;
    private float delayMax;
    // public float movementSpeed;
    
    [Range(100f, 500f)]
    public float rangeMax = 200f;
    public AudioSource boop;
    public AudioSource button;
    public bool sonarEnabled;
    public Text txtx;
    public float speed;
    public float scale = 50f;
    void Awake()
    {
        txtx.text = rangeMax.ToString();
        if (gameObject.tag != "Player")
            sonarEnabled = true;
        delayMax = 5f;
        delay = 0f;
        sonarEnabled = false;

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
                txtx.text = rangeMax.ToString();
                pfRadarPulse.rangeMax = rangeMax;
                delayMax = (rangeMax * 2) / 100f;
                delay = delayMax;
                pfRadarPulse.delayFade = delayMax / 2f;
                if (speed != 0) pfRadarPulse.rangeSpeed = speed;
                Instantiate(pfRadarPulse, this.transform.position, Quaternion.identity);
                if (gameObject.tag == "Player")
                {
                    boop.Play();
                    pfRadarPulse.sourcePlayer = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.tag == "Player")
            {
                ToggleSonar();
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if(rangeMax<500f)
            rangeMax += scale;
            txtx.text = rangeMax.ToString();
            Debug.Log(rangeMax);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if(rangeMax>100f)
            rangeMax -= scale;
            txtx.text = rangeMax.ToString();
            Debug.Log(rangeMax);
        }
    }

    public void ToggleSonar()
    {
        this.sonarEnabled = !this.sonarEnabled;
        this.delay = 0;
        button.Play();
    }
}
