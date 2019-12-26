using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataReaders;

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
        json = DataReader.ReadJSONFromFile(path);
        Debug.Log(DataReader.ParseJSON(json, keys, false, arrayKeys));
    }
}
