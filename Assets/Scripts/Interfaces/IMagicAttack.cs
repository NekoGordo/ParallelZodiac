using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IMagicAttack
{

    //When implemented cast should calculate damage and return an int of how much damage it is dealing
    int Cast();

    //Should be called to load the attack into the menu. Should return a string with the name of the attack to map it to the button
    string Load(Button button);

    void SetTarget(BaseCharacter target);
    void SetPlayer(BaseCharacter player);


}
