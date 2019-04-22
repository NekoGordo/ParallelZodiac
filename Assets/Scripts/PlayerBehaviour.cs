using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    const float STOP_DRAG = 100;

    public float MIN_CHR_MOVESPD = 1,
                 MAX_CHR_MOVESPD = 10;

    public float MIN_SPRINT_FACTOR = 1.1f,
                 MAX_SPRINT_FACTOR = 3.5f;

    public float MIN_SNEAK_FACTOR = 0.1f,
                 MAX_SNEAK_FACTOR = 0.9f;

    public float MIN_JUMP = 2,
                 MAX_JUMP = 8;

    public float MIN_CLIMB_ANGLE = 30,
                 MAX_CLIMB_ANGLE = 90;

    public float moveSpd;
    public float sprintFactor, sneakFactor, jumpHeight;
    public float climbAngle;
    public Vector3 spawnPos;

    Vector3 playerMove, surfaceOrient;
    Vector3 camRight, camForward, camUp;

    Rigidbody self;
    GameObject playerCam;

    public bool sprint, sneak, jump, act, climb, attack;

    // Use this for initialization
	void Start ()
    {
        self = GetComponentInChildren<Rigidbody>();
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetButtonInput();
        Player_Move();
        if (transform.position.y < -10)
            transform.position = spawnPos;
	}

    private void OnCollisionEnter(Collision collision)
    {
        jump = false;
        self.velocity = new Vector3(self.velocity.x, 0, self.velocity.z);
        if (collision.gameObject.tag == "Surface") surfaceOrient = collision.gameObject.transform.rotation.eulerAngles;
    }

    private void OnCollisionStay(Collision collision)
    {
        jump = false;

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            self.drag = STOP_DRAG;
        else
            self.drag = 0;
        self.velocity = new Vector3(self.velocity.x, 0, self.velocity.z);
    }

    private void OnCollisionExit(Collision collision)
    {
        self.drag = 0;
        jump = true;
        surfaceOrient = Vector3.zero;
    }

    void GetButtonInput()
    {
        // If changing sneak state, modify height to accomodate and change sprint to false
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            sneak = !sneak;
            if (sprint) sprint = false;
        }
        // If changing sprint state, change sneak state to false and modify height to accomodate ONLY IF SNEAKING
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = !sprint;
            if (sneak) sneak = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {            
            jump = true;
            self.drag = 0;
            Jump();
            //StartCoroutine(Jump());
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1)) act = true; else act = false;
        if (Input.GetMouseButtonDown(0)) attack = true; else attack = false;

        if (act) Act();
        if (attack) Attack();
    }

    void Player_Move()
    {
        // Project the camera coordinates for movement direction
        ProjectCameraCoordinates();

        // Calculate the movement
        Vector3 player_moveInOut = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1, 1) * camForward.normalized * moveSpd;
        Vector3 player_moveLeftRight = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1, 1) * camRight.normalized * moveSpd;
        playerMove = player_moveInOut + player_moveLeftRight;

        // Face the movement direction
        if (playerMove != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(new Vector3(playerMove.x, 0, playerMove.z));

        // Move, modifying movement to accomodate for current move status
        if (sprint)
            self.transform.position += ModSpeed(sprintFactor);
        else if (sneak)
            self.transform.position += ModSpeed(sneakFactor);
        else
            self.transform.position += ModSpeed();
    }

    /**
     * Change the speed of the player based on if they are moving normally, sprinting, or sneaking.
     * Pass no parameter for normal movement and corresponding factors for sneaking or sprinting
     */
    Vector3 ModSpeed(float speedMod = 1)
    {
        return new Vector3(playerMove.x, self.velocity.y, playerMove.z) * speedMod * Time.deltaTime;
    }

    void Act()
    {
        Debug.Log("You pressed the action button.");
        Debug.Log("You can talk to NPCs, pick up items, and interact with your environment with this.");
    }

    void Attack()
    {
        Debug.Log("you pressed the attack button.");
        Debug.Log("Your equipped weapon determines your attack pattern.");
    }
    
    void Jump()
    {
        Vector3 jumpForce = Vector3.up * jumpHeight;
        self.velocity += jumpForce;
    }

    void ProjectCameraCoordinates()
    {
        camRight = new Vector3(playerCam.transform.right.x, 0, playerCam.transform.right.z).normalized;
        camForward = new Vector3(playerCam.transform.forward.x, 0, playerCam.transform.forward.z).normalized;
        camUp = new Vector3(0, playerCam.transform.up.y, 0).normalized;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawSphere(spawnPos, 0.5f);
    }
}
