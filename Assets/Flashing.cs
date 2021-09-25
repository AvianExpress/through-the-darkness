using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    public float flashtime;
    void Start()
    {
        flashtime = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        flashtime -= Time.deltaTime;
        if(flashtime == 0 ){
            if(gameObject.activeSelf == true)
            gameObject.SetActive(false);
            else  gameObject.SetActive(true);
            flashtime = 1.5f;
        }
    }
}
