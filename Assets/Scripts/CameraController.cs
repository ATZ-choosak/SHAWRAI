using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    private float zoomMin , zoomMax , smoothTime , scaleZoom , moveSpeed , Delta;

    [SerializeField]
    private Vector2 maxMove, minMove;

    float zoomSize , currentVelocity;

    Vector3 CamMove;

    bool lockCam;

    GameObject lastRay;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void LockCam(bool b)
    {
        lockCam = b;
    }

    void FixedUpdate()
    {
        if (!lockCam)
        {
            Zoom();
            Move();
            RayCast();
        }
    }

    void Zoom()
    {
        zoomSize -= Input.GetAxis("Mouse ScrollWheel") * scaleZoom;
        zoomSize = Mathf.Clamp(zoomSize, zoomMin, zoomMax);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize , zoomSize , ref currentVelocity , smoothTime * Time.deltaTime);
    }

    void RayCast()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition) , Vector2.zero);
        if (hit.collider != null)
        {
            //init set lastRay
            if (lastRay == null)
            {
                lastRay = hit.collider.gameObject;
            }

            if (hit.collider.gameObject != lastRay)
            {
                lastRay.GetComponent<BaseSystem>().NotHover();
                lastRay = hit.collider.gameObject;
            }

            lastRay.GetComponent<BaseSystem>().onRay();
        }
        else
        {
            if (lastRay)
            {
                lastRay.GetComponent<BaseSystem>().NotHover();
            }
        }
    }

    void Move()
    {
        if (Input.mousePosition.x >= Screen.width - Delta)
        {
            CamMove += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= Delta)
        {
            CamMove += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y >= Screen.height - Delta)
        {
            CamMove += Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= Delta)
        {
            CamMove += Vector3.down * moveSpeed * Time.deltaTime;
        }

        transform.position = Vector3.Lerp(transform.position , CamMove, smoothTime * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x , minMove.x , maxMove.x) , Mathf.Clamp(transform.position.y, minMove.y, maxMove.y) , -10);


    }


}
