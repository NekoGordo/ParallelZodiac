using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(PlayerBehaviour))]
[RequireComponent(typeof(CameraBehaviour))]
[RequireComponent(typeof(PlayerCollisionDetection))]
[CustomEditor(typeof(ThirdPersonController))]
public class ThirdPersonEditor : Editor
{
    const float ABS_MIN_PLAYER_SPEED = 1.0f;
    const float ABS_MIN_JUMP = 0.0f;
    const float ABS_MIN_SPRINT = 1.1f;
    const float ABS_MIN_SNEAK = 0.1f;
    const float ABS_MIN_CLIMB_ANGLE = 55.0f;

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
    PlayerCollisionDetection colScript;
    GameObject camera;

    bool showPlayerInfo, lockPlayerConstraints = true, showPlayerConstraints, showCameraInfo, lockCamConstraints = true, showCamConstraints;
    int labelWidth, subWidth, constraintWidth;

    private void Awake()
    {
        self = (ThirdPersonController)target;
        playerScript = self.GetComponent<PlayerBehaviour>();
        camScript = self.GetComponent<CameraBehaviour>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        if (camScript.playerCam == null) camScript.playerCam = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        if (camScript.camAnchor == null) camScript.camAnchor = GameObject.Find("Camera Anchor").gameObject;
    }

    public override void OnInspectorGUI()
    {
        GUIStyle mainFont = new GUIStyle();
        GUIStyle subFont = new GUIStyle();

        mainFont.fontSize = 14;
        mainFont.fontStyle = FontStyle.Bold;
        subFont.fontStyle = FontStyle.Bold;

        camScript.EditorCameraUpdate();
        //Editor_CameraUpdate();

        EditorGUILayout.BeginVertical();
        ShowPlayerOptions();
        ShowCameraOptions();
        EditorGUILayout.EndVertical();
    }

