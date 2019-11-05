using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
public class FollowPlayer : MonoBehaviour {

	Rigidbody rb;
	public Transform target; 
	public float moveSpeed; 
	public float rotationSpeed = 3;
	public Vector3 dir;
    public GameObject [] OtherCom;
	public GameObject comp1;
	public GameObject comp2;
	public GameObject marker;
	public GameObject comp3;
	public GameObject comp4;
	public Transform myTransform ; 
	public float distance;
    public float Dist;
    public float CStop;
	public float stop;
	public bool PlayerCloseEnough = false;
    public bool CompCloseEnough = false;
    
	void Awake(){
		myTransform = transform;
        target = GameObject.FindGameObjectWithTag ( "Player" ).transform;
        OtherCom = GameObject.FindGameObjectsWithTag ( "Comp" );
		for ( int i = 0; i < OtherCom.Length; i++ ) {
			Debug.Log(OtherCom.Length);
			if(i == 1){
				Debug.Log("found 1 or 2");
				comp1 = OtherCom[0];
			}
			if(i == 2){
				comp2 = OtherCom[1];
				comp1 = OtherCom[0];
			}
			if(i == 3){
				comp3 = OtherCom[2];
				comp2 = OtherCom[1];
				comp1 = OtherCom[0];
			}
			if (i == 4){
				comp4 = OtherCom[3];
				comp3 = OtherCom[2];
				comp2 = OtherCom[1];
				comp1 = OtherCom[0];
			}
			
		}
		marker = GameObject.Find("marker");

	}

	void Start(){
		rb = GetComponent<Rigidbody> ();
		
		
		
		// this.transform.rotation = Quaternion.LookRotation(Vector3.zero);
	}

	void Update () {
		distance = Vector3.Distance (myTransform.position, target.position);
        
		for ( int i = 0; i < OtherCom.Length; i++ ) {
			
			Debug.Log("i have found companions: "+ OtherCom.Length);
			if (PlayerCloseEnough){
				Debug.Log("companions are close");
				//move compnaions x distance away from eachother
				Dist = Vector3.Distance(new Vector3(OtherCom[i].transform.position.x,OtherCom[i].transform.position.y,OtherCom[i].transform.position.z), new Vector3(OtherCom[i].transform.position.x,OtherCom[i].transform.position.y,OtherCom[i].transform.position.z));
				if (Dist < CStop){
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation,	Quaternion.LookRotation(dir),rotationSpeed *Time.deltaTime);					
					// Debug.DrawLine(this.transform.position,OtherCom[i].transform.position,Color.red);
					Debug.Log("plz move away");
					moveSpeed = 1.5f;
					var dist2 = Vector3.Distance(comp1.transform.position,marker.transform.position);
					if(dist2>CStop){
						comp1.transform.position += comp1.transform.right * moveSpeed * Time.deltaTime;
					}
					
				}
				else {	
					moveSpeed = 0;
				}
			}
		}

         //^^ myTransform.position, OtherCom [ i ].gameObject.transform.position
        
		if (distance <= stop) {
			//moveSpeed = 0;  
			PlayerCloseEnough = true;
		} else {
			moveSpeed = 1.5f;
			PlayerCloseEnough = false;
			var lookDir = target.position - myTransform.position;
			lookDir.y = 0; // zero the height difference
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}