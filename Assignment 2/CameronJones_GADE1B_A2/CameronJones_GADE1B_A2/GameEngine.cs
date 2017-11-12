using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameronJones_GADE1B_A2
{
    class GameEngine
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        Map map = new Map(); 
        FactoryBuilding f = new FactoryBuilding();
        string gameMap;
        Unit tempHeroUnit;
        Unit tempEnemyUnit;
        Unit tempUnit;
        int timer = 0, move;
        int arraySize = 10;
        string MapString = "";


        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

        public int Timer { get => timer; set => timer = value; }
        public string GameMap { get => gameMap; set => gameMap = value; }
        public string MapString1 { get => MapString; set => MapString = value; }
        internal Map Map { get => map; set => map = value; }
        
        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public void PlayGame()
        {
            
             for (int i = 0; i < map.ArrUnit.Length; i++)
             {
                if (map.ArrUnit[i] != null)
                {
                    if (map.ArrUnit[i].AmDead(map.ArrUnit[i]) == true)
                    {
                        map.ArrUnit[i] = null;
                    }
                }

              

                if (map.ArrUnit[i] != null)
                {

                    if (map.ArrUnit[i].Currenthealth < (map.ArrUnit[i].Currenthealth / map.ArrUnit[i].Maxhealth) * 100)
                    {
                        move = map.ArrUnit[i].RunAway();

                        switch (move)
                        {
                            case 1:
                                if (map.ArrUnit[i].XPos + 1 != 21)
                                {
                                    map.ArrUnit[i].XPos = map.ArrUnit[i].XPos + 1;
                                    map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos + 1, map.ArrUnit[i].YPos);
                                }
                                break;
                            case 2:
                                if (map.ArrUnit[i].XPos - 1 != -1)
                                {
                                    map.ArrUnit[i].XPos = map.ArrUnit[i].XPos - 1;
                                    map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos - 1, map.ArrUnit[i].YPos);
                                }
                                break;
                            case 3:
                                if (map.ArrUnit[i].YPos + 1 != 21)
                                {
                                    map.ArrUnit[i].YPos = map.ArrUnit[i].YPos + 1;
                                    map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 1);
                                }
                                break;
                            case 4:
                                if (map.ArrUnit[i].YPos - 1 != -1)
                                {
                                    map.ArrUnit[i].YPos = map.ArrUnit[i].YPos - 1;
                                    map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos -1);
                                }
                                break;
                        }
                    }

                    else
                    {
                        tempEnemyUnit = map.ArrUnit[i].CheckClosestUnit(map.ArrUnit, map.ArrUnit[i], tempEnemyUnit);

                        if (map.ArrUnit[i].InCombat == true)
                        {
                            map.ArrUnit[i].Combat(tempEnemyUnit);
                        }
                        else
                        {
                            map.ArrUnit[i].CheckAttackRange(map.ArrUnit[i], tempEnemyUnit);

                            if (map.ArrUnit[i].InRange == true)
                            {
                                map.ArrUnit[i].Combat(tempEnemyUnit);
                            }
                            else if (timer % map.ArrUnit[i].Speed == 0)
                            {
                                move = map.ArrUnit[i].Move(map.ArrUnit[i], tempEnemyUnit);

                                switch (move)
                                {
                                    case 1:
                                        Console.WriteLine((map.ArrUnit[i].XPos - 1) + "," + map.ArrUnit[i].YPos);
                                        map.UnitMove(map.ArrUnit[i], map.ArrUnit[i].XPos - 1, map.ArrUnit[i].YPos);
                                        map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos - 1, map.ArrUnit[i].YPos);
                                        break;
                                    case 2:
                                        Console.WriteLine((map.ArrUnit[i].XPos + 1) + "," + map.ArrUnit[i].YPos);
                                        map.UnitMove(map.ArrUnit[i], map.ArrUnit[i].XPos + 1, map.ArrUnit[i].YPos);
                                        map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos + 1, map.ArrUnit[i].YPos);
                                        break;
                                    case 3:
                                        Console.WriteLine(map.ArrUnit[i].XPos + "," + (map.ArrUnit[i].YPos - 1));
                                        map.UnitMove(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos - 1);
                                        map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos - 1);
                                        break;
                                    case 4:
                                        Console.WriteLine(map.ArrUnit[i].XPos + "," + (map.ArrUnit[i].YPos + 1));
                                        map.UnitMove(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 1);
                                        map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 1);
                                        break;
                                    case 5:
                                        break;
                                }


                            }
                        }

                    }
                }
               
             }

           


                if(timer % f.GameTicksPerProduction == 0)
                {
                tempUnit = f.UnitSpawn();
                Unit[] newarrUnit = new Unit[arraySize + 1];

                    for (int i = 0; i < map.ArrUnit.Length; i++)
                    {
                        newarrUnit[i] = map.ArrUnit[i];
                    }

                    newarrUnit[arraySize] = tempUnit;

                    arraySize++;

                    map.ArrUnit = newarrUnit;

                    Map.ArrMap[tempUnit.XPos, tempUnit.YPos] =  tempUnit.Symbol;
               
                }

            MapString1 = Map.redrawMap();

            timer++;

        }
    }
}
