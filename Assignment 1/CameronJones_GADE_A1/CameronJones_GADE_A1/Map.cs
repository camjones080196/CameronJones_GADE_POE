using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameronJones_GADE_A1
{
    class Map
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************
        Random random = new Random();
        char[,] arrMap = new char[20, 20];
        Unit[] arrUnit = new Unit[10];
        char Symbol;
        int xpos, ypos;
        string Faction;

        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

        public char[,] ArrMap { get => arrMap; set => arrMap = value; }
        internal Unit[] ArrUnit { get => arrUnit; set => arrUnit = value; }

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public Unit[] PopulateBattlefield()
        {
           

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    arrMap[j, i] = ',';
                }
            }

           

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
                            Symbol = 'M';
                        }

                        if (number2 % 2 != 0)
                        {
                            Faction = "Enemy";
                            Symbol = 'm';
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
                            Symbol = 'R';
                        }

                        if (number2 % 2 != 0)
                        {
                            Faction = "Enemy";
                            Symbol = 'r';
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
            

            return ArrUnit;

        }

        public void UnitMove(Unit unit, int destx, int desty)
        {
            char sym = unit.Symbol;
            int currentx = unit.XPos;
            int currenty = unit.YPos;

            arrMap[currentx, currenty] = ',';
            arrMap[destx, desty] = sym;
        }

        public void UpdateUnit(Unit unit, int newx, int newy)
        {
            unit.XPos = newx;
            unit.YPos = newy;
        }

        public string redrawMap()
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
        }

       


        

    }
}
