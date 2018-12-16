using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : MonoBehaviour {

    public bool IsAbleToFish = false;

    public string [] Common = new string [] { };
    int CNameLength;
    public string [] Uncommon = new string [] { };
    public string [] Artefacts = new string [] { };
    int UNameLength;
    int ANameLength;
    public int RNG;

    void Start () {
       
        CNameLength = Common.Length;
        UNameLength = Uncommon.Length;
        ANameLength = Artefacts.Length;
    }

    void OnTriggerEnter ( Collider other ) {
        if ( !IsAbleToFish) {
            Debug.Log ( "entered" );
            IsAbleToFish = true;
        }
    }

    private void OnTriggerStay ( Collider other ) {
        if (other.name == "Player") {
            if ( IsAbleToFish && Input.GetKeyDown ( KeyCode.L ) && GameObject.Find ( "Player" ).GetComponent<InputTesting> ().isSwimming == false ) {
                RNG = Random.Range ( 1, 150 );
                Debug.Log ( RNG );
                if ( RNG >= 101 ) {
                    int indexA = Random.Range ( 0, Artefacts.Length );
                    string getAItem = Artefacts [ indexA ];
                    print ( "get item from here " + getAItem );
                    Debug.Log ( "fishing" );
                }
                if ( RNG >= 51 && RNG <= 100 ) {
                    int indexU = Random.Range ( 0, Uncommon.Length );
                    string getUItem = Uncommon [ indexU ];
                    print ( "get item from here " + getUItem );
                    Debug.Log ( "fishing" );
                } else if ( RNG <= 50 ) {
                    int index = Random.Range ( 0, Common.Length );
                    string getItem = Common [ index ];
                    print ( "get item from here " + getItem );
                    Debug.Log ( "fishing" );
                }
                if ( IsAbleToFish && Input.GetKeyDown ( KeyCode.L ) && GameObject.Find ( "Player" ).GetComponent<InputTesting> ().isSwimming == true ) {
                    Debug.Log ( "cant fish while swimming" );
                }
            }
        }
    }

    void OnTriggerExit ( Collider other ) {
        if ( IsAbleToFish ) {
            Debug.Log ( "bye" );
            IsAbleToFish = false;
        }
    }
}
