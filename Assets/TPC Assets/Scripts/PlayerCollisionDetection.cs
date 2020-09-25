using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    #region Fields

    enum RaycastPosition
    {
        GROIN,  // Bottom position on a large body, center position on a small body
        CORE,   // Center position on a large body
        HEAD,   // Head position on a large body
    }

    enum RaycastDirection
    {
        NULL = -1,
        FORWARD,
        FORWARD_RIGHT,
        RIGHT,
        BACK_RIGHT,
        BACK,
        BACK_LEFT,
        LEFT,
        FORWARD_LEFT,        
    }

    #region constants
    public const int SMALL_COLLIDER_WALLCHECKS = 8,
                     LARGE_COLLIDER_WALLCHECKS = 24,
                     SMALL_COLLIDER_ITERATIONS = 1,
                     LARGE_COLLIDER_ITERATIONS = 3;

    const float DEFAULT_HIT_DUMMY = -9999.0f;
    #endregion

    #region Public
    [HideInInspector]
    public float groundAngle;
    [HideInInspector]
    public RaycastHit groundHit, headHit;
    [HideInInspector]
    public RaycastHit[] wallHits; // 0-7 = groin/core hits, 8 - 15 = core hits, 16 - 23 = head hits
    
    public bool debugCollisions;
    public float collisionPadding;
    public LayerMask groundLayer, defaultLayer;
    public bool grounded, hitWall_forward, againstWall, hitCeiling, falling;
    public float width, height;

    #endregion

    #region Private
    Collider self_col;
    PlayerBehaviour playerScript;
    Vector3 forward, forwardRight, right, backRight, back, backLeft, left, forwardLeft;
    #endregion

    #endregion

    #region Methods

    #region Universal

    void Start()
    {        
        self_col = GetComponent<Collider>();
        playerScript = GetComponent<PlayerBehaviour>();
        width = self_col.bounds.extents.x;
        height = self_col.bounds.extents.y;
        UpdateCollisionVectors();
        if (height <= width * 1.3f)
            wallHits = new RaycastHit[SMALL_COLLIDER_WALLCHECKS]; /* wallHits indexes 0 - 7 = center hits*/
        else
            wallHits = new RaycastHit[LARGE_COLLIDER_WALLCHECKS];
            /* wallHits indexes 0  - 7  ~ groin hits
               wallHits indexes 8  - 15 = core hits
               wallHits indexes 16 - 23 ~ groin hits */  
    }

    /// <summary>
    /// Run debug info.
    /// Track collisions and collider bounds changes.
    /// </summary>
    void Update()
    {
        DrawDebug_CollisionChecking();
        CheckBoundChanges();
        UpdateCollisionVectors();
        CheckCollision_Ground();
        CalculateGroundAngle();        
        CheckCollisions_Walls();
        CheckCollision_Ceiling();        
    }

    /// <summary>
    /// Check for if the player's collider bounds change.
    /// Update as needed.
    /// </summary>
    void CheckBoundChanges()
    {
        // If the collider size changes, update player width and height
        // Time.deltaTime used to ignore extremely minute size changes, which do happen while moving
        if (width  > Mathf.Abs(self_col.bounds.extents.x + Time.deltaTime) ||
            width  < Mathf.Abs(self_col.bounds.extents.x - Time.deltaTime) ||
            height > Mathf.Abs(self_col.bounds.extents.y + Time.deltaTime) ||
            height < Mathf.Abs(self_col.bounds.extents.y - Time.deltaTime))
        {
            UpdateCollisionBoundExtents();
            if (height < width * 1.5)
                wallHits = new RaycastHit[SMALL_COLLIDER_WALLCHECKS];
            else
                wallHits = new RaycastHit[LARGE_COLLIDER_WALLCHECKS];
        }
    }

    /// <summary>
    /// Update the current player width and height.
    /// </summary>
    public void UpdateCollisionBoundExtents()
    {
        width = self_col.bounds.extents.x;
        height = self_col.bounds.extents.y;
    }

    #endregion

    #region Ground
    /// <summary>
    /// Check directly beneath the player for if there is a collision.
    /// Reposition player to keep from clipping into the ground.
    /// </summary>
    void CheckCollision_Ground()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, out groundHit, height + collisionPadding))
        {
            if (Vector3.Distance(transform.position, groundHit.point) < height)
            {
                transform.position = groundHit.point + Vector3.up * height;
            }
            grounded = true;
            playerScript.jumping = false;
            falling = false;
            playerScript.StopAllCoroutines();
        }
        else
        {
            grounded = false;
        }
    }

    /// <summary>
    /// Calculate the angle between the groundHit normal and self upward direction based on self right direction.
    /// Result is stored in groundAngle.
    /// groundAngle is 0 when not grounded.
    /// </summary>
    void CalculateGroundAngle()
    {
        if (!grounded)
            groundAngle = 0;
        else
            groundAngle = Vector3.SignedAngle(groundHit.normal, transform.up, transform.right);
    }
    #endregion

    #region Wall

    void UpdateCollisionVectors()
    {
        forward = transform.forward;
        forwardRight = (transform.forward + transform.right).normalized;
        right = transform.right;
        backRight = (transform.right - transform.forward).normalized;
        back = -transform.forward;
        backLeft = -(transform.forward + transform.right).normalized;
        left = -transform.right;
        forwardLeft = (transform.forward - transform.right).normalized;
    }

    void CheckCollisions_Walls()
    {
        // Wall Raycast direction, player position, and world point
        RaycastDirection colliDir = RaycastDirection.NULL;
        RaycastPosition colPos = RaycastPosition.GROIN;
        Vector3 colPt = Vector3.one * DEFAULT_HIT_DUMMY;

        // Check for a wall hit, calling the corresponding function depending on the collider
        if (wallHits.Length == SMALL_COLLIDER_WALLCHECKS)
        {
            Wallcast(ref colliDir, ref colPt); // Check from center
            if (colliDir != RaycastDirection.NULL && !TestIncline())
            {
                Debug.Log("Collision detected in " + GetCollisionDirection(colliDir) + " direction");
                WallDisplace(colliDir, colPt);
            }
        }
        else
        {
            Wallcast(ref colliDir, ref colPos, ref colPt); // Check from groin, center, and head
            if (colliDir != RaycastDirection.NULL && !TestIncline())
            {
                Debug.Log("Collision Detected at " + GetCollisionPosition(colPos) + ", " + GetCollisionDirection(colliDir) + " direction");
                WallDisplace(colliDir, colPos, colPt);
            }
        }
    }

    bool TestIncline()
    {
        return grounded && (groundAngle > 0 && groundAngle < 90);
    }

    /// <summary>
    /// Wallcast function for player with a small collider.
    /// Cast out from eight major directions, starting with forward and rotating to forward left, from center.
    /// If collision is found, assign references as needed and stop checking.
    /// </summary>
    /// <param name="direction">Enum reference for detected collision direction. </param>
    /// <param name="collisionPoint">Vector3 reference for where collision is detected at in the world.</param>
    void Wallcast(ref RaycastDirection direction, ref Vector3 collisionPoint)
    {
        Vector3 raycastDir;

        // Cast out from the center of the player, rotating clockwise from forward to forward left, to determine if there is a collision.
        for (int dir = (int)RaycastDirection.FORWARD; dir <= (int)RaycastDirection.FORWARD_LEFT; dir++)
        {
            raycastDir = GetRaycastDirection((RaycastDirection)dir);
            // If a collision is detected, assign the direction and collision point in the world.
            if (Raycast(transform.position, raycastDir, RaycastPosition.GROIN, (RaycastDirection)dir))
            {
                direction = (RaycastDirection)dir;
                collisionPoint = wallHits[dir].point;
            }
            // Stop looping through directions if a collision was detected
            if (direction != RaycastDirection.NULL) break;
        }
    }

    /// <summary>
    /// Wallcast function for player with a large collider.
    /// Cast out from eight major directions, starting with forward and rotatinf to forward left, from
    /// groin region up to head.
    /// If collision is found, assign references as needed and stop checking.
    /// </summary>
    /// <param name="direction">Enum reference for detected collision detection.</param>
    /// <param name="position">Enum reference for relative position on player collision was at.</param>
    /// <param name="collisionPoint">Vector3 reference for where collision is detected at in the world.</param>
    void Wallcast(ref RaycastDirection direction, ref RaycastPosition position, ref Vector3 collisionPoint)
    {
        Vector3 raycastPos, raycastDir;

        /* For the three points on the player, starting from the groin up to the head, cast out starting from 
         * forward and rotating around clockwise to forward left to determine if there is a collision. */
        for (int pos = (int)RaycastPosition.GROIN; pos <= (int)RaycastPosition.HEAD; pos++)
        {
            for (int dir = (int)RaycastDirection.FORWARD; dir <= (int)RaycastDirection.FORWARD_LEFT; dir++)
            {
                raycastPos = GetRaycastPosition((RaycastPosition)pos);
                raycastDir = GetRaycastDirection((RaycastDirection)dir);
                // If a collision is detected, assign the relative point, direction, and collision point in the world
                if (Raycast(raycastPos, raycastDir, (RaycastPosition)pos, (RaycastDirection)dir))
                {
                    Debug.Log("Collision Detected");
                    direction = (RaycastDirection)dir;
                    position = (RaycastPosition)pos;
                    collisionPoint = wallHits[8 * pos + dir].point;
                }
                // Stop looping through directions if a collision was detected
                if (direction != RaycastDirection.NULL) break;
            }
            // Stop looping through player positions if a collision was detected
            if (direction != RaycastDirection.NULL) break;
        }
    }

    /// <summary>
    /// Return where on the player to cast out from based on the passed RaycastPosition pos.
    /// </summary>
    /// <param name="pos">Enum representation of the player position to cast from.</param>
    /// <returns>Return the relative player position to cast out from.</returns>
    Vector3 GetRaycastPosition(RaycastPosition pos)
    {
        switch (pos)
        {
            case (RaycastPosition.GROIN):
                if (wallHits.Length == SMALL_COLLIDER_WALLCHECKS)
                    return transform.position;
                else
                    return transform.position - (Vector3.up * (height - width));
            case (RaycastPosition.CORE):
                return transform.position;
            case (RaycastPosition.HEAD):
                return transform.position + (Vector3.up * (height - width));
        }
        return Vector3.zero;
    }

    /// <summary>
    /// Return which direction to cast out from based on the passed RaycastDirection dir.
    /// </summary>
    /// <param name="dir">Enum representation of the directional vector to cast from.</param>
    /// <returns>Return the direction to cast out from.</returns>
    Vector3 GetRaycastDirection(RaycastDirection dir)
    {
        switch (dir)
        {
            case (RaycastDirection.FORWARD):
                return forward;
            case (RaycastDirection.FORWARD_RIGHT):
                return forwardRight;
            case (RaycastDirection.RIGHT):
                return right;
            case (RaycastDirection.BACK_RIGHT):
                return backRight;
            case (RaycastDirection.BACK):
                return back;
            case (RaycastDirection.BACK_LEFT):
                return backLeft;
            case (RaycastDirection.LEFT):
                return left;
            case (RaycastDirection.FORWARD_LEFT):
                return forwardLeft;
        }
        return Vector3.zero;
    }

    /// <summary>
    /// Return if a raycast hit is occuring at raycastPos in raycastDir and assign to wallHits
    /// based on position and direction enum values.
    /// </summary>
    /// <param name="raycastPos">position raycast is being cast from; either head, core, or groin area on player.</param>
    /// <param name="raycastDir">Direction from raycastPos to cast from; based on one of eight core directions.</param>
    /// <param name="position">Enum representing where from player to raycast from; used for assigning to wallHits</param>
    /// <param name="direction">Enum representing which direction to raycast out; used for assigning to wallHits</param>
    /// <returns>true if a raycast hit occurs, false if not.</returns>
    bool Raycast(Vector3 raycastPos, Vector3 raycastDir, RaycastPosition position, RaycastDirection direction)
    {
        return Physics.Raycast(raycastPos, raycastDir, out wallHits[8 * (int)position + (int)direction], width + collisionPadding, groundLayer);
    }    

    void WallDisplace(RaycastDirection dir, Vector3 collisionPt)
    {
        Vector3 displaceDir = DisplaceDirection(dir);
    }

    void WallDisplace(RaycastDirection dir, RaycastPosition pos, Vector3 collisionPt)
    {
        Vector3 displaceDir = DisplaceDirection(dir).normalized * width;
        float posDisplace = DisplacePosition(pos);
        transform.position = (collisionPt - (Vector3.up * posDisplace)) - displaceDir;
    }

    Vector3 DisplaceDirection(RaycastDirection dir)
    {

        switch(dir)
        {
            case (RaycastDirection.FORWARD):
                return forward;
            case (RaycastDirection.FORWARD_RIGHT):
                return forwardRight;
            case (RaycastDirection.RIGHT):
                return right;
            case (RaycastDirection.BACK_RIGHT):
                return backRight;
            case (RaycastDirection.BACK):
                return back;
            case (RaycastDirection.BACK_LEFT):
                return backLeft;
            case (RaycastDirection.LEFT):
                return left;
            case (RaycastDirection.FORWARD_LEFT):
                return forwardLeft;
            default:
                return Vector3.zero;
        }
    }

    float DisplacePosition(RaycastPosition pos)
    {
        switch(pos)
        {
            case (RaycastPosition.GROIN):
                return -(height - width);
            case (RaycastPosition.HEAD):
                return height - width;
            default:
                return 0;
        }
    }

    #endregion

    #region Ceiling

    /// <summary>
    /// Check directly above the player for if there is a collision.
    /// Reposition player to keep from clipping into ceiling.
    /// </summary>
    void CheckCollision_Ceiling()
    {
        if(Physics.Raycast(transform.position, Vector3.up, out headHit, height + collisionPadding))
        {
            if (Vector3.Distance(transform.position, headHit.point) < height)
                transform.position = headHit.point - Vector3.up * height;
            hitCeiling = true;
        }
        else
        {
            hitCeiling = false;
        }
    }

    #endregion

    #region Debug
    string GetCollisionPosition(RaycastPosition pos)
    {
        switch(pos)
        {
            case (RaycastPosition.GROIN):
                return "Groin";
            case (RaycastPosition.CORE):
                return "Core";
            case (RaycastPosition.HEAD):
                return "Head";
            default:
                return "Error?";
        }
    }

    string GetCollisionDirection(RaycastDirection dir)
    {
        switch(dir)
        {
            case (RaycastDirection.FORWARD):
                return "Forward";
            case (RaycastDirection.FORWARD_RIGHT):
                return "Forward-Right";
            case (RaycastDirection.RIGHT):
                return "Right";
            case (RaycastDirection.BACK_RIGHT):
                return "Back-Right";
            case (RaycastDirection.BACK):
                return "Back";
            case (RaycastDirection.BACK_LEFT):
                return "Back-Left";
            case (RaycastDirection.LEFT):
                return "Left";
            case (RaycastDirection.FORWARD_LEFT):
                return "Forward-Left";
            default:
                return "Error?";
        }
    }

    void DrawDebug_CollisionChecking()
    {
        float collisionDistance = width + collisionPadding;

        //Vector3 forward = transform.forward,
        //        forwardRight = (transform.forward + transform.right).normalized,
        //        right = transform.right,
        //        backRight = (transform.right - transform.forward).normalized,
        //        back = -transform.forward,
        //        backLeft = (-transform.right - transform.forward).normalized,
        //        left = -transform.right,
        //        forwardLeft = (transform.forward - transform.right).normalized;
                

        Vector3 center = transform.position,
                head = transform.position + (Vector3.up * (height - width)),
                groin = transform.position - (Vector3.up * (height - width));

        // Ground collision
        DrawLine_Floor_Ceiling(center, -Vector3.up);

        // Head Collision
        DrawLine_Floor_Ceiling(center, Vector3.up);

        // Wall Collisions
        // Center
        DrawLine_Wall(center, forward);
        DrawLine_Wall(center, forwardRight);
        DrawLine_Wall(center, right);
        DrawLine_Wall(center, backRight);
        DrawLine_Wall(center, back);
        DrawLine_Wall(center, backLeft);
        DrawLine_Wall(center, left);
        DrawLine_Wall(center, forwardLeft);

        if(wallHits.Length > SMALL_COLLIDER_WALLCHECKS)
        {
            // Head
            DrawLine_Wall(head, forward);
            DrawLine_Wall(head, forwardRight);
            DrawLine_Wall(head, right);
            DrawLine_Wall(head, backRight);
            DrawLine_Wall(head, back);
            DrawLine_Wall(head, backLeft);
            DrawLine_Wall(head, left);
            DrawLine_Wall(head, forwardLeft);

            // Groin
            DrawLine_Wall(groin, forward);
            DrawLine_Wall(groin, forwardRight);
            DrawLine_Wall(groin, right);
            DrawLine_Wall(groin, backRight);
            DrawLine_Wall(groin, back);
            DrawLine_Wall(groin, backLeft);
            DrawLine_Wall(groin, left);
            DrawLine_Wall(groin, forwardLeft);
        }
    }

    void DrawLine_Wall(Vector3 center, Vector3 direction)
    {
        Debug.DrawLine(center, center + direction * width, Color.blue);
        Debug.DrawLine(center + direction * width, center + direction * width + direction * collisionPadding, Color.green);
    }

    void DrawLine_Floor_Ceiling(Vector3 center, Vector3 direction)
    {
        Debug.DrawLine(center, center + direction * height, Color.blue);
        Debug.DrawLine(center + direction * height, center + direction * height + direction * collisionPadding, Color.green);
    }



    #endregion

    #endregion
}
