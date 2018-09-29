using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTesting : MonoBehaviour
{
    public bool showCameraAngles;

    [SerializeField]
    float horizontalMovement = 0;
    [SerializeField]
    float verticalMovement = 0;
    [SerializeField]
    float cameraHorizontal = 0;
    [SerializeField]
    float cameraVertical = 0;
    [SerializeField]
    float zoomValue = 0;

    [SerializeField]
    Rigidbody self;
    [SerializeField]
    GameObject playerCam;
    [SerializeField]
    GameObject camAnchor;
    Vector3 cameraTether;
    Vector3 camProjectionAnchorXZ;
    float camDistance;
    float camAngle;

    Vector3 cameraForward, cameraRight, cameraUp;
    Vector3 camProj;

    private void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        self = GetComponentInChildren<Rigidbody>();
        camAnchor = GameObject.Find("Camera Anchor");
        
    }

    void Update ()
    {
        ProjectCameraToPlayerCoordinates();
        cameraTether = camAnchor.transform.position + playerCam.transform.position;
        CalculateCameraAngle();

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        cameraHorizontal = Input.GetAxis("Mouse X");
        cameraVertical = Input.GetAxis("Mouse Y");
        zoomValue = Input.GetAxis("Zoom");
        camDistance = GetComponent<ThirdPersonController>().GetCamDistance();

        if(Mathf.Sign(playerCam.transform.position.y - camAnchor.transform.position.y) < 0)
            camAngle = -camAngle;
        else
            camAngle = Mathf.Abs(camAngle);

        Debug.DrawRay(transform.position, self.velocity, Color.red + Color.yellow);      
    }

    private void OnGUI()
    {

        //GUI.color = Color.black;
        //GUILayout.BeginVertical();
        //    GUILayout.BeginHorizontal();
        //        GUILayout.Label("Velocity:");
        //        GUILayout.BeginVertical();
        //            GUILayout.BeginHorizontal();
        //                GUILayout.Label("Direction:");
        //                GUILayout.Label(self.velocity.ToString());
        //            GUILayout.EndHorizontal();
        //            GUILayout.BeginHorizontal();
        //                GUILayout.Label("Speed:");                        
        //                GUILayout.Label(self.velocity.magnitude.ToString("F4"));
        //            GUILayout.EndHorizontal();
        //        GUILayout.EndVertical();
        //    GUILayout.EndHorizontal();
        //    GUILayout.BeginHorizontal();
        //        GUILayout.Label("Camera Position:");
        //        GUILayout.Label(playerCam.transform.position.ToString("F2"));
        //    GUILayout.EndHorizontal();
        //    GUILayout.BeginHorizontal();
        //        GUILayout.Label("Camera Projection:");
        //        GUILayout.Label(camProj.ToString("F2"));
        //    GUILayout.EndHorizontal();
        //    GUILayout.BeginHorizontal();
        //        GUILayout.Label("Camera angle");
        //        GUILayout.Label(camAngle.ToString("F1"));
        //    GUILayout.EndHorizontal();
        //    GUILayout.BeginHorizontal();
        //        GUILayout.Label("Tether Length:");
        //        GUILayout.Label(camDistance.ToString("F2"));
        //    GUILayout.EndHorizontal();
        //GUILayout.EndVertical();

        
    }

    private void OnDrawGizmosSelected()
    {
        if(showCameraAngles)
            DrawCameraAngles();
    }


    void ProjectCameraToPlayerCoordinates()
    {
        cameraRight = new Vector3(playerCam.transform.right.x, 0, playerCam.transform.right.z);
        cameraForward = new Vector3(playerCam.transform.forward.x, 0, playerCam.transform.forward.z);
        cameraUp = new Vector3(0, playerCam.transform.up.y, 0);

        DrawCameraCoordinates();
    }

    void CalculateCameraAngle()
    {
        camProj = new Vector3(playerCam.transform.position.x, camAnchor.transform.position.y, playerCam.transform.position.z);       
        
        Vector3 toCam = (playerCam.transform.position - camAnchor.transform.position).normalized;
        Vector3 toProj = (camProj - camAnchor.transform.position).normalized;

        camAngle = Mathf.Acos(Vector3.Dot(toCam, toProj)) * Mathf.Rad2Deg;
    }

    void DrawCameraCoordinates()
    {
        Debug.DrawRay(transform.position, cameraForward, Color.blue);
        Debug.DrawRay(transform.position, cameraRight, Color.red);
        Debug.DrawRay(transform.position, cameraUp, Color.green);
    }

#if UNITY_EDITOR
    void DrawCameraAngles()
    {
        camAnchor = GameObject.Find("Camera Anchor");
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        camProj = new Vector3(playerCam.transform.position.x, camAnchor.transform.position.y, playerCam.transform.position.z);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(camAnchor.transform.position, playerCam.transform.position);
        Gizmos.DrawLine(camAnchor.transform.position, camProj);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(camAnchor.transform.position, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(playerCam.transform.position, 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(camProj, 0.5f);
    }
#endif
}   