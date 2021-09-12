using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPulse : MonoBehaviour
{

    [SerializeField] private Transform pfRadarPing;
    private Transform pulseTransform;
    private float range;
    public float rangeMax = 200f;
    private float rangeFade;
    private Color pulseColor;
    private HitByRayscan enemy;
    private SpriteRenderer pulseSpriteRenderer;
    private List<Collider2D> listPinged;
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

        float rangeSpeed = 100f;
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
            if (raycastHit2d.collider != null && !listPinged.Contains(raycastHit2d.collider)) {
                listPinged.Add(raycastHit2d.collider);
            Transform radarPingTransform = Instantiate(pfRadarPing, raycastHit2d.point, raycastHit2d.transform.rotation);
            RadarPing radarPing = radarPingTransform.GetComponent<RadarPing>();
                if (raycastHit2d.collider.gameObject.CompareTag("Player") == true)
                {
                    radarPing.SetColor(new Color(0, 1, 0));
                }
                if (raycastHit2d.collider.gameObject.CompareTag("Enemy") == true)
                {
                    radarPing.SetColor(new Color(1, 0, 0));
                    enemy = raycastHit2d.collider.gameObject.GetComponent<HitByRayscan>();
                    enemy.targetPos = transform.position;
                }
                else radarPing.SetColor(new Color(1, 0, 1));
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
