using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTesting : MonoBehaviour
{
    [SerializeField]
    float horizontalMovement = 0;
    [SerializeField]
    float verticalMovement = 0;
    [SerializeField]
    float cameraHorizontal = 0;
    [SerializeField]
    float cameraVertical = 0;

    [SerializeField]
    Rigidbody self;
    [SerializeField]
    GameObject playerCam;

    private void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        self = GetComponentInChildren<Rigidbody>();
    }
    // Update is called once per frame
    void Update ()
    {
        
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        cameraHorizontal = Input.GetAxis("Mouse X");
        cameraVertical = Input.GetAxis("Mouse Y");

        Debug.DrawRay(transform.position, self.velocity, Color.red + Color.yellow);

        ProjectCameraToPlayerCoordinates();
    }

    void OnCollisionEnter(Collision collision)
    {

    }

    private void OnGUI()
    {

        GUI.color = Color.black;
        GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
                GUILayout.Label("Velocity:");
                GUILayout.BeginVertical();
                    GUILayout.BeginHorizontal();
                        GUILayout.Label("Direction:");
                        GUILayout.Label(self.velocity.ToString());
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                        GUILayout.Label("Speed:");
                        
                        GUILayout.Label(self.velocity.magnitude.ToString("F4"));
                    GUILayout.EndHorizontal();
        GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                GUILayout.Label("Angles of movement:");
                GUILayout.BeginHorizontal();
                    GUILayout.Label(Vector3.Angle(self.velocity, Vector3.right).ToString("F2"));
                    GUILayout.Label(Vector3.Angle(self.velocity, Vector3.up).ToString("F2"));
                    GUILayout.Label(Vector3.Angle(self.velocity, Vector3.forward).ToString("F2"));
        GUILayout.EndHorizontal();
            GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }

    void ProjectCameraToPlayerCoordinates()
    {
        Vector3 cameraRight = new Vector3(playerCam.transform.right.x, 0, playerCam.transform.right.z);
        Vector3 cameraForward = new Vector3(playerCam.transform.forward.x, 0, playerCam.transform.forward.z);
        Vector3 cameraUp = new Vector3(0, playerCam.transform.up.y, 0);

        Debug.DrawRay(transform.position, cameraForward, Color.blue);
        Debug.DrawRay(transform.position, cameraRight, Color.red);
        Debug.DrawRay(transform.position, cameraUp, Color.green);
    }
}
