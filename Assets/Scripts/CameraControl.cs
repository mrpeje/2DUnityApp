using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject map;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY; 
    private Vector3 originCamPos, newCamPos; 
    private float zoomStep, minCamSize, maxCamSize;

    // Init
    private void Awake()
    {
        SpriteRenderer sp = map.GetComponent<SpriteRenderer>();

        mapMinX = sp.transform.position.x - sp.bounds.size.x / 2f;
        mapMaxX = sp.transform.position.x + sp.bounds.size.x / 2f;

        mapMinY = sp.transform.position.y - sp.bounds.size.y / 2f;
        mapMaxY = sp.transform.position.y + sp.bounds.size.y / 2f;

        zoomStep = 1/20f;
        minCamSize = 1;
        maxCamSize = mapMaxY/2;
    }
    void ZoomIn()
    {
        float newSize = Camera.main.orthographicSize + zoomStep;
        Camera.main.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);   
    }
    void ZoomOut()
    {
        float newSize = Camera.main.orthographicSize - zoomStep;
        Camera.main.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);   
    }
    // Camera view clamping
    Vector3 ClampCamera(Vector3 pos)
    {
        float cameraHeight = Camera.main.orthographicSize * 2f; // orthographicSize is half of camera height
        float cameraWidth = Camera.main.aspect * cameraHeight;

        float minX, maxX, minY, maxY;
        minX = mapMinX + cameraWidth / 2f;
        maxX = mapMaxX - cameraWidth / 2f;
        minY = mapMinY + cameraHeight / 2f;
        maxY = mapMaxY - cameraHeight / 2f;
        

        return new Vector3(Mathf.Clamp(pos.x, minX, maxX), Mathf.Clamp(pos.y, minY, maxY), pos.z);
    }
    void Update()
    {
        // ZoomIn and ZoomOut
        if (Input.touchCount == 2)
        {
            float distance, distance2;
            Vector2 delta1, delta2;

            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                delta1 = touch1.deltaPosition;
                delta2 = touch2.deltaPosition;
                distance2 = Vector2.Distance(touch1.position + delta1, touch2.position + delta2);
                distance = Vector2.Distance(touch1.position, touch2.position);
                if((distance - distance2) > 0)
                    ZoomIn();
                if((distance - distance2) < 0)
                    ZoomOut();
            }
        }
        //Drag camera
        if (Input.touchCount < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                originCamPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                newCamPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position = ClampCamera(Camera.main.transform.position + originCamPos - newCamPos);
            }
        }
    }
}
