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
        private int health;
        private string faction;
        private char symbol;
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
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
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
    public char Symbol
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

    /*public Building()
        {
            //code
        }*/

        /*~Building()
        {
            //code
        }*/

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public abstract override string ToString();
       

    }

