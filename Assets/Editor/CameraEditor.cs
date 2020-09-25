using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraBehaviour))]
public class CameraEditor : Editor
{
    bool showCamObjects = false;

    const float ABS_MIN_CAM_RADIUS = 2.5f;
    const float ABS_MIN_ZOOM_SPD = 1.0f;
    const float ABS_MIN_ROT_SPD = 1.0f;
    const float ABS_MIN_CAM_ANGLE = 15.0f;

    CameraBehaviour self;
    GameObject playerCam, camAnchor;

    private void Awake()
    {
        self = (CameraBehaviour)target;
        playerCam = GameObject.Find("Main Camera");
        camAnchor = GameObject.Find("Camera Anchor");

        self.playerCam = playerCam;
        self.camAnchor = camAnchor;
    }

    public override void OnInspectorGUI()
    {
        if(!EditorGlobals.HideEditors)
        {

            if (showCamObjects = EditorGlobals.ShowToggle("Show Camera Objects", showCamObjects))
            {
                playerCam = EditorGlobals.ShowObjectField("Player Camera", 128, playerCam);
                camAnchor = EditorGlobals.ShowObjectField("Camera Anchor", 128, camAnchor);
            }

            Vector3 anchorLocalPos = camAnchor.transform.localPosition;
            anchorLocalPos = EditorGlobals.ShowVector3Field("Anchor Pos", "X", "Y", "Z", ref anchorLocalPos);
            camAnchor.transform.localPosition = anchorLocalPos;
            self.sphericalPos = ShowSphericalPoint("Spherical Pos", "R", "T", "P", self.sphericalPos);
            self.zoomSpd = EditorGlobals.ShowOptionSlider("Zoom Speed", "Slow", "Fast", 60, self.zoomSpd, ref self.MIN_ZOOM_SPD, ref self.MAX_ZOOM_SPD);
            self.camRotSpd = EditorGlobals.ShowOptionSlider("Rotation Speed", "Slow", "Fast", 60, self.camRotSpd, ref self.MIN_ROT_SPD, ref self.MAX_ROT_SPD);
            self.maxHorizonAngle = EditorGlobals.ShowOptionSlider("Max Horizon Angle", "Small", "Large", 60, self.maxHorizonAngle, ref self.MIN_VERTICAL_ANGLE, ref self.MAX_VERTICAL_ANGLE);


            EditorUtility.SetDirty(self);
        }
        else
            base.OnInspectorGUI();
    }

    Vector3 ShowSphericalPoint(string label, string R, string T, string P, Vector3 point)
    {
        Vector3 dynamicPoint = point;
        float editorP = dynamicPoint.y - 90;

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(EditorGlobals.LABEL_WIDTH));
            EditorGUILayout.LabelField(R, GUILayout.Width(16));
            dynamicPoint.x = EditorGUILayout.FloatField(GUIContent.none, dynamicPoint.x, GUILayout.Width(64));
            EditorGUILayout.LabelField(T, GUILayout.Width(16));
            dynamicPoint.z = EditorGUILayout.FloatField(GUIContent.none, dynamicPoint.z, GUILayout.Width(64));
            if (dynamicPoint.z < 0) dynamicPoint.z += 360; else if (dynamicPoint.z > 360) dynamicPoint.z -= 360;
            EditorGUILayout.LabelField(P, GUILayout.Width(16));
            editorP = EditorGUILayout.FloatField(GUIContent.none, editorP, GUILayout.Width(64));
            if (editorP < -self.MAX_VERTICAL_ANGLE) editorP = -self.MAX_VERTICAL_ANGLE; else if (editorP > self.MAX_VERTICAL_ANGLE) editorP = self.MAX_VERTICAL_ANGLE;
            dynamicPoint.y = editorP + 90;
        EditorGUILayout.EndHorizontal();

        return dynamicPoint;

    }
}
