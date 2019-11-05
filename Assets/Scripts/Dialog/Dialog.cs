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
	void Start(){
		textdsiplay.text = "";
	}
	void Update(){
		/*
		do distance check here then run scripts
		 */
		//checks if its false then activates the sentences
		if(Istalking == false){
			if (Input.GetKeyDown(KeyCode.M)){
				Istalking = true;
				hasFinished = false;
				doneTalking = false;
				StartCoroutine(Type());
			}
		}
		//puts up the next sentence
		if (Istalking){
			if(!doneTalking){
				if(Input.GetKeyDown(KeyCode.X)){
					textdsiplay.text = "";
					index++;
					StartCoroutine(Type());
				}
			}
		}
		if (doneTalking){
			textdsiplay.text = "";
			StopAllCoroutines();
		}
	}
	IEnumerator Type(){
		if(index == sentence.Length){
			index = 0;
			Istalking = false;
			doneTalking = true;
		}	
		if(sentence.Length != index){	
		foreach (char letter in sentence[index].ToCharArray()){
			textdsiplay.text += letter; 	
			yield return new WaitForSeconds(typingspeed);
			//wip
			//hasFinished = true;
			}
		}
	}
}
