﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using Leguar.TotalJSON;


namespace DataReaders
{
    public static class DataReader
    {

        // Regex for parsing CSV, DO NOT TOUCH THIS
        private static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        private static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
        private static char[] TRIM_CHARS = { '\"' };

        /// <summary>
        /// Parses a JSON object to return a nested JSON Object. Uses the string array of keys to get each nested field.
        /// The keys must be in traversal order. 
        /// </summary>
        /// <param name="json">The JSON object we wish to parse through.</param>
        /// <param name="keys">A sequence of fields in the JSON object, must be in order of nesting</param>
        /// <param name="returnArray"> Set this to true if you want to return an array from a key, otherwise the assumption is you want to dive into the array. Must provide an array key when true</param>/param>
        /// <param name="arrayKeys">Indices into nested arrays, keys are read in order as this function encounters arrays</param>
        /// <returns></returns>
        public static JValue ParseJSON(JValue json, string[] keys, bool returnArray = false, int[] arrayKeys = null)
        {
            
            JSON jsonObjectHolder;
            int arrayKeyIndex = 0;
            JArray jsonArray;
            //Ensure that we have keys into the json object unless we're indexing into an immediate array
            if (keys.Length < 1)
            {
                if (json is JArray)
                {
                    jsonArray = json as JArray;
                    //We either don't want to return an array so we need to update the object holder
                    //Or we want to return an array but not this one
                    if (!returnArray || (returnArray && (arrayKeys != null && arrayKeys.Length > 0)))
                    {
                        jsonObjectHolder = jsonArray.GetJSON(arrayKeys[arrayKeyIndex]);
                        arrayKeyIndex++;
                    }
                    else if(arrayKeys == null || arrayKeys.Length < 1)
                    {
                        return jsonArray;
                    }
                }
                else
                {
                    throw new ArgumentException("Must provided a set of keys to parse with. Must be an array and cannot be empty", "Keys");
                }
            }


            if (json is JSON)
            {
                jsonObjectHolder = json as JSON;
                if (keys.Length == 1)
                {
                    return jsonObjectHolder.Get(keys[0]);
                }
                else
                {
                    jsonObjectHolder = jsonObjectHolder.GetJSON(keys[0]);
                }
            }
            else if (json is JArray)
            {
                jsonArray = json as JArray;
                jsonObjectHolder = jsonArray.GetJSON(arrayKeys[arrayKeyIndex]);
                arrayKeyIndex++;
            }
            else
            {
                throw new Exception("Could not determine JSON object type");
            }
           
            //Now loop throw our keys into the json and dig as deep as we into to get a JValue
            for (int i = 1; i < keys.Length; i++)
            {
                JValue temp = jsonObjectHolder.Get(keys[i]);

                //If they field we grabbed turned out to be an array, we'll want to grab our desired index;
                if (temp is JArray)
                {
                    if (!returnArray && (arrayKeys == null || arrayKeyIndex >= arrayKeys.Length))
                    {
                        throw new ArgumentException("Array keys cannot be null when attempting to access array objects. Array Keys must also be equal to the number of arrays you're attemtpting to access", "ArrayKeys");
                    }
                    int index = arrayKeys[arrayKeyIndex];
                    JArray tempArray = temp as JArray;
                    jsonObjectHolder = tempArray[index] as JSON;
                }

            }
            return jsonObjectHolder;
        }

        /// <summary>
        /// Reads a JSON file in and spits out a JSONObject
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JValue ReadJSONFromFile(string filename, string extenstion)
        {
            string jsonString = LoadResourceTextfile(filename, extenstion);
            JValue json = TryParseJSONOrArray(jsonString);
            return json;
        }

        public static JValue TryParseJSONOrArray(string jsonString)
        {
            JValue json;
            try
            {
                json = JSON.ParseString(jsonString);
            }
            catch
            {
                try
                {
                    json = JArray.ParseString(jsonString);
                }
                catch
                {
                    throw new Exception("Cannot parse file as JSON or Array please check file for errors and try again.");
                }
            }
            return json;
        }

        /// <summary>
        /// Reads a CSV file and returns it as a dictionary
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> ReadCSVFromFile(string filename, string extension)
        {
            var list = new List<Dictionary<string, object>>();
            string data = LoadResourceTextfile(filename, extension);

            var lines = Regex.Split(data, LINE_SPLIT_RE);

            if (lines.Length <= 1) return list;

            var header = Regex.Split(lines[0], SPLIT_RE);
            for (var i = 1; i < lines.Length; i++)
            {

                var values = Regex.Split(lines[i], SPLIT_RE);
                if (values.Length == 0 || values[0] == "") continue;

                var entry = new Dictionary<string, object>();
                for (var j = 0; j < header.Length && j < values.Length; j++)
                {
                    string value = values[j];
                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                    object finalvalue = value;
                    int n;
                    float f;
                    if (int.TryParse(value, out n))
                    {
                        finalvalue = n;
                    }
                    else if (float.TryParse(value, out f))
                    {
                        finalvalue = f;
                    }
                    entry[header[j]] = finalvalue;
                }
                list.Add(entry);
            }
            return list;
        }

        /// <summary>
        /// Reads a Parsed CSV file, as List of dictionaries, and converts them to JSONObjects
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static JValue ConvertCSVToJSON(List<Dictionary<string, object>> dict)
        {
            JSONObject masterJson = new JSONObject();

            for (int i = 0; i < dict.Count; i++)
            {
                JSONObject innerJson = new JSONObject();

                var innerDict = dict[i];
                foreach (string key in innerDict.Keys)
                {
                    string finalKey = key;

                    //Blank keys shall be ignored
                    if (key == "" || key.Length == 0 || key == null)
                    {
                        continue;
                    }
                    
                    //Remove escapre characters from the key string
                    if (key.Contains("\""))
                    {
                        finalKey = key.Replace("\"", "");
                    }

                    var item = innerDict[key];


                    if (item == null)
                    {
                        continue;
                    }

                    Type itemType = item.GetType();

                    if (itemType == typeof(float))
                    {
                        float finalItem = (float)item;
                        innerJson.AddField(finalKey, finalItem);
                    }
                    else if (itemType == typeof(int))
                    {
                        int finalItem = (int)item;
                        innerJson.AddField(finalKey, finalItem);
                    }
                    else if (itemType == typeof(string))
                    {
                        string finalItem = (string)item;

                        //Blank strings will also be ignored
                        if (finalItem.Length == 0 || finalItem == null || finalItem == "")
                        {
                            continue;
                        }
                        //Remve escape characters 
                        if (finalItem.Contains("\""))
                        {
                            finalItem = finalItem.Replace("\"", "");
                        }

                        innerJson.AddField(finalKey, finalItem);
                    }
                    else if (itemType == typeof(bool))
                    {
                        bool finalItem = (bool)item;
                        innerJson.AddField(finalKey, finalItem);
                    }
                    else
                    {
                        throw new Exception("Could not determine type of item in CSV File. Must be a number, string, or bool");
                    }
                }
                masterJson.Add(innerJson);
            }
            string stringifiedJSON = masterJson.ToString();
            return TryParseJSONOrArray(stringifiedJSON);
        }

        /// <summary>
        /// Loads a text file from the Data Folder in resources and spits it back as a string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string LoadResourceTextfile(string path, string ext)
        {
            string filePath = $"Data/{path.Replace(ext, "")}";

            TextAsset targetFile = Resources.Load<TextAsset>(filePath);

            return targetFile.text;
        }

    }
}
