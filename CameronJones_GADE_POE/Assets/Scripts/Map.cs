using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class Map
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************
        System.Random random = new System.Random();
        char[,] arrMap = new char[20, 20];
        Unit[] arrUnit = new Unit[10];
        char Symbol;
        int xpos, ypos;
        string Faction;

    //**************************************************************************************************************** G&S's *************************************************************************************************************************************

   public char[,] ArrMap
    {
        get
        {
            return arrMap;
        }
        set
        {
            arrMap = value;
        }
    }

    internal Unit[] ArrUnit
    {
        get
        {
            return arrUnit;
        }
        set
        {
            arrUnit = value;
        }
    }

    //**************************************************************************************************************** Methods *************************************************************************************************************************************

    public void PopulateBattlefield()
    {
        FactoryBuilding factory = new FactoryBuilding();
        ResourceBuilding resource = new ResourceBuilding();

        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                arrMap[j, i] = ',';
            }
        }

        arrMap[0, 0] = resource.Buildingsymbol;
        arrMap[19, 19] = factory.Buildingsymbol;

        for (int i = 0; i < ArrUnit.Length; i++)
        {
            int number = random.Next(1, 10);
            xpos = random.Next(1, 20);
            ypos = random.Next(1, 20);

            if (arrMap[xpos, ypos] != '#' && arrMap[xpos, ypos] != '@')
            {
                if (number % 2 == 0 && arrMap[xpos, ypos] == ',')
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

                    ArrUnit[i] = new MeleeUnit(xpos, ypos, Faction, Symbol);
                    arrMap[xpos, ypos] = Symbol;
                }

                else if (number % 2 != 0 && arrMap[xpos, ypos] == ',')
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

                    xpos = random.Next(1, 20);
                    ypos = random.Next(1, 20);

                    ArrUnit[i] = new RangedUnit(xpos, ypos, Faction, Symbol);
                    arrMap[xpos, ypos] = Symbol;
                }
                else
                {
                    i--;
                }

            }
            else
            {
                i--;
            }
        }


        /*for (int i = 0; i < ArrUnit.Length; i++)
        {
            int number = random.Next(1, 10);
            xpos = random.Next(1, 20);
            ypos = random.Next(1, 20);

            if (xpos + ypos != 0 && xpos + ypos != 38)
            {
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

                    ArrUnit[i] = new MeleeUnit(xpos, ypos, Faction, Symbol);
                    arrMap[xpos, ypos] = Symbol;
                }

                else if (number % 2 != 0)
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

                    xpos = random.Next(1, 20);
                    ypos = random.Next(1, 20);

                    ArrUnit[i] = new RangedUnit(xpos, ypos, Faction, Symbol);
                    arrMap[xpos, ypos] = Symbol;
                }
                else
                {
                    i--;
                }

            }
            else
            {
                i--;
            }


        }*/
    }

        public void UnitMove(Unit unit, int destx, int desty)
        {
            char sym = unit.Symbol;
            int currentx = unit.XPos;
            int currenty = unit.YPos;

           //arrMap[currentx, currenty] = ',';
            //arrMap[destx, desty] = sym;
        }

        public void UpdateUnit(Unit unit, int newx, int newy)
        {
            unit.XPos = newx;
            unit.YPos = newy;
        }

        /*public string redrawMap()
        {
            string gameWorld = "";

            for (int i = 0; i < arrMap.GetLength(0); i++)
            {
                for (int j = 0; j < arrMap.GetLength(1); j++)
                {
                    gameWorld += arrMap[i, j] + "  ";
                }

                gameWorld += Environment.NewLine;
            }

            return gameWorld;
        }*/

       


        

    }