    void ShowPlayerOptions()
    {
        EditorGUILayout.BeginHorizontal();
        showPlayerInfo = EditorGUILayout.Foldout(showPlayerInfo, "Player Info", true);
        EditorGUILayout.EndHorizontal();
        if (showPlayerInfo)
        {
            EditorGUI.indentLevel++;


            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Move Speed", GUILayout.Width(LABEL_WIDTH));
            playerScript.moveSpd = ShowOptionSlider("Slow", "Fast", 60, playerScript.moveSpd, ref playerScript.MIN_CHR_SPD, ref playerScript.MAX_CHR_SPD);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Sprint factor", GUILayout.Width(LABEL_WIDTH));
            playerScript.sprintFactor = ShowOptionSlider("Quick", "Speedy", 60, playerScript.sprintFactor, ref playerScript.MIN_SPRINT, ref playerScript.MAX_SPRINT);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Sneak Factor", GUILayout.Width(LABEL_WIDTH));
            playerScript.sneakFactor = ShowOptionSlider("Sneaky", "Slow", 60, playerScript.sneakFactor, ref playerScript.MIN_SNEAK, ref playerScript.MAX_SNEAK);
            EditorGUILayout.EndHorizontal();

            //EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField("Jump Height", GUILayout.Width(LABEL_WIDTH));
            //playerScript.jumpTime = ShowOptionSlider("Low", "High", 60, playerScript.jumpTime, ref playerScript.MIN_JUMP_TIME, ref playerScript.MAX_JUMP_TIME);
            //EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Climb Angle", GUILayout.Width(LABEL_WIDTH));
            playerScript.climbAngle = ShowOptionSlider("Low", "High", 60, playerScript.climbAngle, ref playerScript.MIN_CLIMB_ANGLE, ref playerScript.MAX_CLIMB_ANGLE);
            EditorGUILayout.EndHorizontal();



            showPlayerConstraints = EditorGUILayout.Foldout(showPlayerConstraints, "Player Constraints", true);
            if (showPlayerConstraints)
            {
                EditorGUI.indentLevel++;


                lockPlayerConstraints = EditorGUILayout.Toggle("Lock Constraints", lockPlayerConstraints);
                EditorGUILayout.LabelField("Movement speed");
                if (lockPlayerConstraints) ShowMinMax(ref playerScript.MIN_CHR_SPD, ref playerScript.MAX_CHR_SPD); else ChangeMinMax(ref playerScript.MIN_CHR_SPD, ref playerScript.MAX_CHR_SPD);
                EditorGUILayout.LabelField("Jump Height");
                if (lockPlayerConstraints) ShowMinMax(ref playerScript.MIN_JUMP_VAL, ref playerScript.MAX_JUMP_VAL); else ChangeMinMax(ref playerScript.MIN_JUMP_VAL, ref playerScript.MAX_JUMP_VAL);
                EditorGUILayout.LabelField("Sprint Factor");
                if (lockPlayerConstraints) ShowMinMax(ref playerScript.MIN_SPRINT, ref playerScript.MAX_SPRINT); else ChangeMinMax(ref playerScript.MIN_SPRINT, ref playerScript.MAX_SPRINT);
                EditorGUILayout.LabelField("Sneak Factor");
                if (lockPlayerConstraints) ShowMinMax(ref playerScript.MIN_SNEAK, ref playerScript.MAX_SNEAK); else ChangeMinMax(ref playerScript.MIN_SNEAK, ref playerScript.MAX_SNEAK);
                EditorGUILayout.LabelField("Climb Angle");
                if (lockPlayerConstraints) ShowMinMax(ref playerScript.MIN_CLIMB_ANGLE, ref playerScript.MAX_CLIMB_ANGLE); else ChangeMinMax(ref playerScript.MIN_CLIMB_ANGLE, ref playerScript.MAX_CLIMB_ANGLE);

                CheckPlayerMinContraints();

                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;
        }
        EditorUtility.SetDirty(playerScript);
    }

    void ShowCameraOptions()
    {
        showCameraInfo = EditorGUILayout.Foldout(showCameraInfo, "Camera Info");
        if (showCameraInfo)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Zoom Speed", GUILayout.Width(LABEL_WIDTH));
            camScript.zoomSpd = ShowOptionSlider("Slow", "Fast", 60, camScript.zoomSpd, ref camScript.MIN_ZOOM_SPD, ref camScript.MAX_ZOOM_SPD);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Rotate Speed", GUILayout.Width(LABEL_WIDTH));
            camScript.camRotSpd = ShowOptionSlider("Slow", "Fast", 60, camScript.camRotSpd, ref camScript.MIN_ROT_SPD, ref camScript.MAX_ROT_SPD);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Camera Anchor", GUILayout.Width(LABEL_WIDTH));
            camScript.camAnchor.transform.localPosition = PointEditor("X", "Y", "Z", camScript.camAnchor.transform.localPosition, false);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Spherical Position", GUILayout.Width(LABEL_WIDTH));
            camScript.sphericalPos = PointEditor("R", "T", "P", camScript.sphericalPos, true);
            EditorGUILayout.EndHorizontal();



            showCamConstraints = EditorGUILayout.Foldout(showCamConstraints, "Camera Constraints", true);
            if (showCamConstraints)
            {
                EditorGUI.indentLevel++;

                lockCamConstraints = EditorGUILayout.Toggle("Lock Constraints", lockCamConstraints);
                EditorGUILayout.LabelField("Camera Distance");
                if (lockCamConstraints) ShowMinMax(ref camScript.MIN_CAM_DIST, ref camScript.MAX_CAM_DIST); else ChangeMinMax(ref camScript.MIN_CAM_DIST, ref camScript.MAX_CAM_DIST);

                EditorGUILayout.LabelField("Zoom Speed");
                if (lockCamConstraints) ShowMinMax(ref camScript.MIN_ZOOM_SPD, ref camScript.MAX_ZOOM_SPD); else ChangeMinMax(ref camScript.MIN_ZOOM_SPD, ref camScript.MAX_ZOOM_SPD);

                EditorGUILayout.LabelField("Rotate Speed");
                if (lockCamConstraints) ShowMinMax(ref camScript.MIN_ROT_SPD, ref camScript.MAX_ROT_SPD); else ChangeMinMax(ref camScript.MIN_ROT_SPD, ref camScript.MAX_ROT_SPD);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Maximum horizon angle", GUILayout.Width(200));
                if (lockCamConstraints) EditorGUILayout.LabelField(camScript.MAX_VERTICAL_ANGLE.ToString(), GUILayout.Width(CONSTRAIN_FIELD));
                else camScript.MAX_VERTICAL_ANGLE = EditorGUILayout.FloatField(GUIContent.none, camScript.MAX_VERTICAL_ANGLE, GUILayout.Width(CONSTRAIN_FIELD));
                EditorGUILayout.EndHorizontal();

                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;
        }
        EditorUtility.SetDirty(camScript);
    }

    float ShowOptionSlider(string left, string right, float labelWidth, float modValue, ref float min, ref float max)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(left, GUILayout.Width(labelWidth));
        modValue = GUILayout.HorizontalSlider(modValue, min, max, GUILayout.Width(128));
        EditorGUILayout.LabelField(right, GUILayout.Width(labelWidth));
        modValue = EditorGUILayout.FloatField(GUIContent.none, modValue, GUILayout.Width(CONSTRAIN_FIELD));
        EditorGUILayout.EndHorizontal();

        return modValue;
    }

