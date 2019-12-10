using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {

	public TextMeshProUGUI textdsiplay;
	public string[] sentence;
	public int index;
	public float typingspeed;
	public bool Istalking = false;
	public bool hasFinished;
	public bool doneTalking;
    public int count;
	//public float dist;
	public GameObject player;
	public bool isClose;
	public float Distance;
	public FindNpc test;
//	public List<GameObject>npc = new List<GameObject>();
	void Start(){
		textdsiplay.text = "";

		//npc.Add(GameObject.Find("NPC"));
		player = GameObject.Find("Player");
		test = player.GetComponent<FindNpc>();

	}
	

	void Update(){
		/*
		do distance check here then run scripts
		 */
		//checks if its false then activates the sentences
		/*var shortDist = Mathf.Infinity;	
		GameObject closest;
		for (var i = 0; i < npc.Count; i++)
		{
			var dist = Vector3.Distance(transform.position,npc[i].transform.position);
			if(dist <shortDist){
				shortDist = dist;
				closest = npc[i];
				var check = Vector3.Distance(closest.transform.position,player.position);
				if(check>Distance ){
					closest.GetComponent<Dialog>().isClose = true;
				}
			}
		}this sort of works.
		there is a seperate script that works better*/
		
		if(test.closesntNpc.gameObject.name != this.gameObject.name){
			isClose = false;
		}

		var dist = Vector3.Distance(test.closesntNpc.gameObject.transform.position, player.transform.position);

		if(dist < Distance){		 
			if(Istalking == false && isClose){
				if (Input.GetKeyDown(KeyCode.M)){
					Istalking = true;
					hasFinished = false;
					doneTalking = false;
					StartCoroutine(Type());
				}
			}
		}
		//puts up the next sentence
		if (Istalking && isClose){
			if (Input.GetKeyDown(KeyCode.X))
			{
				if (count == sentence[index].Length)
				{
					textdsiplay.text = "";
					index++;
					count = 0;
					StopCoroutine(Type());
					StartCoroutine(Type());
				}else{
					return;
				}
			}
		}
		else if(Istalking && isClose == false){
			StopAllCoroutines();
			textdsiplay.text = "";
			Istalking = false;
		}
		
		
		if (doneTalking){
			textdsiplay.text = "";
            count = 0;
			doneTalking = false;
			StopAllCoroutines();
		}
	}
	IEnumerator Type(){
        if (index == sentence.Length)
        {
            index = 0;
            Istalking = false;
            doneTalking = true;
        }
		if(sentence.Length != index){
            foreach (char letter in sentence[index].ToCharArray())
            {
                textdsiplay.text += letter;
                yield return new WaitForSeconds(typingspeed);
                count++;
               
            }
		}
	}
}
