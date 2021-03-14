using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_mk2 : MonoBehaviour
{
    /*
    *what needs doing:
    -spawn enemies at random ammount between 1-3
    -make boss spawn random
    -make player move in combat
    -make player deal damage
    -make player take damage
    -death for enemy and players
    -player move within a certain range
    -gain xp
    -check for level up
    -add magic attacks
    -add mana
    -take away mana when using magic
    */

    public List<GameObject> eSpawn = new List<GameObject>();
    public Enemy enemy;

    void Awake(){
       
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
        var enemySpawnPoints = GameObject.FindGameObjectsWithTag("Spawn_Enemy");
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            GameObject enemyObject;
            switch(Random.Range(0,3)){
                case 0:
                    enemyObject = Instantiate(Resources.Load("SpiritBird"), enemySpawnPoints[i].transform) as GameObject;
                    enemyObject.AddComponent<SpiritBird>().enabled = true;
                    break;
                case 1:
                    enemyObject = Instantiate(Resources.Load("MineralDragon"), enemySpawnPoints[i].transform) as GameObject;
                    enemyObject.AddComponent<MineralDragon>().enabled = true;
                    break;
                case 2:
                    enemyObject = Instantiate(Resources.Load("FireCactus"), enemySpawnPoints[i].transform) as GameObject;
                    enemyObject.AddComponent<FireCactus>().enabled = true;
                    break;
                default:
                    break;

            }
        }
    }
    void SpawnBoss(){
        Debug.Log("SpawnBoss");
        var bossSpawn = GameObject.FindGameObjectWithTag("Spawn_Boss");
        GameObject bossobj;
        bossobj = Instantiate(Resources.Load("SquidTurtle"), bossSpawn.transform) as GameObject;
        bossobj.AddComponent<SquidTurtle>().enabled = true;
    }
    void spawnPlayer(){
        Debug.Log("Spawn player");
        var allySpawnPoints = GameObject.FindGameObjectsWithTag("Spawn_Ally");

        var shiroSpawnIndex = Random.Range(0, 2);
        var binxSpawnIndex = 1 - shiroSpawnIndex;

        GameObject shiroobj;
        GameObject binxobj;

        shiroobj = Instantiate(Resources.Load("Shiro"), allySpawnPoints[shiroSpawnIndex].transform) as GameObject;
        shiroobj.AddComponent<Shiro>().enabled=true;
        binxobj = Instantiate(Resources.Load("Binx"), allySpawnPoints[binxSpawnIndex].transform) as GameObject;
        binxobj.AddComponent<Binx>().enabled = true;

        
    }
}
