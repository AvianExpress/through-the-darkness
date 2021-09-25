using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    private RadarDeploy rd;
    public Text text;

    void Awake(){
        rd = GameObject.FindGameObjectWithTag("Player").GetComponent<RadarDeploy>();
    }
    void Update()
    {
        rd = GameObject.FindGameObjectWithTag("Player").GetComponent<RadarDeploy>();
        if (rd.sonarEnabled == false) text.color = new Color(1f,0f,0f);
        else text.color = new Color(0f,1f,0f);
    }
}
