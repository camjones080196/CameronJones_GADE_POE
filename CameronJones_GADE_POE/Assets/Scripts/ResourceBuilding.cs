using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class ResourceBuilding : Building
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        char resourceType;
        int resourcesPerGameTick;
        int resourcesRemaining = 50;
        System.Random r = new System.Random();


        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

        public char ResourceType
        {
            get
            {
                return resourceType;
            }
            set
            {
                resourceType = value;
            }
        }
        public int ResourcesPerGameTick
        {
            get
            {
                return resourcesPerGameTick;
            }
            set
            {
                resourcesPerGameTick = value;
            }
        }
        public int ResourcesRemaining {
            get
            {
                return resourcesRemaining;
            }
            set
            {
                resourcesRemaining = value;
            }
        }
        
        
    

   

    //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

    public ResourceBuilding(string faction, int xpos, int ypos)
    {
           
        Buildingsymbol = '#';
        HP = MaxHP;
        Faction = faction;
        Xpos = xpos;
        Ypos = ypos;
    }



    //**************************************************************************************************************** Methods *************************************************************************************************************************************

    public override string ToString()
    {
        return Xpos + ", " + Ypos + ", " + HP + ", " + Faction + ", " + Buildingsymbol;
    }

    public override bool AmDead(int HP)
    {
        bool dead;

        if (HP <= 0)
        {
            dead = true;
            Debug.Log("I am dead.");
        }
        else
        {
            dead = false;
            Debug.Log("I am not dead.");
        }

        return dead;
    }

    public void GenerateResource()
        {

            resourcesPerGameTick = r.Next(1, 3);
            resourcesRemaining = resourcesRemaining - resourcesPerGameTick;
        }

    public override Unit UnitSpawn(string faction)
    {
        throw new NotImplementedException();
    }
}

