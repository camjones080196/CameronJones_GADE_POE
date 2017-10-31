using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class FactoryBuilding : Building
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        int unitsToProduce = 10;
        int gameTicksPerProduction = 250;
        int spawnX, spawnY;
        int xPos, yPos, factoryHp, factoryMaxHp = 100;
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
    public int XPos
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
    public int YPos
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
    public int FactoryHP
    {
        get
        {
            return factoryHp;
        }
        set
        {
            factoryHp = value;
        }
    }

    public int FactoryMaxHP
    {
        get
        {
            return factoryMaxHp;
        }
        set
        {
            factoryMaxHp = value;
        }
    }

    //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

    public FactoryBuilding()
        {
            XPos = 19;
            YPos = 19;
            Buildingsymbol = '@';
            factoryHp = factoryMaxHp;
        }

        ~FactoryBuilding()
        {

        }

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public override string ToString()
        {
            return Xpos + ", " + Ypos + ", " + Health + ", " + Faction + ", " + Symbol;
        }

    public bool AmDead(int HP)
    {
        bool dead;

        if (HP <= 0)
        {
            dead = true;
        }
        else
        {
            dead = false;
        }

        return dead;
    }

    public Unit UnitSpawn()
        {
            if(unitsToProduce > 0)
            {
                int number = random.Next(1, 10);

                spawnX = 18;
                spawnY = 19;

                    if (number % 2 == 0)
                    {
                        int number2 = random.Next(1, 10);

                        if (number2 % 2 == 0)
                        {
                            Faction = "Hero";
                            Symbol = '$';
                        }

                        if (number2 % 2 != 0)
                        {
                            Faction = "Enemy";
                            Symbol = '%';
                        }

                    addUnit = new MeleeUnit(spawnX, spawnY, Faction, Symbol);

                    }

                    Xpos = random.Next(1, 20);
                    Ypos = random.Next(1, 20);

                    if (number % 2 != 0)
                    {
                        int number2 = random.Next(1, 10);

                        if (number2 % 2 == 0)
                        {
                            Faction = "Hero";
                            Symbol = '^';
                        }

                        if (number2 % 2 != 0)
                        {
                            Faction = "Enemy";
                            Symbol = '&';
                        }

                        addUnit = new RangedUnit(spawnX, spawnY, Faction, Symbol);
                    }
            }

            unitsToProduce--;
            return addUnit;

        }

    }

