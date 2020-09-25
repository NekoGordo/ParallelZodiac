using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerBehaviour))]
public class PlayerEditor : Editor
{
    const float ABS_MIN_PLAYER_SPEED = 1.0f;
    const float ABS_MIN_JUMP = 0.0f;
    const float ABS_MIN_SPRINT = 1.1f;
    const float ABS_MIN_SNEAK = 0.1f;
    const float ABS_MIN_CLIMB_ANGLE = 55.0f;    

    PlayerBehaviour self;
    bool showConstraints = false;

    private void Awake()
    {
        self = (PlayerBehaviour)target;
    }

    public override void OnInspectorGUI()
    {

        if (!EditorGlobals.HideEditors)
        {
            self.moveSpd = EditorGlobals.ShowOptionSlider("Move Speed", "Slow", "Fast", 60, self.moveSpd, ref self.MIN_CHR_SPD, ref self.MAX_CHR_SPD);
            self.sprintFactor = EditorGlobals.ShowOptionSlider("Sprint", "Fast", "Quick", 60, self.sprintFactor, ref self.MIN_SPRINT, ref self.MAX_SPRINT);
            self.sneakFactor = EditorGlobals.ShowOptionSlider("Sneak", "Sneaky", "Slow", 60, self.sneakFactor, ref self.MIN_SNEAK, ref self.MAX_SNEAK);
            //if(self.canClimb) self.climbAngle = EditorGlobals.ShowOptionSlider("Climb Angle", "Low", "High", 60, self.climbAngle, ref self.MIN_CLIMB_ANGLE, ref self.MAX_CLIMB_ANGLE);
            //else self.climbAngle = EditorGlobals.ShowOptionSlider("Slide Angle", "Low", "High", 60, self.climbAngle, ref self.MIN_CLIMB_ANGLE, ref self.MAX_CLIMB_ANGLE);
            
            if (self.canJump = EditorGlobals.ShowToggle("Can Jump?", self.canJump))
            {
               self.jump = EditorGlobals.ShowOptionSlider("Jump", "Small", "Large", 60, self.jump, ref self.MIN_JUMP_VAL, ref self.MAX_JUMP_VAL);
               self.airDelay = EditorGlobals.ShowOptionSlider("Fall Delay", "Small", "Large", 60, self.airDelay, ref self.MIN_JUMP_VAL, ref self.MAX_JUMP_VAL);
            }
            else
                EditorGUILayout.LabelField("\tCAN'T JUMP");

            if (self.canClimb = EditorGlobals.ShowToggle("Can Climb?", self.canClimb))
            {
                self.climbSpd = EditorGlobals.ShowOptionSlider("Climb Speed", "Slow", "Fast", 60, self.climbSpd, ref self.MIN_CLIMB_SPD, ref self.MAX_CLIMB_SPD);
                self.climbAngle = EditorGlobals.ShowOptionSlider("Climb Angle", "Low", "High", 60, self.climbAngle, ref self.MIN_CLIMB_ANGLE, ref self.MAX_CLIMB_ANGLE);
            }
            else
            {
                //EditorGUILayout.LabelField("\tCAN'T CLIMB");
                self.dragSpeed = EditorGlobals.ShowOptionSlider("Slide Speed", "Slow", "Fast", 60, self.dragSpeed, ref self.MIN_CHR_SPD, ref self.MAX_CHR_SPD);
                self.climbAngle = EditorGlobals.ShowOptionSlider("Slide Angle", "Low", "High", 60, self.climbAngle, ref self.MIN_CLIMB_ANGLE, ref self.MAX_CLIMB_ANGLE);
            }

            if (self.canSwim = EditorGlobals.ShowToggle("Can Swim?", self.canSwim))
                self.swimSpd = EditorGlobals.ShowOptionSlider("Swim Speed", "Slow", "Fast", 60, self.swimSpd, ref self.MIN_SWIM_SPD, ref self.MAX_SWIM_SPD);
            else
                EditorGUILayout.LabelField("\tCAN'T SWIM");

            if (showConstraints = EditorGUILayout.Foldout(showConstraints, "Show Constraints"))
            {
                EditorGlobals.ShowConstraints("Move Speed", ref self.MIN_CHR_SPD, ref self.MAX_CHR_SPD);
                EditorGlobals.ShowConstraints("Sprint", ref self.MIN_SPRINT, ref self.MAX_SPRINT);
                EditorGlobals.ShowConstraints("Sneak", ref self.MIN_SNEAK, ref self.MAX_SNEAK);
                if (self.canClimb) EditorGlobals.ShowConstraints("Climb Angle", ref self.MIN_CLIMB_ANGLE, ref self.MAX_CLIMB_ANGLE);
                else EditorGlobals.ShowConstraints("Slide Angle", ref self.MIN_CLIMB_ANGLE, ref self.MAX_CLIMB_ANGLE);
                if (self.canJump) EditorGlobals.ShowConstraints("Jump/Fall", ref self.MIN_JUMP_VAL, ref self.MAX_JUMP_VAL);
                if (self.canClimb) EditorGlobals.ShowConstraints("Climb Speed", ref self.MIN_CLIMB_SPD, ref self.MAX_CLIMB_SPD);
                if (self.canSwim) EditorGlobals.ShowConstraints("Swim Speed", ref self.MIN_SWIM_SPD, ref self.MAX_SWIM_SPD);
            }

            EditorUtility.SetDirty(self);
        }
        else
            base.OnInspectorGUI();
    }
}
