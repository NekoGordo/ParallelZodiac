using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
[RequireComponent(typeof(CameraBehaviour))]
[RequireComponent(typeof(PlayerCollisionDetection))]
public class ThirdPersonController : MonoBehaviour
{
    PlayerBehaviour playerScript;
    CameraBehaviour camScript;
    PlayerCollisionDetection colScript;

    private void Start()
    {
        playerScript = GetComponent<PlayerBehaviour>();
        camScript = GetComponent<CameraBehaviour>();
        colScript = GetComponent<PlayerCollisionDetection>();
    }

    private void OnGUI()
    {
        GUI.color = Color.black;
        GUILayout.Label("Ground angle: " + colScript.groundAngle);
    }
}
