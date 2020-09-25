using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//TODO: Stop inheriting from mono. Need to get rid of the canvas instantiate
public class BaseCharacterCombat : MonoBehaviour
{
    public CharacterStats myStats;

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
        if (IsDead())
            return;

        UpdateBar();
        UpdateCanvas();
    }

    //TODO: Rename this
    public virtual void ReceivPriority()
    {
        
    }

    public bool IsDead()
    {
        if ( myStats.HealthPoints <= 0 ) {
            myStats.HealthPoints = 0;
            return true;
        }
        return false;
    }

    void UpdateCanvas()
    {
        Debug.Log(gameObject.name);
        Canvas.HPBarP.Target = myStats.HealthPoints / myStats.MaximumHealthPoints;
        Canvas.HPBar.GetComponent<Image>().fillAmount = Canvas.HPBarP.Position;
        Canvas.ATBarP.Target = myStats.AttackBar;
        Canvas.ATBar.GetComponent<Image>().fillAmount = Canvas.ATBarP.Position;
        //TODO: Is this always the main camera?
        Canvas.canvas.transform.LookAt(Camera.main.transform.position);

    }

    void UpdateBar()
    {
        myStats.AttackBar += (Time.deltaTime *myStats. AttackSpeed) / AttackSpeedDivider;
        if (myStats.AttackBar >= 1)
        {
            CanAct = true;
            // hasAttacked=attackChosen !=null ? true : false;
            // attackChosen = null;
            myStats.AttackBar = hasAttacked ? 0 : 1;
        }
    }

    public void TakeDamage()
    {
        // add damage to player
    }
    public void DamageEnemy () {

        // add damage to enemies
    }

    void CharacterDeath()
    {
        //TODO: implement character death
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

        // need to add menu display
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
