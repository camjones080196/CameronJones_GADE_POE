using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    abstract class Building
{
        //**************************************************************************************************************** Variables *************************************************************************************************************************************
        private int xpos;
        private int ypos;
        private int hp, maxhp = 100;
        private string faction;
        private char buildingSymbol;

    //**************************************************************************************************************** G&S's *************************************************************************************************************************************

    public int Xpos
    {
        get
        {
            return xpos;
        }

        set
        {
            xpos = value;
        }
    }
    public int Ypos
    {
        get
        {
            return ypos;
        }

        set
        {
            ypos = value;
        }
    }
    public int HP
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }
    public int MaxHP
    {
        get
        {
            return maxhp;
        }

        set
        {
            maxhp = value;
        }
    }
    public string Faction
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
    public char Buildingsymbol
    {
        get
        {
            return buildingSymbol;
        }

        set
        {
            buildingSymbol = value;
        }
    }

    //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************


    //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public abstract bool AmDead(int HP);
        public abstract override string ToString();
        public abstract Unit UnitSpawn(string faction);
}

