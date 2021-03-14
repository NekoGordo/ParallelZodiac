using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations : MonoBehaviour
{
    /* to do:
     * sepeart entites into allied or enemy
     * get speed from all entites
     * put entites into speed order
     * if current attacker just went move to the back
     */
    public List<GameObject> entites = new List<GameObject>();

  

    void Update(){

        SortList();
    }

    private void SortList()
    {
        entites.Sort(objSort);
    }

    private int objSort(GameObject a, GameObject b)
    {
        if(a.GetComponent<CharacterStats>().TotalAgility < b.GetComponent<CharacterStats>().TotalAgility)
        {
            return -1;
        }
        else if(a.GetComponent<CharacterStats>().TotalAgility > b.GetComponent<CharacterStats>().TotalAgility)
        {
            return 1;
        }
        return 0;
    }

    private int SortFunc(CharacterStats a, CharacterStats b)
    {
        if(a.TotalAgility < b.TotalAgility)
        {
            return -1;
        }
        else if(a.TotalAgility > b.TotalAgility)
        {
            return 1;
        }
        return 0;
    }
}
