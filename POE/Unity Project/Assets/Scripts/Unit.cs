using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    abstract class Unit 
{
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

    private new string name = "";
    private int xPos = 0;
    private int yPos = 0;
    private int maxHealth = 100;
    private int currentHealth = 0;
    private int speed = 0;
    private int attack = 0;
    private int attackRange = 0;
    private string faction = "";
    private char symbol = '^';
    private bool inCombat = false;
    
    

        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

    public virtual int XPos
    {
        get
        {
            return xPos;
        }
        set
        {
            xPos = value;
        }
    }
    public virtual int YPos
    {
        get
        {
            return yPos;
        }
        set
        {
            yPos = value;
        }
    }
    public virtual int Maxhealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }
    public virtual int Currenthealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }
    public virtual int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public virtual int Attack
    {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
    }
    public virtual int AttackRange
    {
        get
        {
            return attackRange;
        }
        set
        {
            attackRange = value;
        }
    }
    public virtual string Faction
    {
        get
        {
            return faction;
        }
        set
        {
            faction = value;
        }
    }
        public virtual char Symbol
    {
        get
        {
            return symbol;
        }
        set
        {
            symbol = value;
        }
    }
    public virtual bool InCombat
    {
        get
        {
            return inCombat;
        }
        set
        {
            inCombat = value;
        }
    }
   
    public virtual string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    
       

        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

       


        

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public abstract int Move(Unit currentUnit, Unit tempenemyUnit);
        public abstract int BuildingMove(Unit currentUnit, Building tempBuilding);
        public abstract void Combat(Unit tempenemyUnit);
        public abstract void BuildingCombat(Building enemyBuilding);
        public abstract bool CheckAttackRange(Unit currentUnit, Unit tempenemyUnit);
        public abstract bool CheckBuildingRange(Unit currentUnit, Building tempBuilding);
        public abstract Unit CheckClosestUnit(Unit[] unitTemp, Unit currentUnit, Unit tempenemyunit);
        public abstract Building CheckClosestBuilding(Building[] buildingTemp, Unit currentUnit, Building tempBuidling);
        public abstract int RunAway();
        public abstract bool AmDead(int HP);
        //public abstract void SaveUnit(Unit[] tempUnit);
       // public abstract void ReadUnit();
        public abstract override string ToString();
    }
    

