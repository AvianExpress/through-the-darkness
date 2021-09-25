using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitByRayscan : MonoBehaviour
{
   
    public float speed;
    private Transform target;
    private float delayShow;
    private float delayShowMax = 1.5f;
    public Vector3 targetPos;
    [SerializeField] private Transform pfRadarPing;

    private AudioSource alert;
    private float criticalRange;

    void Start(){
        alert = GameObject.FindGameObjectWithTag("Alert").GetComponent<AudioSource>();
        delayShowMax = 1f;
        criticalRange = 80f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPos = transform.position;
    }

    void Update(){
        RaycastHit2D[] raycastHit2Ddarray = Physics2D.CircleCastAll(transform.position, criticalRange, Vector2.zero);
        foreach (RaycastHit2D raycastHit2d in raycastHit2Ddarray){
            if (raycastHit2d.collider.gameObject.CompareTag("Player") == true){
                if (!alert.isPlaying){
                    alert.Play();
                }
                targetPos = target.position;
                if(delayShow >= delayShowMax){
                Vector3 randomOffset = new Vector3(Random.Range(0f, 2f), Random.Range(0f, 2f), 0f);
                Transform radarPingTransform = Instantiate(pfRadarPing, transform.position + randomOffset, raycastHit2d.transform.rotation);
                RadarPing radarPing = radarPingTransform.GetComponent<RadarPing>();
                radarPing.SetDisTimer(delayShowMax * 3);
                radarPing.SetColor(new Color(1, 0, 0));
                delayShow=0;
                }
                delayShow += Time.deltaTime;
            }
        }
        // Debug.Log("Targeting" + Vector3.Distance(tragetPos,transform.position));
         var dir = targetPos-transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) *Mathf.Rad2Deg;
        var rotateto = Quaternion.AngleAxis(angle + 270f, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateto, 3f );
        transform.position= Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
}
