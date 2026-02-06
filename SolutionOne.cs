using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class SolutionOne : MonoBehaviour
{
    
    public string myName;
    public Dictionary<string, float> DNDClass = new Dictionary<string, float>();
    public Dictionary<int, int> ConScore = new Dictionary<int, int>();
    public Dictionary<string, int> DNDRace = new Dictionary<string, int>();
    public string myClass;
    private float hitDie;
    private bool hasFeat;
    public int myCon;
    private int myModifier;
    public int myLevel;
    public bool hasTough;
    public bool hasStout;
    private string doeshasFeat;
    public string myRace;
    private int myHealth;
    private int raceHPAdd;
    private int featHPAdd;
    public bool hpAveraged;
    private int hpDiced;

    void Start()
    {
        if (hpAveraged == true)
        {
            DNDClass.Add("Artificer", 4.5f);
            DNDClass.Add("Barbarian", 6.5f);
            DNDClass.Add("Bard", 4.5f);
            DNDClass.Add("Cleric", 4.5f);
            DNDClass.Add("Druid", 4.5f);
            DNDClass.Add("Fighter", 5.5f);
            DNDClass.Add("Monk", 4.5f);
            DNDClass.Add("Ranger", 5.5f);
            DNDClass.Add("Rouge", 4.5f);
            DNDClass.Add("Paladin", 5.5f);
            DNDClass.Add("Sorcerer", 3.5f);
            DNDClass.Add("Wizard", 3.5f);
            DNDClass.Add("Warlock", 4.5f);
        }
        // need to have it check for whatever the string is then get the roll from it 
        else
        {
            DNDClass.Add("Artificer", 8);
            DNDClass.Add("Barbarian", 12);
            DNDClass.Add("Bard", 8);
            DNDClass.Add("Cleric", 8);
            DNDClass.Add("Druid", 8);
            DNDClass.Add("Fighter", 10);
            DNDClass.Add("Monk", 8);
            DNDClass.Add("Ranger", 10);
            DNDClass.Add("Rouge", 8);
            DNDClass.Add("Paladin", 10);
            DNDClass.Add("Sorcerer", 6);
            DNDClass.Add("Wizard", 6);
            DNDClass.Add("Warlock", 8);
        }


            DNDRace.Add("Asaimar", 0);
        DNDRace.Add("Dragonborn", 0);
        DNDRace.Add("Dwarf", 2);
        DNDRace.Add("Elf", 0);
        DNDRace.Add("Gnome", 0);
        DNDRace.Add("Goliath", 1);
        DNDRace.Add("Halfling", 0);
        DNDRace.Add("Human", 0);
        DNDRace.Add("Orc", 1);
        DNDRace.Add("Tiefling", 0);


        GetStats();

    }

    // Update is called once per frame
    void GetStats()
    {
        foreach (string ClassName in DNDClass.Keys)
        {
            if (DNDClass.ContainsKey(myClass))
            {
                hitDie = DNDClass[myClass];    //gets the damage taken from whatever class it is 
            }
            else { Debug.Log("You spelt the class wrong"); }

        }
        foreach (string RaceName in DNDRace.Keys)       //checks if they have the stout or tough feat
        {
            if (DNDRace.ContainsKey(myRace))
            {
                if (DNDRace[myRace] == 1)
                {
                    raceHPAdd = 1;
                }
                else if (DNDRace[myRace] == 2)
                {                   
                    raceHPAdd = 2;
                }
                else { raceHPAdd = 0; }

            }
           // else { Debug.Log("You spelt the race wrong"); }
        }
        if (hasStout == true)           //figures uot how much hp to add if they have the feats
        {

            doeshasFeat = "has stout feat";
            featHPAdd = 1;
        }
        else if (hasTough == true)
        {
            doeshasFeat = "has tough feat";
            featHPAdd = 2;
        }
        else { doeshasFeat = "does not have tough/stout feat";  featHPAdd = 0; }

            myModifier = Mathf.FloorToInt((myCon - 10) / 2);    //calculates modifier based on whatever the con is using formula from dnd

        
        if (myLevel > 20) { myLevel = 20; } // makes sure the level cant go above the max of 20
        if (myLevel < 0) { myLevel = 0; }

        if(hpAveraged == false)
        {
            for (int i = 0; i < myLevel; i++)
            {
                hpDiced = Random.Range(0, Mathf.RoundToInt(hitDie)) +hpDiced;              
            }
            myHealth = (hpDiced + (myLevel * raceHPAdd) + (myLevel * featHPAdd));
        }
        if(hpAveraged == true) { myHealth = (myLevel * Mathf.RoundToInt(hitDie) + (myLevel * raceHPAdd) + (myLevel * featHPAdd)); }
        
        OutPutStats();
    }
    void OutPutStats()
    {
        Debug.Log("My character " + myName + "is a level " + myLevel + myClass + "with a CON score of " + myCon + " and is of " + myRace + "race and" + doeshasFeat + "and has" + myHealth + "health");
        Debug.Log("" + hpDiced);
    }
}
