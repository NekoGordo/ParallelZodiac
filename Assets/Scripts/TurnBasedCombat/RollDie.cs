using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDie {
    
    int RollD100 () {
       return Random.Range ( 0, 101 );
    }

    int RollD20 () {
        return Random.Range ( 0, 21 );
    }

    int RollD4 () {
        return Random.Range(0,5);
    }

    int RollD2 () {
        return Random.Range ( 0, 3 );
    }

    int RollD12 () {
        return Random.Range ( 0, 13 );
    }

    int RollD10 () {
        return Random.Range ( 0, 11 );
    }

    int RollD6 () {
        return Random.Range ( 0, 7 );
    }

    int RollD8 () {
        return Random.Range ( 0, 9 );
    }

    int RollGeneric (int maxnum) {
        return Random.Range ( 0, maxnum );
    }
}
