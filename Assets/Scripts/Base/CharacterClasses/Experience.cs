using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Experience {
    //TODO: Make partial classes for race and character. Have a centralized character setup script
    //This script will load the data for the char. ALl the data. 
    //Then each other thing that needs the data (for dmg, this, etc) will call CentralCharScript.GetXPToNextevel()
    //It will handle the data management, these will handle the logic
    enum BaseXPToLevel : int //Renamed to base so we can have different classes or races require different XP amounts to level up 
    {
        Level1 = 0, 
        Level2 = 100, 
        Level3 = 300, 
        Level4 = 900, 
        Level5 = 1800
    };
    int CurrentLevel;
    int CurrentXP;
    Race CharacterRace;
    
    public Experience()
    {
        LoadDataForRace("Mortal");
    }

    public Experience (string race)
    {
        LoadDataForRace(race);
    }

    void LoadDataForRace(string race)
    {
        try
        {
            //TODO: Shorten this
            var path = Application.dataPath + @"/Scripts/Base/RaceClassStats/" + race + ".xml";
            //This stuff is commented out because it would result in "C:\\..." instead of "C:\", which was causing it to fail to find
            //Path.Combine(Application.dataPath, "Scripts");
            //path = Path.Combine(path, "Base");
            //path = Path.Combine(path, "RaceClassStats");
            //path = Path.Combine(path, race + ".xml");
            TextReader reader = new StreamReader(path);
            var data = new XmlSerializer(typeof(Race)).Deserialize(reader);
            CharacterRace = (Race)data;
            reader.Close();
        }
        catch (Exception ex)
        {
            //TODO: Error handling
        }
    }

    public void LevelUp()
    {
        CurrentLevel++;
    }

    public void AddXP(int xp)
    {
        CurrentXP += xp;
        if (xp >= GetXPToNextLevel())
            LevelUp();   
    }

    int GetXPToNextLevel()
    {
        string currentLevelString = "Level" + CurrentLevel.ToString();  //TODO: Make "Level" a static final
        var raceMod = CharacterRace.XPPerLevelMod;
        //TODO: The same thing with class mods, or any other xp mods
    
        //TODO: Test this 
        int baseXP = 0;
        var baseXPPerLvl = System.Enum.Parse(typeof(BaseXPToLevel), currentLevelString);
        baseXP = (int)baseXPPerLvl;
        
        return raceMod + baseXP;
    }


    public partial struct Race
    {
        public string CharacterRace;
        public int MaxLevel;
        public int XPPerLevelMod;
        public int StrengthMod;
        public int IntelligenceMod;
        public int DexterityMod;
        public int DefenseMod;
    }
}