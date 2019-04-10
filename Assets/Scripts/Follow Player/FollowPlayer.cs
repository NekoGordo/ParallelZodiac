using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
public class FollowPlayer : MonoBehaviour {

	Rigidbody rb;
	public Transform target; 
	public float moveSpeed; 
	public float rotationSpeed = 3;
    public GameObject [] OtherCom;
    public Transform [] OtherCompT;
	public Transform myTransform ; 
	public float distance;
    public float Dist;
    public float Dist2;
    public float Dist3;
    public float CStop;
	public float stop;
	private bool PlayerCloseEnough = false;
    private bool CompCloseEnough = false;
    
	void Awake(){
		myTransform = transform;
        target = GameObject.FindGameObjectWithTag ( "Player" ).transform;
        OtherCom = GameObject.FindGameObjectsWithTag ( "Comp" );
        
	}

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		distance = Vector3.Distance (myTransform.position, target.position);
        for ( int i = 0; i < OtherCom.Length; i++ ) {
            Dist2 = Vector3.Magnitude (OtherCom [ i ].transform.position);
            if(Vector3.Distance(OtherCom[i].gameObject.transform.position, OtherCom [ i ].transform.position ) ) {

            }
            Dist = Vector3.Distance (myTransform.transform.position, OtherCom[i].gameObject.transform.position);
            if ( Vector3.Distance ( OtherCom [ i ].transform.position, myTransform.position ) < Dist ) {
                CompCloseEnough = true;
                moveSpeed = 0;
            } else if ( Vector3.Distance ( OtherCom [ i ].transform.position, myTransform.position ) > Dist ) {
                CompCloseEnough = false;
                moveSpeed = 3;
            }
           
        }
        //^^ myTransform.position, OtherCom [ i ].gameObject.transform.position
        if ( Vector3.Distance (target.position, myTransform.position) > distance) {
			PlayerCloseEnough = true;
		} else if (Vector3.Distance (target.position, myTransform.position) < distance){
			PlayerCloseEnough = false;
		}
		if (distance <= stop) {
			moveSpeed = 0;  
		} else {
			moveSpeed = 3;
			var lookDir = target.position - myTransform.position;
			lookDir.y = 0; // zero the height difference
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
