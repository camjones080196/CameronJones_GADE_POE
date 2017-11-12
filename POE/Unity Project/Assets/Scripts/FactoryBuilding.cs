using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class FactoryBuilding : Building
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        int unitsToProduce = 20;
        int gameTicksPerProduction = 250;
        int spawnX, spawnY;
        Unit addUnit;
        System.Random random = new System.Random();

        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

    public int UnitsToProduce
    {
        get
        {
            return unitsToProduce;
        }
        set
        {
            unitsToProduce = value;
        }
    }
    public int GameTicksPerProduction
    {
        get
        {
            return gameTicksPerProduction;
        }
        set
        {
            gameTicksPerProduction = value;
        }
    }
   
    public int SpawnX
    {
        get
        {
            return spawnX;
        }
        set
        {
            spawnX = value;
        }
    }
    public int SpawnY
    {
        get
        {
            return spawnY;
        }
        set
        {
            spawnY = value;
        }
    }
   

    //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

    public FactoryBuilding(string faction, int xpos, int ypos)
        {
        Buildingsymbol = '@';
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

    public override Unit UnitSpawn(string faction)
        {
            if(unitsToProduce > 0)
            {
                int number = random.Next(1, 10);

            if (faction == "Hero")
            {
                if (number % 2 == 0)
                {
                    spawnX = 19;
                    spawnY = 19;
                    addUnit = new MeleeUnit(spawnX, spawnY, "Hero", '$');
                }

                if (number % 2 != 0)
                {
                    spawnX = 19;
                    spawnY = 19;
                    addUnit = new RangedUnit(spawnX, spawnY, "Hero", '^');
                }

            }

            if (faction == "Enemy")
            {
                if (number % 2 == 0)
                {
                    spawnX = 0;
                    spawnY = 19;
                    addUnit = new MeleeUnit(spawnX, spawnY, "Enemy", '%');
                }

                if (number % 2 != 0)
                {
                    spawnX = 0;
                    spawnY = 19;
                    addUnit = new RangedUnit(spawnX, spawnY, "Enemy", '&');
                }

            }
        }

            unitsToProduce--;
            return addUnit;

        }

    }

