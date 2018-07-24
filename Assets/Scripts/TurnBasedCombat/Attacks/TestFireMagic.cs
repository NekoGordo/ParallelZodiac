using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFireMagic : IMagicAttack
{

    [SerializeField]
    private int damage = 2;

    private BaseCharacter myTarget;
    private BaseCharacter myPlayer;

    public int Cast()
    {
        Debug.Log("Cast was called");
        if (!myPlayer)
        {
            Debug.LogError("Caster not set call set player");
            return -1;
        }

        if (!myTarget)
        {
            Debug.LogError("Target not set. Call set Target");
            return -1;
        }

        myPlayer.DamageEnemy(myTarget, damage);
        return damage;
    }

    public string Load(Button button)
    {
        Debug.Log(button);
        button.onClick.AddListener(delegate { Cast(); });
        return "Fire";
    }

    public void SetPlayer(BaseCharacter player)
    {
        myPlayer = player;
    }

    public void SetTarget(BaseCharacter target)
    {
        myTarget = target;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
