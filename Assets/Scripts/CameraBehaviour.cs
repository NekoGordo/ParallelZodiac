using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    const float ANGLE_DISPLACEMENT = 90;
    public float MIN_CAM_DIST, MAX_CAM_DIST;
    

    public float zoomSpd;
    public float camRotSpd;

    public float maxHorizonAngle;
    public GameObject camAnchor;
    public Vector3 sphericalPos;

    GameObject playerCam;
    float currentCamDist, currentCamAngle;
    Vector3 camMove;
    Vector3 camUp, camRight, camForward;
    Vector3 camera_moveUpDown, camera_MoveLeftRight;
    Vector3 camProj;

    bool zoom;

	// Use this for initialization
	void Start ()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        ThrottleCamAtStart();
        camAnchor = GameObject.Find("Camera Anchor");
        sphericalPos.y += ANGLE_DISPLACEMENT;
        playerCam.transform.position = camAnchor.transform.position + ConvertSphericalToCartesian();
        
	}

    private void Update()
    {
        Camera_Move();
        Camera_Update();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
       
	}

    void ThrottleCamAtStart()
    {
        if (sphericalPos.x < MIN_CAM_DIST)
            sphericalPos.x = MIN_CAM_DIST;
        else if (sphericalPos.x > MAX_CAM_DIST)
            sphericalPos.x = MAX_CAM_DIST;
    }

    void Camera_Move()
    {
        sphericalPos.y += Input.GetAxisRaw("Mouse Y") * camRotSpd;
        sphericalPos.z += Input.GetAxisRaw("Mouse X") * camRotSpd;
    }

    void Camera_Update()
    {
        playerCam.transform.position = camAnchor.transform.position + ConvertSphericalToCartesian();
        playerCam.transform.LookAt(camAnchor.transform.position);
    }

    

    void Camera_Zoom()
    {
        sphericalPos.x += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * zoomSpd;
        if(sphericalPos.x < MIN_CAM_DIST) sphericalPos.x = MIN_CAM_DIST;
        if (sphericalPos.x > MAX_CAM_DIST) sphericalPos.x = MAX_CAM_DIST;
    }

    Vector3 ConvertSphericalToCartesian()
    {
        float x = sphericalPos.x * Mathf.Sin(sphericalPos.y * Mathf.Deg2Rad) * Mathf.Sin(sphericalPos.z * Mathf.Deg2Rad);
        float y = sphericalPos.x * Mathf.Cos(sphericalPos.y * Mathf.Deg2Rad);
        float z = sphericalPos.x * Mathf.Sin(sphericalPos.y * Mathf.Deg2Rad) * Mathf.Cos(sphericalPos.z * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }
}