    Vector3 PointEditor(string xLabel, string yLabel, string zLabel, Vector3 point, bool isSpherePos)
    {
        Vector3 dynamicPoint = point;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(xLabel, GUILayout.Width(32));
        dynamicPoint.x = EditorGUILayout.FloatField(GUIContent.none, dynamicPoint.x, GUILayout.Width(128));

        if (!isSpherePos) // Not a spherical position point; display normally
        {
            EditorGUILayout.LabelField(yLabel, GUILayout.Width(32));
            dynamicPoint.y = EditorGUILayout.FloatField(GUIContent.none, dynamicPoint.y, GUILayout.Width(128));
            EditorGUILayout.LabelField(zLabel, GUILayout.Width(32));
            dynamicPoint.z = EditorGUILayout.FloatField(GUIContent.none, dynamicPoint.z, GUILayout.Width(128));
        }
        else // Spherical position point; flip y and z
        {
            float editorP = dynamicPoint.y - 90;

            EditorGUILayout.LabelField(yLabel, GUILayout.Width(32));
            dynamicPoint.z = EditorGUILayout.FloatField(GUIContent.none, dynamicPoint.z, GUILayout.Width(128));
            if (dynamicPoint.z < 0) dynamicPoint.z += 360; else if (dynamicPoint.z > 360) dynamicPoint.z -= 360;
            EditorGUILayout.LabelField(zLabel, GUILayout.Width(32));
            editorP = EditorGUILayout.FloatField(GUIContent.none, editorP, GUILayout.Width(128));
            if (editorP < -camScript.MAX_VERTICAL_ANGLE) editorP = -camScript.MAX_VERTICAL_ANGLE; else if (editorP > camScript.MAX_VERTICAL_ANGLE) editorP = camScript.MAX_VERTICAL_ANGLE;

            dynamicPoint.y = editorP + 90;
        }

        EditorGUILayout.EndHorizontal();

        return dynamicPoint;
    }

    void Editor_CameraUpdate()
    {
        camera.transform.position = camScript.camAnchor.transform.position + Editor_ConvertSphericalToCartesian();
        camera.transform.LookAt(camScript.camAnchor.transform);
    }

    Vector3 Editor_ConvertSphericalToCartesian()
    {
        float x = camScript.sphericalPos.x * Mathf.Sin(camScript.sphericalPos.y * Mathf.Deg2Rad) * Mathf.Sin(camScript.sphericalPos.z * Mathf.Deg2Rad);
        float y = camScript.sphericalPos.x * Mathf.Cos(camScript.sphericalPos.y * Mathf.Deg2Rad);
        float z = camScript.sphericalPos.x * Mathf.Sin(camScript.sphericalPos.y * Mathf.Deg2Rad) * Mathf.Cos(camScript.sphericalPos.z * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }

    void ShowMinMax(ref float min, ref float max)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Min", GUILayout.Width(CONSTRAIN_WIDTH));
        EditorGUILayout.LabelField(min.ToString(), GUILayout.Width(CONSTRAIN_FIELD));
        EditorGUILayout.LabelField("Max", GUILayout.Width(CONSTRAIN_WIDTH));
        EditorGUILayout.LabelField(max.ToString(), GUILayout.Width(CONSTRAIN_FIELD));
        EditorGUILayout.EndHorizontal();
    }

    void ChangeMinMax(ref float min, ref float max)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Min", GUILayout.Width(CONSTRAIN_WIDTH));
        min = EditorGUILayout.FloatField(GUIContent.none, min, GUILayout.Width(CONSTRAIN_FIELD));
        EditorGUILayout.LabelField("Max", GUILayout.Width(CONSTRAIN_WIDTH));
        max = EditorGUILayout.FloatField(GUIContent.none, max, GUILayout.Width(CONSTRAIN_FIELD));
        EditorGUILayout.EndHorizontal();
    }


    void CheckPlayerMinContraints()
    {
        if (playerScript.MIN_CHR_SPD < ABS_MIN_PLAYER_SPEED) playerScript.MIN_CHR_SPD = ABS_MIN_PLAYER_SPEED;
        if (playerScript.MIN_JUMP_VAL < ABS_MIN_JUMP) playerScript.MIN_JUMP_VAL = ABS_MIN_JUMP;
        if (playerScript.MIN_SPRINT < ABS_MIN_SPRINT) playerScript.MIN_SPRINT = ABS_MIN_SPRINT;
        if (playerScript.MIN_SNEAK < ABS_MIN_SNEAK) playerScript.MIN_SNEAK = ABS_MIN_SNEAK;
        if (playerScript.MIN_CLIMB_ANGLE < ABS_MIN_CLIMB_ANGLE) playerScript.MIN_CLIMB_ANGLE = ABS_MIN_CLIMB_ANGLE;
    }
}
