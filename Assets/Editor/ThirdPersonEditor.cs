using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ThirdPersonController))]
public class ThirdPersonEditor : Editor
{
    const float ABS_MIN_PLAYER_SPEED = 1.0f;
    const float ABS_MIN_SPRINT = 1.1f;
    const float ABS_MIN_CLIMB_ANGLE = 60.0f;
    const float ABS_MIN_CAM_RADIUS = 2.5f;
    const float ABS_MIN_ZOOM_SPD = 1.0f;
    const float ABS_MIN_ROT_SPD = 1.0f;
    const float ABS_MIN_CAM_ANGLE = 15.0f;

    const int LABEL_WIDTH = 120;
    const int SUB_WIDTH = 72;
    const int CONSTRAIN_WIDTH = 56;
    const int CONSTRAIN_FIELD = 80;

    ThirdPersonController self;
    PlayerBehaviour playerScript;
    CameraBehaviour camScript;    

    bool showPlayerInfo, showPlayerConstraints, showCameraInfo, showCamConstraints;
    int labelWidth, subWidth, constraintWidth;

    private void Awake()
    {
        self = (ThirdPersonController)target;
        playerScript = self.GetComponent<PlayerBehaviour>();
        camScript = self.GetComponent<CameraBehaviour>();
    }

    public override void OnInspectorGUI()
    {
        GUIStyle mainFont = new GUIStyle();
        GUIStyle subFont = new GUIStyle();

        mainFont.fontSize = 14;
        mainFont.fontStyle = FontStyle.Bold;
        subFont.fontStyle = FontStyle.Bold;

        

        //base.OnInspectorGUI();
        EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
                //EditorGUILayout.LabelField("Player Info", mainFont, GUILayout.Width(labelWidth));
                showPlayerInfo = EditorGUILayout.Foldout(showPlayerInfo, "Player Info", true);
            EditorGUILayout.EndHorizontal();
            if(showPlayerInfo)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Move Speed", GUILayout.Width(LABEL_WIDTH));
                    playerScript.moveSpd = ShowOptionSlider("Slow", "Fast", 60, playerScript.moveSpd, ref playerScript.MIN_CHR_MOVESPD, ref playerScript.MAX_CHR_MOVESPD);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Sprint factor", GUILayout.Width(LABEL_WIDTH));
                    playerScript.sprintFactor = ShowOptionSlider("Quick", "Speedy", 60, playerScript.sprintFactor, ref playerScript.MIN_SPRINT_FACTOR, ref playerScript.MAX_SPRINT_FACTOR);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Sneak Factor", GUILayout.Width(LABEL_WIDTH));
                    playerScript.sneakFactor = ShowOptionSlider("Sneaky", "Slow", 60, playerScript.sneakFactor, ref playerScript.MIN_SNEAK_FACTOR, ref playerScript.MAX_SNEAK_FACTOR);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Jump Height", GUILayout.Width(LABEL_WIDTH));
                    playerScript.jumpHeight = ShowOptionSlider("Low", "High", 60, playerScript.jumpHeight, ref playerScript.MIN_JUMP, ref playerScript.MAX_JUMP);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Climb Angle", GUILayout.Width(LABEL_WIDTH));
                    playerScript.climbAngle = ShowOptionSlider("Low", "High", 60, playerScript.climbAngle, ref playerScript.MIN_CLIMB_ANGLE, ref playerScript.MAX_CLIMB_ANGLE);
                EditorGUILayout.EndHorizontal();

                showPlayerConstraints = EditorGUILayout.Foldout(showPlayerConstraints, "Player Constraints", true);
                if(showPlayerConstraints)
                {
                    EditorGUI.indentLevel++;

                        EditorGUILayout.LabelField("Movement speed");
                        ShowMinMax(ref playerScript.MIN_CHR_MOVESPD, ref playerScript.MAX_CHR_MOVESPD);
                        EditorGUILayout.LabelField("Jump Height");
                        ShowMinMax(ref playerScript.MIN_JUMP, ref playerScript.MAX_JUMP);
                        EditorGUILayout.LabelField("Sprint Factor");
                        ShowMinMax(ref playerScript.MIN_SPRINT_FACTOR, ref playerScript.MAX_SPRINT_FACTOR);
                        EditorGUILayout.LabelField("Sneak Factor");
                        ShowMinMax(ref playerScript.MIN_SNEAK_FACTOR, ref playerScript.MAX_SNEAK_FACTOR);
                        EditorGUILayout.LabelField("Climb Angle");
                        ShowMinMax(ref playerScript.MIN_CLIMB_ANGLE, ref playerScript.MAX_CLIMB_ANGLE);

                    EditorGUI.indentLevel--;
                }

            EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space();

            showCameraInfo = EditorGUILayout.Foldout(showCameraInfo, "Camera Info");
            if(showCameraInfo)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Zoom Speed", GUILayout.Width(LABEL_WIDTH));
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Rotate Speed", GUILayout.Width(LABEL_WIDTH));
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Spherical Position", GUILayout.Width(LABEL_WIDTH));
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Camera Anchor", GUILayout.Width(LABEL_WIDTH));
                EditorGUILayout.EndHorizontal();
    
                showCamConstraints = EditorGUILayout.Foldout(showCamConstraints, "Camera Constraints", true);
                if(showCamConstraints)
                {
                    EditorGUI.indentLevel++;
                        EditorGUILayout.LabelField("Camera Distance");
                        //ShowMinMax();

                        EditorGUILayout.LabelField("Zoom Speed");
                        //ShowMinMax();

                        EditorGUILayout.LabelField("Rotate Speed");
                        //ShowMinMax();

                        EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Maximum horizon angle", GUILayout.Width(200));
                            EditorGUILayout.FloatField(999.99f, GUILayout.Width(CONSTRAIN_FIELD));
                        EditorGUILayout.EndHorizontal();

                    EditorGUI.indentLevel--;
                }

            EditorGUI.indentLevel--;
            }
        EditorGUILayout.EndVertical();
    }

    float ShowOptionSlider(string left, string right, float labelWidth, float modValue, ref float min, ref float max)
    {
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(left, GUILayout.Width(labelWidth));
            modValue = GUILayout.HorizontalSlider(modValue, min, max, GUILayout.Width(128));
            EditorGUILayout.LabelField(right, GUILayout.Width(labelWidth));
            modValue = EditorGUILayout.FloatField(modValue, GUILayout.Width(CONSTRAIN_FIELD));            
        EditorGUILayout.EndHorizontal();

        return modValue;
    }

    void ShowMinMax(ref float min, ref float max)


    {
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Min", GUILayout.Width(CONSTRAIN_WIDTH));
            min = EditorGUILayout.FloatField(min , GUILayout.Width(CONSTRAIN_FIELD));
            EditorGUILayout.LabelField("Max", GUILayout.Width(CONSTRAIN_WIDTH));
            max = EditorGUILayout.FloatField(max, GUILayout.Width(CONSTRAIN_FIELD));
        EditorGUILayout.EndHorizontal();
    }
}