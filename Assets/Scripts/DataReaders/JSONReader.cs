using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DataReader
{
    public static class JSONReader
    {
        /// <summary>
        /// Parses a JSON object to return a nested JSON Object. Uses the string array of keys to get each nested field.
        /// The keys must be in traversal order. 
        /// </summary>
        /// <param name="json">The JSON object we wish to parse through.</param>
        /// <param name="keys">A sequence of fields in the JSON object, must be in order of nesting</param>
        /// <param name="returnArray"> Set this to true if you want to return an array from a key, otherwise the assumption is you want to dive into the array. Must provide an array key when true</param>/param>
        /// <param name="arrayKeys">Indices into nested arrays, keys are read in order as this function encounters arrays</param>
        /// <returns></returns>
        public static JSONObject ParseJSON(JSONObject json, string[] keys, bool returnArray = false, int[] arrayKeys = null)
        {
            //Ensure that we have keys into the json object
            if (keys.Length < 1)
            {
                throw new ArgumentException("Must provided a set of keys to parse with. Must be an array and cannot be empty", "Keys");   
            }

            JSONObject objectHolder;
            if (keys.Length == 1)
            {
                return json.GetField(keys[0]);
            }
            else
            {
                objectHolder = json.GetField(keys[0]);
            }

            int arrayKeyIndex = 0;

            for (int i = 1; i < keys.Length; i++)
            {
                objectHolder = objectHolder.GetField(keys[i]);

                //If they field we grabbed turned out to be an array, we'll want to grab our desired index;
                if (objectHolder.IsArray)
                {
                    if (!returnArray && (arrayKeys == null || arrayKeyIndex >= arrayKeys.Length))
                    {
                        throw new ArgumentException("Array keys cannot be null when attempting to access array objects. Array Keys must also be equal to the number of arrays you're attemtpting to access", "ArrayKeys");
                    }
                    int index = arrayKeys[arrayKeyIndex];
                    objectHolder = objectHolder[index];
                }

            }
            return objectHolder;
        }

        public static JSONObject ReadJSONFromFile(string path)
        {
            string jsonString = LoadResourceTextfile(path);

            JSONObject JSON = new JSONObject(jsonString);
            return JSON;
            
        }

        public static string LoadResourceTextfile(string path)
        {

            string filePath = $"Data/{path.Replace(".json", "")}"; 

            TextAsset targetFile = Resources.Load<TextAsset>(filePath);

            return targetFile.text;
        }


    }
}
