using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OWBattleMovement : MonoBehaviour {

    NavMeshAgent navMeshAgent;
    NavMeshPath navpath;
    public float RestTime;
    public float TimeForNewPath;
    Vector3 target;
    bool Routine;
    bool validpath;

    void Start () {
        navpath = new NavMeshPath();
        navMeshAgent = GetComponent<NavMeshAgent> ();
    }

    void Update () {
        if ( !Routine ) {
            StartCoroutine ( DoSomething () );
       }
    }

    Vector3 GetNewPos () {
        float x = Random.Range ( -20, 20 );
        float z = Random.Range ( -20, 20 );

        Vector3 pos = new Vector3 ( x, 0, z );
        return pos;
    }

    IEnumerator DoSomething() {
        Routine = true;
        yield return new WaitForSeconds (TimeForNewPath);
        GetNewPath ();
        validpath = navMeshAgent.CalculatePath ( target, navpath );
        if (!validpath) {
            Debug.Log ( "no path" );
            validpath = navMeshAgent.CalculatePath ( target, navpath );
        }
        yield return new WaitForSeconds ( RestTime);
        Routine = false;
    }

    void GetNewPath () {
        target = GetNewPos ();
        navMeshAgent.SetDestination (target);

    }

}
