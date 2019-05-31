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
    public Transform [] OtherCompT;
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
        
	}

	void Start(){
		rb = GetComponent<Rigidbody> ();
		// this.transform.rotation = Quaternion.LookRotation(Vector3.zero);
	}

	void Update () {
		distance = Vector3.Distance (myTransform.position, target.position);
        for ( int i = 0; i < OtherCom.Length; i++ ) {
			Debug.Log("i have found companions");
			if (PlayerCloseEnough){
				//move compnaions x distance away from eachother
				Dist = Vector3.Distance(this.transform.position, new Vector3(OtherCom[i].transform.position.x,transform.position.y,transform.position.z));
				if (Dist < stop){
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation,	Quaternion.LookRotation(dir),rotationSpeed *Time.deltaTime);					
					//moveSpeed = 3;
				}
				else if (Dist> stop){
					this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(target.transform.position),rotationSpeed*Time.deltaTime);
			//		moveSpeed = 0;
				}

			}

            // Dist = Vector3.Distance (myTransform.transform.position, OtherCom[i].gameObject.transform.position);
            // if ( Vector3.Distance(myTransform.transform.position,OtherCom[i].transform.position) > Dist ) {
            //     OtherCom[i].gameObject.transform.position = new Vector3(3,0,2);
			// 	Debug.Log("not moving");
            //     moveSpeed = 0;
            // } else if ( Vector3.Distance ( OtherCom [ i ].transform.position, myTransform.position ) < Dist ) {
            //     CompCloseEnough = false;
			// 	Debug.Log("moving");
            //     moveSpeed = 3;
            // }
			// Dist2 = Vector3.Distance(OtherCom[i].transform.position, OtherCom[i].transform.position);
			// if(Vector3.Magnitude(OtherCom[i].transform.position)<Dist2) {
			// 	moveSpeed = -3;
            // }
			// else {
			// 	moveSpeed=3;
			// }
           
        }
        //^^ myTransform.position, OtherCom [ i ].gameObject.transform.position
        
		if (distance <= stop) {
			//moveSpeed = 0;  
			PlayerCloseEnough = true;
		} else {
			moveSpeed = 3;
			PlayerCloseEnough = false;
			var lookDir = target.position - myTransform.position;
			lookDir.y = 0; // zero the height difference
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
