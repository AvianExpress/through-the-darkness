using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameover;
    public GameObject gamewon;
    public AudioSource crack;
    public AudioSource staticSound;
    public AudioSource pickup;
    public AudioSource shutdown;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {   
            crack.Play();
            gameover.SetActive(true);
            staticSound.Stop();
            Destroy(gameObject);
        }
        if (other.CompareTag("Antenna"))
        {   
            Destroy(other.gameObject);
            shutdown.Play();
            gamewon.SetActive(true);
            staticSound.Stop();
            Destroy(gameObject);
            
        }
        if (other.CompareTag("Item"))
        {   
            pickup.Play();
        }
    }
}
