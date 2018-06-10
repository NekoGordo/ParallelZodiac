using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//TODO: Stop inheriting from mono. Need to get rid of the canvas instantiate
public class BaseCharacter : MonoBehaviour
{

    public string BasicType;    //TODO: ???

    //TODO: Make a class/struct for these? This needs refactoring
    public string Name;
    public int Force;
    public int Vitality;
    public int Agility;
    public int Fortiude;
    public int Intellect;
    public int Rationale;
    public int Charisma;

    public float AbilityPoints; //abillity points(magic damage)
    public float AttackDamage; //attack damage
    public float MoralPoints; //moral points
    public float Defence;
    public float MagicDefence; //magic deffence
    public float AttackSpeed; //attack speed
    public float TravelStamina; //helps with trvels
    public float HealthPoints;
    public float MaximumHealthPoints = 0;
    public float MaximumAttackBar;
    public float MaximumAbilityPoints = 0;
    public float AttackBar;

    float AttackSpeedDivider = 64f; //TODO: Why 64?

    public int MovementRadius = 5;
    protected Vector3 MovementOrigin;
    protected GameObject MovementCollider;

    public bool CanAct;
    public bool hasAttacked;
    public bool EnemyAttacked;
    public GameObject visual;
    Canvas battlemenu;
    MyCanvas Canvas;
    GameObject menu;
    GameObject active;
    GameObject inactive;

    public void SetupCanvas()
    {
        Canvas = CreateCanvas();
    }
    MyCanvas CreateCanvas()
    {
        GameObject realcanvas = Instantiate(Resources.Load("Canvas", typeof(GameObject)), visual.transform) as GameObject;
        MyCanvas canvas = new MyCanvas
        {
            HPBarP = new FSpring(),
            ATBarP = new FSpring(),
            canvas = realcanvas,
            HPBar = realcanvas.transform.Find("HealthBG").Find("HealthBar").gameObject,
            ATBar = realcanvas.transform.Find("ATBG").Find("ATBar").gameObject,
        };

        canvas.HPBarP.Speed = 11f;
        canvas.ATBarP.Speed = 11f;
        canvas.HPBarP.Damper = 0.66f;
        canvas.ATBarP.Damper = 0.66f;

        return canvas;
    }

    void Start () {
        menu = GameObject.FindGameObjectWithTag ( "BattleMenu" );
        inactive = GameObject.FindGameObjectWithTag ( "Inactive" );
        active = GameObject.FindGameObjectWithTag ( "Active" );
        menu.transform.position = inactive.transform.position;
    }

    //TODO: A different update for when they are acting?
    public virtual void CharacterUpdate()
    {
        if (IsDead()) return;

        UpdateBar();
        UpdateCanvas();
    }

    //TODO: Rename this
    public virtual void ReceivPriority()
    {
        
    }

    public bool IsDead()
    {   
        if (HealthPoints == 0)
            return true;
        return false;
    }

    void UpdateCanvas()
    {
        Canvas.HPBarP.Target = HealthPoints / MaximumHealthPoints;
        Canvas.HPBar.GetComponent<Image>().fillAmount = Canvas.HPBarP.Position;
        Canvas.ATBarP.Target = AttackBar;
        Canvas.ATBar.GetComponent<Image>().fillAmount = Canvas.ATBarP.Position;
        //TODO: Is this always the main camera?
        Canvas.canvas.transform.LookAt(Camera.main.transform.position);

    }

    void UpdateBar()
    {
        AttackBar += (Time.deltaTime * AttackSpeed) / AttackSpeedDivider;
        if (AttackBar >= 1)
        {
            CanAct = true;
            // hasAttacked=attackChosen !=null ? true : false;
            // attackChosen = null;
            AttackBar = hasAttacked ? 0 : 1;
        }
    }

    public void TakeDamage(int force)
    {
        int damage = force; //TODO: Implement actual damage formula
        HealthPoints -= damage;

        if (HealthPoints <= 0)
        {
            CharacterDeath();
        }
        EnemyAttacked = false;
    }
    public void DamageEnemy (int force) {
        int damage = force; //TODO: Implement actual damage formula
        HealthPoints -= damage;

        if ( HealthPoints <= 0 ) {
            CharacterDeath ();
        }
    }

    void CharacterDeath()
    {
        HealthPoints = 0;
        AttackBar = 0;

        UpdateCanvas();

        Debug.Log("Character Dead: " + (string.IsNullOrEmpty(Name) ? "Unknown" : Name));
        //TODO: Play death anim, anything else that needs to happen
    }
    
    void CreatePlayerMovementRadius () {
        //TODO: implement the distance the olayer can move
    }

    void PlayerFinishedMoving () {
        //TODO: has the player finished moving?
    }

    void PlayerActionSelect () {
        //TODO: implement selection menu for actions that can be done
    }

    public void MenuDisplay () {

        Debug.Log ( "why am i here?" );
        if ( menu ) {
            if ( CanAct == true ) {
                Debug.Log ( "or am i here?" );
                Debug.Log ( "i have been called and i can do something" );
                menu.transform.position = active.transform.position;
                Debug.Log ( "can act = " + CanAct );
            } else {
                Debug.Log ( "um am i here?" );
                menu.transform.position = inactive.transform.position;
            }
        } else {
            Debug.Log ( "Can't Find Menu" );
        }
    }
    
    private struct MyCanvas
    {
        //TODO: Rename these
        public FSpring HPBarP; //Remember to init
        public FSpring ATBarP; //Remember to init
        public GameObject HPBar;
        public GameObject ATBar;
        public GameObject canvas;
    }
}
