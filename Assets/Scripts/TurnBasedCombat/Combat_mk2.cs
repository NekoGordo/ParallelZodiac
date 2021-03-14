using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * completed:
 * enemy spawning
 * player spawning
 * spawn enemy at random spots
 * spawn enemies at random ammount between 1-3
 * make boss spawn random
 */
public class Combat_mk2 : MonoBehaviour
{
    /*
    *what needs doing:
    -set up turn order
    -make player deal damage
    -make player take damage
    -death for enemy and players
    -make player move in combat
    -player move within a certain range
    -gain xp
    -check for level up
    -add magic attacks
    -add mana
    -take away mana when using magic
    */

    public GameObject currentAttacker;
    public Calculations calc;

    void Awake(){
        calc = gameObject.GetComponent<Calculations>();
        //where am i?
        Debug.Log("Awaken");
        //spawn boss
        SpawnBoss();
        // spawn the enemeis
        spawnEnemys();
        //spawn players
        spawnPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawnEnemys(){
        Debug.Log("Spawn enemies");
        float amount = Random.Range(1, 4);
        var enemySpawnPoints = GameObject.FindGameObjectsWithTag("Spawn_Enemy");
        //spawns 1
        if(amount == 1)
        {
            for (int i = 0; i < enemySpawnPoints.Length-2; i++)
            {
                GameObject enemyObject;
                switch (Random.Range(0, 3))
                {
                    case 0:
                        enemyObject = Instantiate(Resources.Load("SpiritBird"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();
                        calc.entites.Add(enemyObject);
                        break;
                    case 1:
                        enemyObject = Instantiate(Resources.Load("MineralDragon"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();

                        calc.entites.Add(enemyObject);
                        break;
                    case 2:
                        enemyObject = Instantiate(Resources.Load("FireCactus"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();
                        calc.entites.Add(enemyObject);
                        break;
                    default:
                        break;

                }
            }
        }
        // spawns 2
        if(amount == 2)
        {
            for(int i = 0; i<enemySpawnPoints.Length-1; i++)
            {
                GameObject enemyObject;
                switch (Random.Range(0, 3))
                {
                    case 0:
                        enemyObject = Instantiate(Resources.Load("SpiritBird"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();
                        calc.entites.Add(enemyObject);
                        break;
                    case 1:
                        enemyObject = Instantiate(Resources.Load("MineralDragon"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();
                        calc.entites.Add(enemyObject);
                        break;
                    case 2:
                        enemyObject = Instantiate(Resources.Load("FireCactus"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();
                        calc.entites.Add(enemyObject);
                        break;
                    default:
                        break;

                }
            }
        }
        // spawns 3
        if (amount == 3)
        {
            for (int i = 0; i < enemySpawnPoints.Length; i++)
            {
                GameObject enemyObject;
                switch (Random.Range(0, 3))
                {
                    case 0:
                        enemyObject = Instantiate(Resources.Load("SpiritBird"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();

                        calc.entites.Add(enemyObject);
                        break;
                    case 1:
                        enemyObject = Instantiate(Resources.Load("MineralDragon"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();
                        calc.entites.Add(enemyObject);
                        break;
                    case 2:
                        enemyObject = Instantiate(Resources.Load("FireCactus"), enemySpawnPoints[i].transform) as GameObject;
                        enemyObject.AddComponent<CharacterStats>();
                        calc.entites.Add(enemyObject);
                        break;
                    default:
                        break;

                }
            }
        }
    }
    void SpawnBoss(){
        float chance = Random.Range(1, 3);
        if(chance == 1)
        {
            return;
        }
        if (chance == 2)
        {

            Debug.Log("SpawnBoss");
            var bossSpawn = GameObject.FindGameObjectWithTag("Spawn_Boss");
            GameObject bossobj;
            bossobj = Instantiate(Resources.Load("SquidTurtle"), bossSpawn.transform) as GameObject;
            bossobj.AddComponent<CharacterStats>();
            calc.entites.Add(bossobj);
        }
    }
    void spawnPlayer(){
        Debug.Log("Spawn player");
        var allySpawnPoints = GameObject.FindGameObjectsWithTag("Spawn_Ally");

        var shiroSpawnIndex = Random.Range(0, 2);
        var binxSpawnIndex = 1 - shiroSpawnIndex;

        GameObject shiroobj;
        GameObject binxobj;

        shiroobj = Instantiate(Resources.Load("Shiro"), allySpawnPoints[shiroSpawnIndex].transform) as GameObject;
        shiroobj.AddComponent<CharacterStats>();
        calc.entites.Add(shiroobj);
        binxobj = Instantiate(Resources.Load("Binx"), allySpawnPoints[binxSpawnIndex].transform) as GameObject;
        binxobj.AddComponent<CharacterStats>();
        calc.entites.Add(binxobj);
    }

}
