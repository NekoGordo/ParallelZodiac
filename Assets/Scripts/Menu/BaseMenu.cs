using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    ////Parameters
    //--X--Y--Placement//
    public int XPosition { get; set; }
    public int YPosition{ get; set; }
    //--Width--Height--Placement//
    public int Width { get; set; }
    public int Height { get; set; }
    //Menu Name
    public string MenuName { get; set; }
}
