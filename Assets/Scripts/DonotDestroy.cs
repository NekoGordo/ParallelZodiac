using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroy : MonoBehaviour {

    private void Awake () {
        DontDestroyOnLoad ( this.gameObject );
    }

}
