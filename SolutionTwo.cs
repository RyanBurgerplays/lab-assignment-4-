using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Internal.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SolutionTwo : MonoBehaviour
{
    public string myName;
    public string myClass; //what class you typed
    public string myRace; // what race you typed
    public int myLevel; //what level you typed
    public bool hasStout;
    public bool hasTough;
    public bool hpAveraged;
    public int myCon;
    private int myModifier;
    private int hpDiced;
    private int myHealth;
    private string doeshasFeat;
    

    private List<int> numbersCombined = new List<int>();
    public dndClass[] DNDClasses;
    public string[] DNDRace = { "Asaimar", "Dragonborn", "Dwarf", "Elf", "Gnome", "Goliath", "Halfling", "Human", "Orc", "Tiefling" };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DNDClasses = new dndClass[13];
        DNDClasses[0] = new dndClass("Artificer", 4.5f,8);
        DNDClasses[1] = new dndClass("Barbarian",6.5f,12);
        DNDClasses[2] = new dndClass("Bard", 4.5f,8);
        DNDClasses[3] = new dndClass("Cleric", 4.5f,8);
        DNDClasses[4] = new dndClass("Druid", 4.5f, 8);
        DNDClasses[5] = new dndClass("Fighter", 5.5f, 10);
        DNDClasses[6] = new dndClass("Monk", 4.5f, 8);
        DNDClasses[7] = new dndClass("Ranger", 5.5f, 10);
        DNDClasses[8] = new dndClass("Rouge", 4.5f, 8);
        DNDClasses[9] = new dndClass("Paladin", 5.5f, 10);
        DNDClasses[10] = new dndClass("Sorcerer", 3.5f, 6);
        DNDClasses[11] = new dndClass("Wizard", 3.5f, 6);
        DNDClasses[12] = new dndClass("Warlock", 4.5f, 8);

        if (myLevel > 20) { myLevel = 20; } // makes sure the level cant go above the max of 20
        if (myLevel < 0) { myLevel = 0; }
        
        
        numbersCombined.Add(Mathf.FloorToInt((myCon - 10) / 2));
        GetClassandRace();
        
    }
    [System.Serializable]
    public class dndClass
    {

        public string className;
        public float diceAverage;
        public int hitDice;
        
        public dndClass(string classType, float averageDice, int diceHit)
        {
          className = classType; 
          diceAverage = averageDice;
          hitDice = diceHit;
        }
    }
    private void GetClassandRace()
    {
        foreach (string checkrace in DNDRace)   //sees if it has either the additions
        {
            
            if (myRace == "Dwarf")
            {
                numbersCombined.Add(2);
                
            }
            if (myRace == "Goliath" || myRace == "Orc")
            {
                numbersCombined.Add(1);
            }
        }
        foreach (dndClass whatclass in DNDClasses)      //figure out how to search the array for the string
        {
            
            if (whatclass.className == myClass)
            {
                Debug.Log(whatclass.hitDice +""+ whatclass.diceAverage);
                if (hpAveraged == false)
                {
                    healthCalc(whatclass.hitDice);
                }
                if(hpAveraged == true) 
                { 
                    numbersCombined.Add(Mathf.RoundToInt(whatclass.diceAverage));
                    healthCalc(0);
                }
            }
           // if (classname.className == null) { Debug.Log("You typed you class wrong"); }
        }
        
    }
    private void healthCalc(int hitDice)
    {
        if (hasStout == true) { numbersCombined.Add(1); doeshasFeat = "has stout feat";  }
        else if (hasTough == true) { numbersCombined.Add(2); doeshasFeat = "has tough feat"; }
        else { doeshasFeat = "does not have tough/stout feat"; }
        if (hpAveraged == false)
        {
            for (int i = 0; i < myLevel; i++)
            {
                hpDiced = Random.Range(1, hitDice) + hpDiced;
            }
            numbersCombined.Add(hpDiced);
        }
        myHealth = myLevel * (numbersCombined.Sum());
        OutputStats();
    }
    private void OutputStats()
    {
        Debug.Log("My character " + myName + " is a level " + myLevel + " "+ myClass + " with a CON score of " + myCon + " and is of " + myRace + " race and " + doeshasFeat + " and has " + myHealth + "health");

        //multiple the numberscombined by level then add level * dice average if there is average
        //add all the strings for the output like what race is, what class, what level, if there is a stout and tough, ect
    }
}
