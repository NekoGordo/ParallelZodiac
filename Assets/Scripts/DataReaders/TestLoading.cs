using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataReaders;
using Leguar.TotalJSON;

public class TestLoading : MonoBehaviour
{

    public GeneralDataObject data;

    [SerializeField]
    private string jsonPath;
    [SerializeField]
    private string csvPath;
    [SerializeField]
    private string jsonExt;
    [SerializeField]
    private string csvExt;
    [SerializeField]
    private string[] keys;
    [SerializeField]
    private int[] arrayKeys;
    private JSONObject json;

    // Start is called before the first frame update
    void Start()
    {
        //Test Json
        json = DataReader.ReadJSONFromFile(jsonPath, jsonExt);
        var displayJSON = DataReader.ParseJSON(json, keys, false, arrayKeys);
        Debug.Log(displayJSON);

        //Test CSV
        var csvResults = DataReader.ReadCSVFromFile(csvPath, csvExt);
        var csvKeys = csvResults[0].Keys;
        foreach (string key in csvKeys)
        {
            Debug.Log(key);
        }

        //Test Conversion
        var converted = DataReader.ConvertCSVToJSON(csvResults);
        Debug.Log(converted );


        //Write to scriptable object
        data.valueMap.Keys.Clear();
        data.valueMap.Values.Clear();

        for (int i = 0; i < keys.Length; i++)
        {
            data.valueMap.Keys.Add(keys[i]);
            if (displayJSON.IsArray)
            {
                data.valueMap.Values.Add(displayJSON[i].n);
            }
            else
            {
                data.valueMap.Values.Add(displayJSON.n);
            }
        }

        Debug.Log(data.valueMap.Keys);
    }
}
