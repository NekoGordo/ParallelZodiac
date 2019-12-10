using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerCollisionDetection))]
public class PlayerBehaviour : MonoBehaviour
{
    public float GRAVITY = 9.8f;

    public bool debugCoordinates, debugMovement, debugCollisions;

    public float MIN_CHR_SPD = 1,
                 MAX_CHR_SPD = 10,

                 MIN_SPRINT = 1.1f,
                 MAX_SPRINT = 3.5f,

                 MIN_SNEAK = 0.1f,
                 MAX_SNEAK = 0.9f,

                 
                
                 MIN_JUMP_TIME = 2,
                 MAX_JUMP_TIME = 8,

                 MIN_CLIMB_ANGLE = 30,
                 MAX_CLIMB_ANGLE = 90;



    public float moveSpd, sprintFactor, sneakFactor, /*jumpStep, jumpTime,*/ jump, airDelay, climbAngle, dragSpeed, gravityAdd;

    public bool moving, canClimb, climbing, canSwim, swimming, canJump, jumping, sprinting, sneaking, acting, attacking;

    float appliedFallVelocity = 0;
    float fallTimeStep = 0;

    Vector3 forward, colliderNormal;
    Collider self_col;
    GameObject playerCam;
    CameraBehaviour camScript;
    PlayerCollisionDetection collisionDetection;

    Vector3 debug_playerMove;

    /// <summary>
    /// Initialize core essential values at Start
    /// </summary>
    private void Start()
    {
        self_col = GetComponent<Collider>();
        camScript = GetComponent<CameraBehaviour>();
        collisionDetection = GetComponent<PlayerCollisionDetection>();
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        Physics.gravity = Vector3.up * -GRAVITY;
    }

    /// <summary>
    /// Constantly check collisions, apply gravity as needed,
    /// and check for button inputs and movement.
    /// </summary>
    void FixedUpdate()
    {

        if (!collisionDetection.grounded && !climbing && !swimming && !jumping) Gravity();
        GetJumpInput();
        if (collisionDetection.groundAngle < climbAngle)
        {
            Player_Move();
        }
        else
        {
            
            if (canClimb) { }
            else
                SlideDownSlope();
        }
    }

    private void Update()
    {
        if (Physics.gravity.magnitude != GRAVITY)
            Physics.gravity = Vector3.up * -GRAVITY;
        if(collisionDetection.hitCeiling)
        {
            canJump = false;
            if(jumping)
            {
                jumping = false;
                StopCoroutine("Jump");
            }
        }
        DrawDebug();        
        GetButtonInput();        
    }

    
    void Gravity()
    {
        transform.position += Physics.gravity * Time.deltaTime;
    }

    /// <summary>
    /// Make the player move on the ground and up slopes.
    /// </summary>
    void Player_Move()
    {
        // Initially assume no movement
        Vector3 playerMove = Vector3.zero;

        // Calculate the forward direction
        Vector3 newForward = CalculateInputForwardDirection();

        
        // If an input was detected, move the player.
        if (newForward != Vector3.zero)
        {
            // Face the forward direction
            transform.rotation = Quaternion.LookRotation(new Vector3(newForward.x, 0, newForward.z));
            if (Physics.Raycast(transform.position, transform.forward, out collisionDetection.wallHits[0], collisionDetection.width + collisionDetection.collisionPadding))
                collisionDetection.hitWall_forward = true;
            else
                collisionDetection.hitWall_forward = false;

            // Calculate the forward orientation as a cross of the ground normal and the player's right direction
            if (collisionDetection.groundHit.normal != Vector3.zero)
                newForward = Vector3.Cross(transform.right, collisionDetection.groundHit.normal) * moveSpd;
            else
                newForward = Vector3.Cross(transform.right, transform.up) * moveSpd;

            // Apply speed modification and move the player forward
            if (sprinting)
                playerMove = ModSpeed(newForward, sprintFactor);
            else if (sneaking)
                playerMove = ModSpeed(newForward, sneakFactor);
            else
                playerMove = ModSpeed(newForward);
            
        }

        if (!collisionDetection.hitWall_forward)
        {
            transform.position += playerMove;
        }
        else
        {
            if (playerMove != Vector3.zero)
            {
                transform.position += Vector3.Cross(collisionDetection.wallHits[0].normal, Vector3.up) * Mathf.Sign(Vector3.SignedAngle(-collisionDetection.wallHits[0].normal, transform.forward, Vector3.up)) * Time.deltaTime;
            }
            else
            {
            }
        }
    }

