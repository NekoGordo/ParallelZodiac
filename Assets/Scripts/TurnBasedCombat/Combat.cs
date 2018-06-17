using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//TODO: NAMESPACES

public class Combat : MonoBehaviour
{
    //TODO: Stop creating the scripts attached to this.

    //TODO: Do I tag the container that contains the spawns or do I tag the spawns themselves?
    //TODO: Condense these into one list of characters, and tag them
    public List<BaseCharacter> Characters;
    public int CharacterWithPriority;
    public GameObject db;   //TODO: What is this?
    public float testIntervalTick = 2;
    public float testTickTime;
    Button btn;
    [SerializeField]
    public Ally actingAlly;
    public Enemy enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> allies = new List<GameObject>();
    public GameObject BattleMenuPanel;
    int rng;

    [SerializeField]
    private float sphereCastRange;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Start Called");
        Characters = new List<BaseCharacter>();

        //for ( int i = 0; i < Characters.Count; i++ ) {
        // whats this for? 
        //}

        CharacterWithPriority = -1;

        SpawnEnemies();
        SpawnBoss();
        SpawnCharacters();

        SetUpCanvases();
        // for the attack button
        GameObject[] tempEnemies;
        tempEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < tempEnemies.Length; i++)
        {
            enemies.Add(tempEnemies[i]);
        }

        Ally[] tempAllies;

        tempAllies = GameObject.FindObjectsOfType<Ally>();
        // does this need to be here? is combsat gonna be on the GM permantly or is it gonna swap with a out of combat script?

        for (int i = 0; i < tempAllies.Length; i++)
        {
            allies.Add(tempAllies[i].gameObject);
        }

        BattleMenuPanel = GameObject.FindGameObjectWithTag("BattleMenu");

        CombatEnter();
    }
    // this update checks to see if the prioity is -1 if it is then it sets ally to null if its 5 or 4 then it sets it to shiro or binx
    void Update()
    {
        if (CharacterWithPriority != -1)
        {
            // needs fixing to work with tag of Player this is a temporay fix
            if (CharacterWithPriority == 4)
            {
                actingAlly = GameObject.FindGameObjectWithTag("Shiro").GetComponent<Shiro>();
                Cursor.lockState = CursorLockMode.None;
                if (BattleMenuPanel)
                {
                    BattleMenuPanel.SetActive(true);
                }
            }
            else if (CharacterWithPriority == 5)
            {
                actingAlly = GameObject.FindGameObjectWithTag("Binx").GetComponent<Binx>();
                Debug.Log("dragons");
                Cursor.lockState = CursorLockMode.None;
                if (BattleMenuPanel)
                {
                    BattleMenuPanel.SetActive(true);
                }
            }
        }
        else if (CharacterWithPriority == -1)
        {
            actingAlly = null;
            Cursor.lockState = CursorLockMode.Locked;

            if (BattleMenuPanel)
            {
                BattleMenuPanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log("WTF!");
            if (BattleMenuPanel)
            {
                BattleMenuPanel.SetActive(false);
            }
        }
    }
    //DO NOT CHANGE THIS IT TOOK ME FOREVER TO GET WORKING
    public void TurnPass()
    {
        if (CharacterWithPriority != -1)
        {
            if (CharacterWithPriority == 4)
            {
                actingAlly.CanAct = false;
                actingAlly.AttackBar = 0;
                actingAlly.PassTurn();
                actingAlly.DisablePlayerControl();
                return;
            }
            else if (CharacterWithPriority == 5)
            {
                actingAlly.CanAct = false;
                actingAlly.AttackBar = 0;
                actingAlly.PassTurn();
                actingAlly.DisablePlayerControl();
                return;
            }
        }
    }

    //this find the enemy script
    private Enemy FindEnemies()
    {

        Enemy enemy = null;
        Enemy CompareEnemy = null;

        //We'll do an overlap sphere to see what enemies are within range 2.5f should eventually be made into a private serialized variable
        Collider[] collisions;
        collisions = Physics.OverlapSphere(actingAlly.gameObject.transform.position, sphereCastRange);

        for (int i = 0; i < collisions.Length; i++)
        {
            //you can filter here however you want this is just one example
            if (collisions[i].gameObject.CompareTag("Enemy"))
            {

                Debug.Log("Enemies found");
                enemy = collisions[i].gameObject.GetComponent<Enemy>();

                //Set the compare enemy if it's null
                if (CompareEnemy == null)
                {
                    CompareEnemy = enemy;
                }
                else
                {

                    //figure out which enemy is closer. That's the one we want. 
                    float enemy1Distance = Vector3.Distance(actingAlly.transform.position, enemy.gameObject.transform.position);
                    float enemy2Distance = Vector3.Distance(actingAlly.transform.position, CompareEnemy.gameObject.transform.position);

                    Debug.Log($"Compare enemy {CompareEnemy.gameObject.name} is {enemy2Distance} units away");
                    Debug.Log($"Regular enemy {enemy.gameObject.name} is {enemy1Distance} units away");

                    if (enemy2Distance < enemy1Distance)
                    {
                        enemy = CompareEnemy;
                        CompareEnemy = null;
                    }
                }
            }

        }

        Debug.Log(enemy ? enemy.gameObject.name : "Nothing found" );
        return enemy;
    }

    //under construction
    /*
     * the atttack button needs to get the main script from the enemy EG mineral dragon() firecactus() ....
     * then attacks the enemy and the enemy HP canvas (the red bar) should drop
     */
    public void AttackBTN()
    {

        Enemy targetEnemy;

        Debug.Log("Attacking");
        if (CharacterWithPriority != -1)
        {

            if (actingAlly.CanAct)
            {
                targetEnemy = FindEnemies();
                if (targetEnemy)
                {
                    actingAlly.hasAttacked = true;
               
                    actingAlly.Attack(targetEnemy);

                    actingAlly.CanAct = false;
                    actingAlly.AttackBar = 0;
                    actingAlly.PassTurn();
                    actingAlly.DisablePlayerControl();
                    actingAlly.hasAttacked = false;
                    enemy = null;
                    targetEnemy = null;
                }
                return;
            }

            //None of this is nessecary
            //if (CharacterWithPriority == 4)
            //{
            //    for (int i = 0; i < allies.Count; i++)
            //    {
            //        for (int j = 0; j < enemies.Count; j++)
            //        {
            //            float dist = Vector3.Distance(allies[i].transform.position, enemies[j].transform.position);
            //            if (dist <= 2.5f)
            //            {
            //                FindEnemies();
            //                //Debug.Log ( allies [ i ].ToString () + " isattacking = " + enemies [ j ].ToString ());
            //                //Characters [ i ].hasAttacked = true;
            //                //ally.Attack ();
            //                //ally.CanAct = false;
            //                //ally.AttackBar = 0;
            //                //ally.PassTurn ();
            //                //ally.DisablePlayerControl ();
            //                //Characters [ i ].hasAttacked = false;
            //                //enemy = null;
            //                //return;

            //            }
            //        }
            //    }
            //}
            //else if (CharacterWithPriority == 5)
            //{
            //    for (int i = 0; i < allies.Count; i++)
            //    {
            //        for (int j = 0; j < enemies.Count; j++)
            //        {
            //            float dist = Vector3.Distance(allies[i].transform.position, enemies[j].transform.position);
            //            if (dist <= 2.5)
            //            {

            //                //Debug.Log ( allies[i].ToString() + " is attacking = " + enemies [ j ].ToString () );
            //                //Characters [ i ].hasAttacked = true;
            //                //ally.Attack ();
            //                //ally.CanAct = false;
            //                //ally.AttackBar = 0;
            //                //ally.PassTurn ();
            //                //ally.DisablePlayerControl ();
            //                //Characters [ i ].hasAttacked = false;
            //                //return;
            //            }
            //        }
            //    }
            //}
        }
    }

    public void Run()
    {
        if (CharacterWithPriority != -1)
        {
            rng = Random.Range(1, 101);
            Debug.Log(rng);
            //shiro is faster so higher chance of escape
            if (CharacterWithPriority == 4)
            {
                if (rng > 35)
                {
                    actingAlly.CanAct = false;
                    actingAlly.AttackBar = 0;
                    actingAlly.PassTurn();
                    actingAlly.DisablePlayerControl();
                    Application.LoadLevel("OverworldTest");
                }
                else if (rng < 35)
                {
                    actingAlly.CanAct = false;
                    actingAlly.AttackBar = 0;
                    actingAlly.PassTurn();
                    actingAlly.DisablePlayerControl();
                    return;
                }
            }
            else if (CharacterWithPriority == 5)
            {
                if (rng > 60)
                {
                    actingAlly.CanAct = false;
                    actingAlly.AttackBar = 0;
                    actingAlly.PassTurn();
                    actingAlly.DisablePlayerControl();
                    Application.LoadLevel("OverworldTest");
                }
                else if (rng < 60)
                {
                    actingAlly.CanAct = false;
                    actingAlly.AttackBar = 0;
                    actingAlly.PassTurn();
                    actingAlly.DisablePlayerControl();
                    return;
                }
            }
        }
    }
    /*
     * the magic button for now should attack using magic and stuff i dont think we have a mana bar set up
     */
    public void MagicAttack()
    {
        if (CharacterWithPriority != -1)
        {
            if (actingAlly.CanAct)
            {
                //TODO: have them attack with magic
            }
        }
    }

    //TODO: Create a BaseCharacter Factory, use it instead of these
    void SpawnEnemies()
    {
        var enemySpawnPoints = GameObject.FindGameObjectsWithTag("Spawn_Enemy");

        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            Enemy enemy = null;
            GameObject enemyobject;
            switch (Random.Range(0, 3))
            {
                case 0:
                    enemyobject = Instantiate(Resources.Load("SpiritBird"), enemySpawnPoints[i].transform) as GameObject;
                    enemy = enemyobject.AddComponent<SpiritBird>();
                    enemy.visual = enemyobject;
                    break;
                case 1:
                    enemyobject = Instantiate(Resources.Load("MineralDragon"), enemySpawnPoints[i].transform) as GameObject;
                    enemy = enemyobject.AddComponent<MineralDragon>();
                    enemy.visual = enemyobject;
                    break;
                case 2:
                    enemyobject = Instantiate(Resources.Load("FireCactus"), enemySpawnPoints[i].transform) as GameObject;
                    enemy = enemyobject.AddComponent<FireCactus>();
                    enemy.visual = enemyobject;
                    break;
                default:
                    break;
            }

            if (enemy != null)
            {
                Characters.Add(enemy);
                Debug.Log("Spawning: " + enemy.GetType().ToString());
            }
        }
    }
    void SpawnBoss()
    {
        var bossSpawn = GameObject.FindGameObjectWithTag("Spawn_Boss"); //TODO: Will there only be one boss at a time?

        GameObject bossobj;
        bossobj = Instantiate(Resources.Load("SquidTurtle"), bossSpawn.transform) as GameObject;
        var boss = bossobj.AddComponent<SquidTurtle>();
        boss.visual = bossobj;

        Characters.Add(boss);

        Debug.Log("Spawning: " + boss.GetType().ToString());
    }
    void SpawnCharacters()
    {
        var allySpawnPoints = GameObject.FindGameObjectsWithTag("Spawn_Ally");

        var shiroSpawnIndex = Random.Range(0, 2);
        var binxSpawnIndex = 1 - shiroSpawnIndex;

        GameObject shiroobj;
        GameObject binxobj;

        shiroobj = Instantiate(Resources.Load("Shiro"), allySpawnPoints[shiroSpawnIndex].transform) as GameObject;
        binxobj = Instantiate(Resources.Load("Binx"), allySpawnPoints[binxSpawnIndex].transform) as GameObject;

        var shiro = shiroobj.AddComponent<Shiro>();
        var binx = binxobj.AddComponent<Binx>();



        shiro.visual = shiroobj;
        binx.visual = binxobj;

        shiro.DisablePlayerControl();
        binx.DisablePlayerControl();

        Characters.Add(shiro);
        Characters.Add(binx);
    }

    void SetUpCanvases()
    {
        foreach (var character in Characters)
            character.SetupCanvas();
    }

    public void LateUpdate()
    {

        ;

        if (CharacterWithPriority != -1)
        {
            Characters[CharacterWithPriority].CharacterUpdate();

            if (Characters[CharacterWithPriority].CanAct == false)   //TODO: 
            {
                CharacterWithPriority = -1;
            }

            return;
        }


        for (int i = 0; i < Characters.Count; i++)
        {
            var character = Characters[i];
            character.CharacterUpdate();
            if (character.CanAct)
                PassPriority(i);

        }
        for (int i = 0; i < Characters.Count; i++)
        {
            if (Characters[i].CanAct)
            {
                Debug.Log("transform");
                Characters[i].MenuDisplay();
            }
        }


        //TODO: Check if all characters in one side are dead.
        //TODO: Acutally, maybe just check when a character dies
    }

    void PassPriority(int id)
    {
        CharacterWithPriority = id;
        Characters[CharacterWithPriority].ReceivPriority();
    }



    private void NotifyAttack(string charName)
    {
        Debug.Log(charName + " Is able to attack at time " + Time.time);
    }

    void CombatEnter()
    {
        //TODO: implement combat enter condition
    }

    void CombatExit()
    {
        //TODO: implement combat end condition
    }
}
