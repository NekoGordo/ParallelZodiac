using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataReader;

public class TestLoading : MonoBehaviour
{
    [SerializeField]
    private string path;
    [SerializeField]
    private string[] keys;
    [SerializeField]
    private int[] arrayKeys;
    private JSONObject json;

    // Start is called before the first frame update
    void Start()
    {
        json = JSONReader.ReadJSONFromFile(path);
        Debug.Log(JSONReader.ParseJSON(json, keys, false, arrayKeys));
    }
}
