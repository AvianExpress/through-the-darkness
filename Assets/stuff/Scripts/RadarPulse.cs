using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPulse : MonoBehaviour
{

    [SerializeField] private Transform pfRadarPing;
    private Transform pulseTransform;
    private float range;
    public float rangeMax;
    private float rangeFade;
    private Color pulseColor;
    private HitByRayscan enemy;
    private SpriteRenderer pulseSpriteRenderer;
    private List<Collider2D> listPinged;
    public bool sourcePlayer = false;
    public float rangeSpeed = 100f;
    public float delayFade = 0f;
    // private float movementSpeed;

    void Awake()
    {
        pulseTransform = transform.Find("Pulse");
        pulseSpriteRenderer = pulseTransform.GetComponent<SpriteRenderer>();
        pulseColor = pulseSpriteRenderer.color;
        listPinged = new List<Collider2D>();
        rangeFade = 50f;
        //   movementSpeed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        // var movementX = Input.GetAxis("Horizontal");
        // var movementY = Input.GetAxis("Vertical");
        // transform.position += new Vector3(movementX, movementY, 0f) * Time.deltaTime * movementSpeed;
        range += rangeSpeed * Time.deltaTime;
        if (range > rangeMax)
        {
            // range = 0f;
            // listPinged.Clear();
            Destroy(gameObject);
        }
        pulseTransform.localScale = new Vector3(range, range);
        RaycastHit2D[] raycastHit2Ddarray = Physics2D.CircleCastAll(transform.position, range / 2f, Vector2.zero);
        foreach (RaycastHit2D raycastHit2d in raycastHit2Ddarray)
        {
            if (raycastHit2d.collider != null && !listPinged.Contains(raycastHit2d.collider))
            {
                listPinged.Add(raycastHit2d.collider);
                Vector2 randomOffset = new Vector2(Random.Range(0f, 10f), Random.Range(0f, 10f));
                Transform radarPingTransform = Instantiate(pfRadarPing, raycastHit2d.point + randomOffset, raycastHit2d.transform.rotation);
                RadarPing radarPing = radarPingTransform.GetComponent<RadarPing>();
                if (raycastHit2d.collider.gameObject.CompareTag("Enemy") == true)
                {
                    radarPing.SetColor(new Color(1, 0, 0));
                    radarPing.gameObject.transform.localScale = new Vector3(15f, 15f, -5f);
                    enemy = raycastHit2d.collider.gameObject.GetComponent<HitByRayscan>();
                    if (sourcePlayer == true)
                    {
                        enemy.targetPos = transform.position;
                    }
                }
                 else if (raycastHit2d.collider.gameObject.CompareTag("Item") == true)
                {
                    radarPing.SetColor(new Color(1, 1, 0));
                    radarPing.gameObject.transform.localScale = new Vector3(30f, 30f, -5f);
                    enemy = raycastHit2d.collider.gameObject.GetComponent<HitByRayscan>();
                    if (sourcePlayer == true)
                    {
                        enemy.targetPos = transform.position;
                    }
                }
                else radarPing.SetColor(new Color(0, 1, 0));
                if (delayFade != 0) radarPing.SetDisTimer(delayFade);
                else
                    radarPing.SetDisTimer(rangeMax / rangeSpeed * 0.4f);
            }
        }






        if (range > rangeMax - rangeFade)
        {
            pulseColor.a = Mathf.Lerp(0f, 1f, (rangeMax - range) / rangeFade);
        }
        else
        {
            pulseColor.a = 1f;
        }
        pulseSpriteRenderer.color = pulseColor;
    }


}
