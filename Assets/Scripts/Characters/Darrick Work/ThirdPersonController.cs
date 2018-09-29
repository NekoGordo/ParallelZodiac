using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    // Drag value to make the player stop moving on a slope.
    // MUST BE A HIGH VALUE TO COMPLETELY STOP SUBTLE SLOPE MOVEMENT
    const float STOP_DRAG = 100;

    public float moveSpd;
    public float camSpd;
    public float startCamDistance;
    public bool softTether;
    public float maxCamAngle;

    float currentCamDistance, currentCamAngle;


    // Minimum and maximum distances between the camera anchor point on the player and the camera
    // KEEP MIN DISTANCE AT 2.5f
    //   Personal testing revealed that any closer obscures the view too much
    float MIN_CAM_DISTANCE = 2.5f,
          MAX_CAM_DISTANCE = 10;

    Vector3 playerMove, cameraMove;
    Vector3 cameraTether;
    Vector3 cameraUp, cameraRight, cameraForward;
    Vector3 player_moveInOut, player_moveLeftRight;
    Vector3 camera_moveUpDown, camera_moveLeftRight;
    Vector3 camProj;
    Vector3 previousPosition, currentPosition;

    float yDiff, camY;

    Rigidbody self;
    Rigidbody camBody;
    Vector3 spawn;
    GameObject playerCam;
    GameObject camAnchor;

    bool zoomMode;


    void Start()
    {
        Application.targetFrameRate = 60;

        ThrottleCameraAtStart();

        // Find necessary components to make this script function
        self = GetComponentInChildren<Rigidbody>();
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        camBody = playerCam.GetComponent<Rigidbody>();
        camAnchor = GameObject.Find("Camera Anchor");

        spawn = GameObject.Find("Spawn").transform.position;
        zoomMode = false;
        previousPosition = transform.position;
        currentPosition = transform.position;
    }

    

    void Update ()
    {
        ToggleZoomMode();

        if (zoomMode)
            Camera_Zoom();
        else
            Camera_Move();

        UpdateCamera(); 
        Player_Move();

        if (self.transform.position.y < -1)
            self.transform.position = spawn;

    }

    public float GetCamDistance()
    {
        return currentCamDistance;
    }

    // OnCollisionStay used for movement to handle movement on slopes.
    private void OnCollisionStay(Collision collision)
    {
        // If no movement is detected, make drag huge to effectively stop sliding.
        // Otherwise, disable drag entirely to allow free movement.
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            self.drag = STOP_DRAG;
        else
            self.drag = 0;
    }

    // OnCollisionExit is called to prevent incline collision detection bug
    //    Changes player drag to 0
    private void OnCollisionExit(Collision collision)
    {        
        self.drag = 0;
    }

    void ThrottleCameraAtStart()
    {
        if (startCamDistance < MIN_CAM_DISTANCE)
            startCamDistance = MIN_CAM_DISTANCE;
        else if (startCamDistance > MAX_CAM_DISTANCE)
            startCamDistance = MAX_CAM_DISTANCE;
        currentCamDistance = startCamDistance;
    }

    void UpdateCamera()
    {
        // Calculate the camera tether
        cameraTether = playerCam.transform.position - camAnchor.transform.position;
        // Draw the camera tether
        Debug.DrawRay(camAnchor.transform.position, playerCam.transform.position - camAnchor.transform.position, Color.cyan);
        Debug.DrawRay(camAnchor.transform.position, cameraTether, Color.red);
        // Update the camera position
        playerCam.transform.position = camAnchor.transform.position + cameraTether.normalized * currentCamDistance;
        // Look at the camera anchor
        playerCam.transform.LookAt(camAnchor.transform.position);
        // Re-calculate the Camera coordinates
        ProjectCameraToPlayerCoordinates();
    }

    // ProjectCameraToPlayerCoordinates converts the camera's coordinates to world space
    void ProjectCameraToPlayerCoordinates()
    {
        cameraRight = new Vector3(playerCam.transform.right.x, 0, playerCam.transform.right.z).normalized;
        cameraForward = new Vector3(playerCam.transform.forward.x, 0, playerCam.transform.forward.z).normalized;
        cameraUp = new Vector3(0, playerCam.transform.up.y, 0).normalized;
    }

    void Player_Move()
    {
        // Get Player movement based on controller/keyboard input
        player_moveInOut = Input.GetAxisRaw("Vertical") * cameraForward.normalized * moveSpd;
        player_moveLeftRight = Input.GetAxisRaw("Horizontal") * cameraRight.normalized * moveSpd;
        playerMove = player_moveInOut + player_moveLeftRight;
        
        // Move the Player
        self.velocity = new Vector3(playerMove.x, self.velocity.y, playerMove.z);
        if(self.velocity != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(new Vector3(self.velocity.x, 0, self.velocity.z));
        // move the camera with the player
        // Update the camera position
        if (softTether == false)
        {
            camBody.velocity = self.velocity;
        }
    }

    void Camera_Move()
    {
        // Get camera movement based on mouse/right joystick movement
        camera_moveLeftRight = Input.GetAxisRaw("Mouse Y") * cameraRight.normalized;
        camera_moveUpDown = Input.GetAxisRaw("Mouse X") * cameraUp.normalized;
        cameraMove = camera_moveUpDown - camera_moveLeftRight;
        // Rotate the camera around the anchor point
        playerCam.transform.RotateAround(camAnchor.transform.position, cameraMove, camSpd);
        
        UpdateCamera();
    }

    void ToggleZoomMode()
    {
        if (Input.GetAxisRaw("Zoom") != 0)
            zoomMode = true;
        else
            zoomMode = false;
    }

    void Camera_Zoom()
    {
        if(Input.GetAxisRaw("Mouse Y") != 0)
        {
            if (Input.GetAxisRaw("Mouse Y") < 0)
            {
                if (currentCamDistance > MIN_CAM_DISTANCE)
                {
                    currentCamDistance -= Time.deltaTime;
                }
            }
            else if (Input.GetAxisRaw("Mouse Y") > 0)
            {
                if(currentCamDistance < MAX_CAM_DISTANCE)
                {
                    currentCamDistance += Time.deltaTime;
                }
            }
        }
    }

    void CalculateCameraAngle()
    {
        camProj = new Vector3(playerCam.transform.position.x, camAnchor.transform.position.y, playerCam.transform.position.z);

        Vector3 toCam = (playerCam.transform.position - camAnchor.transform.position).normalized;
        Vector3 toProj = (camProj - camAnchor.transform.position).normalized;

        currentCamAngle = Mathf.Acos(Vector3.Dot(toCam, toProj)) * Mathf.Rad2Deg;
    }

    // Debug.Log is unreliable
    private void OnGUI()
    {
        GUI.color = Color.black;
        GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
                GUILayout.Label("Player Velocity: ");
                GUILayout.Label(self.velocity.ToString("F4"));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
                GUILayout.Label("Camera Velocity: ");
                GUILayout.Label(camBody.velocity.ToString("F4"));
            GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
}