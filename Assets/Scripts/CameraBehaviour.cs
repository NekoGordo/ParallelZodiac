using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    #region Constants
    const float BASE_VERTICAL_ANGLE = 90;
    #endregion

    #region Constraints
    public float MIN_ZOOM_SPD = 1,
                 MAX_ZOOM_SPD = 10;

    public float MIN_ROT_SPD = 1,
                 MAX_ROT_SPD = 10;

    public float MIN_CAM_DIST = 2.5f, 
                 MAX_CAM_DIST = 10;

    public float MIN_VERTICAL_ANGLE = 15,
                 MAX_VERTICAL_ANGLE = 60;
    #endregion

    #region Fields
    #region Public
    public GameObject playerCam;
    public GameObject camAnchor;
    public Vector3 sphericalPos;

    public float zoomSpd;
    public float camRotSpd;
    public float maxHorizonAngle;

    public Vector3 camRight;
    public Vector3 camForward;
    #endregion

    public bool debug_DrawCoordinates;

    #region Private
    Vector3 camMove;
    #endregion
    #endregion

    ///<summary>
    ///Assign playerCam and camAnchor and tether playerCam to the character object.
    ///</summary>
    public void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        camAnchor = GameObject.Find("Camera Anchor").gameObject;
        Camera_Update();        
	}

    /**
     * Update constantly checks for camera movement, makes sure camera is tethered and facing player, 
     * and projects its coordinates for player movement.
     */

    ///<summary>
    ///Check for camera movement and tether the camera to the character object.
    ///Project camera coordinates for character movement based on character state.
    ///</summary>
    void Update()
    {
        if(debug_DrawCoordinates) DrawDebugDisplay();
        if (GetComponent<PlayerBehaviour>().swimming == true)
            ProjectCamCoordinates(false);
        else
            ProjectCamCoordinates(true);
        Camera_Move();
        Camera_Zoom();
        Camera_Update();
        
    }

    ///<summary>
    ///Move the camera with mouse movement and constrain movement.
    ///</summary>
    void Camera_Move()
    {
        sphericalPos.y += Input.GetAxisRaw("Mouse Y") * camRotSpd;
        sphericalPos.z += Input.GetAxisRaw("Mouse X") * camRotSpd;
        ConstrainCamera();
    }

    void Camera_Zoom()
    {
        sphericalPos.x -= Input.GetAxisRaw("Mouse ScrollWheel") * zoomSpd;
        ConstrainCamera();
    }

    public void EditorCameraUpdate()
    {
        Camera_Update();
    }

    ///<summary>
    ///Move the camera with the anchor position using the spherical position and constantly face the anchor.
    ///</summary>
    void Camera_Update()
    {
        playerCam.transform.position = camAnchor.transform.position + ConvertSphericalToCartesian();
        playerCam.transform.LookAt(camAnchor.transform.position);
    }

     ///<summary>
     ///Project the camera's current facing as coordinates for player movement.
     ///</summary>
     ///<param name="flatCoordinates">
     /// False when in a swim state, true for all other states.
     /// </param>
    void ProjectCamCoordinates(bool flatCoordinates)
    {
        camRight = new Vector3(playerCam.transform.right.x, 0, playerCam.transform.right.z).normalized;
        if(flatCoordinates)
            camForward = new Vector3(playerCam.transform.forward.x, 0, playerCam.transform.forward.z).normalized; // Retains a rigid forward coordinate
        else
            camForward = new Vector3(playerCam.transform.forward.x, playerCam.transform.forward.y, playerCam.transform.forward.z).normalized; // Has a dynamic forward coordinate that moves with the camera.
    }

    ///<summary>
    ///Constrain the spherical position angular values Y(phi) and Z(theta).
    ///Y is from negative to positive max vertical angle.
    ///Z is from 0 to 360 degrees.
    ///</summary>
    void ConstrainCamera()
    {
        if (sphericalPos.x < MIN_CAM_DIST) sphericalPos.x = MIN_CAM_DIST;
        else if (sphericalPos.x > MAX_CAM_DIST) sphericalPos.x = MAX_CAM_DIST;
        // Constrain vertical angle, phi, to be the maximum angle out from the horizon on either side
        if (sphericalPos.y < BASE_VERTICAL_ANGLE - MAX_VERTICAL_ANGLE) sphericalPos.y = BASE_VERTICAL_ANGLE - MAX_VERTICAL_ANGLE;
        else if (sphericalPos.y > BASE_VERTICAL_ANGLE + MAX_VERTICAL_ANGLE) sphericalPos.y = BASE_VERTICAL_ANGLE + MAX_VERTICAL_ANGLE;
        // COnstrain horizontal angle, theta, to be between 0 and 360
        if (sphericalPos.z < 0) sphericalPos.z += 360;
        else if (sphericalPos.z > 360) sphericalPos.z -= 360;
    }

    ///<summary>
    ///Convert the spherical position of the camera to cartesian x,y,z values. Used to update the camera world position.
    ///</summary>
    Vector3 ConvertSphericalToCartesian()
    {
        float x = sphericalPos.x * Mathf.Sin(sphericalPos.y * Mathf.Deg2Rad) * Mathf.Sin(sphericalPos.z * Mathf.Deg2Rad);
        float y = sphericalPos.x * Mathf.Cos(sphericalPos.y * Mathf.Deg2Rad);
        float z = sphericalPos.x * Mathf.Sin(sphericalPos.y * Mathf.Deg2Rad) * Mathf.Cos(sphericalPos.z * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }

    /// <summary>
    /// Display the projected camera coordinates in the Unity editor.
    /// </summary>
    void DrawDebugDisplay()
    {        
        Debug.DrawLine(camAnchor.transform.position, camAnchor.transform.position + camRight * 10, Color.yellow);
        Debug.DrawLine(camAnchor.transform.position, camAnchor.transform.position + camForward * 10, Color.yellow);
    }
}
