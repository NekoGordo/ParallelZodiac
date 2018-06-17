using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : BaseMenu {
    //ToDo --> Time Lock and Screen Lock
    bool isPaused = false;

    public PauseMenu()
    {
        XPosition = 10;
        YPosition = 10;
        MenuName = "Pause Menu";
    }

    void Awake()
    {
        //Parameter Initialization//
        Resolution[] res = Screen.resolutions;
        Width = XPosition - res[0].width;
        Height = YPosition - res[0].height;

        //Button Dimensions Adjustor for Resolution
        float WidthAdjust = 0f;
    }

    void Update() {
        //Check for Escape Button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Check for Pause
            if (isPaused == false)
            {
                isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                isPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    //Menu Instance//
    void OnGUI () {
        if (isPaused == true)
        {
            //A Box
            GUI.Box(new Rect(XPosition, YPosition, Width, Height), MenuName);

            //Buttons
            if (GUI.Button(new Rect(20, 40, 80, 20), "Abilities")) { }
            if (GUI.Button(new Rect(20, 80, 80, 20), "Items")) { }
            if (GUI.Button(new Rect(20, 120, 80, 20), "Status")) { }
            if (GUI.Button(new Rect(20, 160, 80, 20), "Formation")) { }
            if (GUI.Button(new Rect(20, 200, 80, 20), "Inventory")) { }
            if (GUI.Button(new Rect(20, 240, 80, 20), "Equipment")) { }
            if (GUI.Button(new Rect(20, 280, 80, 20), "Story")) { }
            if (GUI.Button(new Rect(20, 320, 80, 20), "Library")) { }
            if (GUI.Button(new Rect(20, 360, 80, 20), "Profile")) { }
            if (GUI.Button(new Rect(20, 400, 80, 20), "Option")) { }
            if (GUI.Button(new Rect(20, 440, 80, 20), "Save / Load")) { }
        }
    }
}