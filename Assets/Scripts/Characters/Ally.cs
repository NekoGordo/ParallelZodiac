using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ally : BaseCharacter
{
    public static string BASIC_TYPE = "Ally";  //TODO:This instead of tags?
    public static Material WalkZoneMaterial;
    Button btn;
    Combat combat;

    public override void CharacterUpdate()
    {
        //If you aren't acting, you're updating
        if (!CanAct)
        {
            base.CharacterUpdate();
            return;
        }
        else
        {
            //TODO: Moving, then menus, etc. Use a State system
            {
                float distance = Vector3.Distance(visual.transform.position, MovementOrigin);
                if(distance > MovementRadius)
                {
                    Vector3 originToCharacter = visual.transform.position - MovementOrigin;
                    originToCharacter *= MovementRadius / distance;
                    visual.transform.position = MovementOrigin + originToCharacter;
                }
            }
        }
    }

    private void Start () {
        combat = GameObject.Find ( "GM" ).GetComponent<Combat> ();

    }

    public void PassTurn () {
            Destroy ( MovementCollider );
    }

    public override void ReceivPriority()
    {
        CreateMovementZone();
        EnablePlayerControl();        
    }

    void CreateMovementZone()
    {
        MovementOrigin = visual.transform.position;

        MovementCollider = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        MovementCollider.transform.position = new Vector3(visual.transform.position.x, 0.05f, visual.transform.position.z);
        MovementCollider.transform.localScale = new Vector3(MovementRadius * 2, 0.1f, MovementRadius * 2);

        Collider[] colliders = MovementCollider.GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
            Destroy(colliders[i]);

        var renderer = MovementCollider.GetComponent<Renderer>();
        var material = (Material)Resources.Load("WalkZone", typeof(Material));
        if (renderer != null && material != null)
        {
            renderer.material = material;
        }
    }

    public void DisablePlayerControl()
    {
        Opsive.ThirdPersonController.EventHandler.ExecuteEvent(visual, "OnAllowGameplayInput", false);
    }
    public void EnablePlayerControl()
    {
        Opsive.ThirdPersonController.EventHandler.ExecuteEvent(visual, "OnAllowGameplayInput", true);
    }

    public void Attack(Enemy enemyToAttack)
    {

        if ( hasAttacked )
            DamageEnemy (enemyToAttack, (int)myStats.AttackDamage);
        //TODO: This code
    }
    public void DamageAlly () {
        TakeDamage ((int)myStats.AttackDamage);
    }
}