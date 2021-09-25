using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    public GameObject player;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    private GameObject antenna;

    private void Awake()
    {
        targetPosition = new Vector3(200, 45);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();

    }
    private void Update()
    {
        antenna = GameObject.FindGameObjectWithTag("Antenna");
        if (antenna)
            targetPosition = antenna.transform.position;
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
        float borderSize = 100f;
        Vector3 targetPositionOffScreen= Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionOffScreen.x<=borderSize ||targetPositionOffScreen.x >= Screen.width -borderSize || targetPositionOffScreen.y <=borderSize ||targetPositionOffScreen.y >= Screen.height -borderSize;
        if (isOffScreen) {
            Vector3 cappedTargetScreenPosition = targetPositionOffScreen;
            if (cappedTargetScreenPosition.x<=borderSize) cappedTargetScreenPosition.x = borderSize;
            if (cappedTargetScreenPosition.x>= Screen.width-borderSize) cappedTargetScreenPosition.x = Screen.width-borderSize;
            if (cappedTargetScreenPosition.y<=borderSize) cappedTargetScreenPosition.y = borderSize;
            if (cappedTargetScreenPosition.y>= Screen.height-borderSize) cappedTargetScreenPosition.y = Screen.height-borderSize;
            Vector3 pointerWorldPosition = uiCamera.ScreenToViewportPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.position =  new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        
        }
    }

    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
