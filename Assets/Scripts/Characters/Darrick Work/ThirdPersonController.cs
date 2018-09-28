using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [Tooltip("Maximum movement speed the player can have")]
    public float moveSpd;
    [Tooltip("Maximum movement speed the camera can have")]
    public float camSpd;

    [Tooltip("Distance between camera anchor and camera")]
    public float startCamDistance;
    [SerializeField]
    float currentCamDistance;

    // Drag value to make the player stop moving on a slope.
    // MUST BE A HIGH VALUE TO COMPLETELY STOP SUBTLE SLOPE MOVEMENT
    const float STOP_DRAG = 100;
    // Minimum and maximum distances between the camera anchor point on the player and the camera
    const float MIN_CAM_DISTANCE = 1,
                MAX_CAM_DISTANCE = 7;

    Vector3 playerMove, cameraMove;
    Vector3 cameraTether;
    Vector3 cameraUp, cameraRight, cameraForward;
    Vector3 player_moveInOut, player_moveLeftRight;
    Vector3 camera_moveUpDown, camera_moveLeftRight;

    Rigidbody self;
    Vector3 spawn;
    GameObject playerCam;
    GameObject camAnchor;

    void Start()
    {
        if (startCamDistance < MIN_CAM_DISTANCE)
            startCamDistance = MIN_CAM_DISTANCE;
        else if (startCamDistance > MAX_CAM_DISTANCE)
            startCamDistance = MAX_CAM_DISTANCE;
        else
            currentCamDistance = startCamDistance;

        self = GetComponentInChildren<Rigidbody>();
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        spawn = GameObject.Find("Spawn").transform.position;
        camAnchor = GameObject.Find("Camera Anchor");
    }

    void Update ()
    {
        UpdateCamera();

        Player_Move();
        Camera_Move();
        
        // Get input from the input source, either WASD/arrows or a controller's left joystick, and apply to the rigidbody's velocity
        //self.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpd, self.velocity.y, Input.GetAxisRaw("Vertical") * moveSpd);
        if (self.transform.position.y < -1)
            self.transform.position = spawn;
    }

    private void OnCollisionStay(Collision collision)
    {
        // For handling movement stopping on slopes.
        // If no movement is detected, make drag huge to effectively stop sliding.
        // Otherwise, disable drag entirely to allow free movement.
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            self.drag = STOP_DRAG;
        else
            self.drag = 0;
    }

    void UpdateCamera()
    {
        cameraTether = playerCam.transform.position - camAnchor.transform.position;
        Debug.DrawRay(camAnchor.transform.position, playerCam.transform.position - camAnchor.transform.position, Color.cyan);
        //playerCam.transform.position = cameraTether.normalized * currentCamDistance;
        playerCam.transform.LookAt(camAnchor.transform.position);
        ProjectCameraToPlayerCoordinates();
    }

    void ProjectCameraToPlayerCoordinates()
    {
        cameraRight = new Vector3(playerCam.transform.right.x, 0, playerCam.transform.right.z);
        cameraForward = new Vector3(playerCam.transform.forward.x, 0, playerCam.transform.forward.z);
        cameraUp = new Vector3(0, playerCam.transform.up.y, 0);
    }

    void Player_Move()
    {
        // Get Player movement based on controller/keyboard input
        player_moveInOut = Input.GetAxisRaw("Vertical") * cameraForward.normalized * moveSpd;
        player_moveLeftRight = Input.GetAxisRaw("Horizontal") * cameraRight.normalized * moveSpd;
        playerMove = player_moveInOut + player_moveLeftRight;
        
        // Move the Player
        self.velocity = new Vector3(playerMove.x, self.velocity.y, playerMove.z);
        // move the camera with the player
        playerCam.transform.position = camAnchor.transform.position + cameraTether.normalized * currentCamDistance;
    }

    void Camera_Move()
    {
            camera_moveLeftRight = Input.GetAxisRaw("Mouse Y") * cameraRight.normalized;
            camera_moveUpDown = Input.GetAxisRaw("Mouse X") * cameraUp.normalized;
            cameraMove = camera_moveUpDown - camera_moveLeftRight;
            playerCam.transform.RotateAround(camAnchor.transform.position, cameraMove, camSpd);
            //cameraTether = playerCam.transform.position - camAnchor.transform.position;
            UpdateCamera();
    }
}