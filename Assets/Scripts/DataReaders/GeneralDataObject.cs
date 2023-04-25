using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ValueMap
{
    public List<string> Keys;
    public List<float> Values;
}

[Serializable]
public class StringValueMap
{
    public List<string> Keys;
    public List<string> Values;
}

[CreateAssetMenu]
public class GeneralDataObject : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    public ValueMap valueMap;

    public void OnAfterDeserialize()
    {
        if (valueMap.Keys.Count < valueMap.Values.Count)
        {
            Debug.Log("more values than keys, removing excess values");
            int index = valueMap.Values.Count - 1;
            while (valueMap.Keys.Count < valueMap.Values.Count)
            {
                valueMap.Values.RemoveAt(index);
                index--;
            }
        }
        else
        {
            if (valueMap.Keys.Count > valueMap.Values.Count)
            {
                Debug.Log("More keys than values, adding needed values");
                while (valueMap.Keys.Count > valueMap.Values.Count)
                {
                    valueMap.Values.Add(0);
                }
            }
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