    /// <summary>
    /// Make the player slide down slopes if they can't climb.
    /// </summary>
    void SlideDownSlope()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(collisionDetection.groundHit.normal.x, 0, collisionDetection.groundHit.normal.z) * -1);
        transform.position += collisionDetection.groundHit.transform.forward * Time.deltaTime * dragSpeed;
    }

    /// <summary>
    /// Use Input to calculate the new forward direction.
    /// Called in Player_Move
    /// </summary>
    /// <returns>Return the forward direction calculated by input.</returns>
    Vector3 CalculateInputForwardDirection()
    {
        Vector3 move_InOut = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1, 1) * camScript.camForward;
        Vector3 move_LeftRight = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1, 1) * camScript.camRight;
        return move_InOut + move_LeftRight;
    }

    /// <summary>
    /// ModSpeed modifies movement to accomodate for player state.
    /// </summary>
    /// <param name="movement">Movement vector to modify</param>
    /// <param name="speedMod">Modification factor</param>
    /// <returns>Return the called movement vector times the modifier and Time.deltaTime</returns>
    Vector3 ModSpeed(Vector3 movement, float speedMod = 1)
    {
        return movement * speedMod * Time.deltaTime;
    }

    /// <summary>
    /// GetButtonInput checks for just that.
    /// </summary>
    void GetButtonInput()
    {
        // If changing sneak state, also change sprint to false
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            sneaking = !sneaking;
            if (sprinting) sprinting = false;
        }
        // If changing sprint state, also change sneak state to false
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = !sprinting;
            if (sneaking) sneaking = false;
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1)) acting = true; else acting = false;
        if (Input.GetMouseButtonDown(0)) attacking = true; else attacking = false;

        if (acting) Act();
        if (attacking) Attack();
    }

    void GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            canJump = false;
            StartCoroutine(Jump());
        }
    }

    /// <summary>
    /// Function for when Action Input is given.
    /// Action is tied to object being acted on.
    /// </summary>
    void Act()
    {
        Debug.Log("You pressed the action button.");
        Debug.Log("You can talk to NPCs, pick up items, and interact with your environment with this.");
    }

    /// <summary>
    /// Function for when Attack Input is given.
    /// Attack is tied to equipped weapon.
    /// </summary>
    void Attack()
    {
        Debug.Log("you pressed the attack button.");
        Debug.Log("Your equipped weapon determines your attack pattern.");
    }

    IEnumerator FaceMoveDirection()
    {
        yield return null;
    }

    IEnumerator Jump()
    {
        float timeStep = 0;
        float jumpStep = jump;
        float jumpTime = jump;
        while (timeStep < jumpTime)
        {
            jumping = true;
            transform.position += Vector3.up * jumpStep;
            timeStep += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(airDelay);
        jumping = false;
    }

    void DrawDebug()
    {
        if(debugCoordinates)DrawDebug_MovementCoordinates();
        Debug.DrawLine(transform.position + Vector3.up * 0.12f, transform.position + Vector3.up * 0.12f + debug_playerMove.normalized * 2, Color.cyan);
    }  

    void DrawDebug_MovementCoordinates()
    {
        Vector3 normal = transform.up, cross = transform.forward;

        if (collisionDetection.groundHit.normal != Vector3.zero)
        {
            normal = collisionDetection.groundHit.normal;
            cross = Vector3.Cross(transform.right, collisionDetection.groundHit.normal);
        }

        Debug.DrawLine(transform.position, transform.position + transform.right * 5, Color.black);
        Debug.DrawLine(transform.position, transform.position + normal * 5, Color.black);
        Debug.DrawLine(transform.position, transform.position + cross * 5, Color.blue);
    }
}
