using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ThirdPersonController))]
public class ThirdPersonEditor : Editor
{
    const float ABS_MIN_MOVESPD = 0.5f,
                ABS_MIN_CAM_DIST = 2.5f;

    float MIN_CHR_MOVE_SPD = 1,
          MAX_CHR_MOVE_SPD = 5,
          MIN_CAM_MOVE_SPD = 1,
          MAX_CAM_MOVE_SPD = 5,
          MIN_CAM_DIST = 2.5f,
          MAX_CAM_DIST = 10;

    bool useSoftTether;


    ThirdPersonController self;


    private void Awake()
    {
        self = (ThirdPersonController)target;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        GUIStyle boldFont = new GUIStyle();
        boldFont.fontSize = 12;
        boldFont.fontStyle = FontStyle.Bold;

        EditorGUILayout.LabelField("Player Move Speed", boldFont);
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Slow", GUILayout.Width(48));
            self.moveSpd = GUILayout.HorizontalSlider(self.moveSpd, MIN_CHR_MOVE_SPD, MAX_CHR_MOVE_SPD, GUILayout.Width(108));
            EditorGUILayout.LabelField("Fast", GUILayout.Width(36));
            self.moveSpd = EditorGUILayout.FloatField(self.moveSpd, GUILayout.Width(32));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Camera Move Speed", boldFont);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Slow", GUILayout.Width(48));
            self.camSpd = GUILayout.HorizontalSlider(self.camSpd, MIN_CAM_MOVE_SPD, MAX_CAM_MOVE_SPD, GUILayout.Width(108));
            EditorGUILayout.LabelField("Fast", GUILayout.Width(36));
            self.camSpd = EditorGUILayout.FloatField(self.camSpd, GUILayout.Width(32));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Camera/Player Start Distance", boldFont);
        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Near", GUILayout.Width(48));
            self.startCamDistance = GUILayout.HorizontalSlider(self.startCamDistance, MIN_CAM_DIST, MAX_CAM_DIST, GUILayout.Width(108));
            EditorGUILayout.LabelField("Far", GUILayout.Width(36));
            self.startCamDistance = EditorGUILayout.FloatField(self.startCamDistance, GUILayout.Width(32));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Soft-Tether Camera");
            self.softTether = EditorGUILayout.Toggle(self.softTether);
        EditorGUILayout.EndHorizontal();


    }
}
