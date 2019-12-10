using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNpc : MonoBehaviour
{
    public float distToClose = Mathf.Infinity;
	public Dialog closesntNpc = null;
	public Dialog[] allNpc;
    float distToNpc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allNpc = GameObject.FindObjectsOfType<Dialog>();
    	foreach (Dialog npc in allNpc)
		{
			distToNpc = (npc.transform.position - this.transform.position).sqrMagnitude;
			if(distToNpc < distToClose){
				distToClose = distToNpc;
				closesntNpc = npc;
                if(closesntNpc != null){
                closesntNpc.GetComponent<Dialog>().isClose = true;
			    }
            }
		}
		Debug.DrawLine(this.transform.position,closesntNpc.transform.position);

    }
}
