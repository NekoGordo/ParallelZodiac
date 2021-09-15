using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject player;
    public GameObject door;
    public bool isClosetoDoor;
    public float MaxDis;
    public float dis;
    Animation animation;
    public bool doorOpen;
    // Start is called before the first frame update
    void Awake()
    {
        animation = this.gameObject.GetComponent<Animation>();
        door = this.gameObject;
        doorOpen = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(player.transform.position, door.transform.position);
       if(dis < MaxDis)
        {
            isClosetoDoor = true;
            if (Input.GetKeyDown(KeyCode.F) && doorOpen == false)
            {
                animation["doorOpen"].wrapMode = WrapMode.Once;
                animation.Play("doorOpen");
                doorOpen = true;
            }
        }
        else
        {
            if(doorOpen == true)
            {
                doorOpen = false;
                StartCoroutine(Close());
               
            }
            isClosetoDoor = false;
        }
    }

    IEnumerator Close()
    {
        
        yield return new WaitForSecondsRealtime(3);
        animation["doorClose"].wrapMode = WrapMode.Once;
        animation.Play("doorClose");
        StopCoroutine(Close());
    }
}
