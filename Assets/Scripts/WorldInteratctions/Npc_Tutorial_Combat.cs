using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Npc_Tutorial_Combat : MonoBehaviour {

    NPC npc;
    public string NpName;
    public GameObject player;
    public int time = 3;
    public float ObjDist;
    public GameObject gd;

    private void Awake () {
        npc = new NPC ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        gd = GameObject.Find ( "Game_Director" );
        npc.npcname = NpName;
    }

    void FixedUpdate () {
        ObjDist = Vector3.Distance ( this.gameObject.transform.position, player.transform.position );
        if ( ObjDist < 2.5 ) {
            if ( Input.GetKeyDown ( KeyCode.C ) ) {
                Debug.Log ( "hi there my name is "+ npc.npcname + "\n i am going to take you to the combat field now" + "\n good luck");
                StartCoroutine ( GoNext ());
            }
        } else if ( ObjDist > 2.6 ) {
            return;
            }
        }

     IEnumerator GoNext () {
        yield return new WaitForSeconds ( time );
        gd.GetComponent<Combat>().CombatEnter();
    }

    }
