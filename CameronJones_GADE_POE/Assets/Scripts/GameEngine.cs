using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEngine : MonoBehaviour
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
    int GameTick = 0;
    int frameRate = 120;


    //**************************************************************************************************************** G&S's *************************************************************************************************************************************

    public int Timer
    {
        get
        {
            return timer;
        }

        set
        {
            timer = value;
        }
    }
    public string GameMap
    {
        get
        {
            return gameMap;
        }

        set
        {
            gameMap = value;
        }
    }
    public string MapString1
    {
        get
        {
            return gameMap;
        }

        set
        {
            gameMap = value;
        }
    }
    internal Map Map
    {
        get
        {
            return map;
        }

        set
        {
            map = value;
        }
    }

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
                                map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos - 1);
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
                                    Debug.Log((map.ArrUnit[i].XPos - 1) + "," + map.ArrUnit[i].YPos);
                                    map.UnitMove(map.ArrUnit[i], map.ArrUnit[i].XPos - 1, map.ArrUnit[i].YPos);
                                    map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos - 1, map.ArrUnit[i].YPos);
                                    break;
                                case 2:
                                    Debug.Log((map.ArrUnit[i].XPos + 1) + "," + map.ArrUnit[i].YPos);
                                    map.UnitMove(map.ArrUnit[i], map.ArrUnit[i].XPos + 1, map.ArrUnit[i].YPos);
                                    map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos + 1, map.ArrUnit[i].YPos);
                                    break;
                                case 3:
                                    Debug.Log(map.ArrUnit[i].XPos + "," + (map.ArrUnit[i].YPos - 1));
                                    map.UnitMove(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos - 1);
                                    map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos - 1);
                                    break;
                                case 4:
                                    Debug.Log(map.ArrUnit[i].XPos + "," + (map.ArrUnit[i].YPos + 1));
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




        if (timer % f.GameTicksPerProduction == 0)
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

            Map.ArrMap[tempUnit.XPos, tempUnit.YPos] = tempUnit.Symbol;

        }

        MapString1 = Map.redrawMap();

        timer++;

    }

   

    // Use this for initialization
    void Start ()
    {
        PlayGame();

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Instantiate(Resources.Load("Grass_Tiles"), new Vector3(i, j, 0), Quaternion.identity);
            }
        }

        Instantiate(Resources.Load("Resource_Building"), new Vector3(0, 0, -1), Quaternion.identity);
        Instantiate(Resources.Load("Factory_Building"), new Vector3(19, 19, -1), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameTick++;

        if (frameRate % GameTick == 0)
        {
            PlayGame();
            Redraw();
        }
	}

    void Redraw()
    {
        /*GameObject[] toDelete = GameObject.FindGameObjectsWithTag("ToDelete");
        foreach (GameObject temp in toDelete)
        {
            Destroy(temp.gameObject);
        }*/

        for(int i = 0; i < map.ArrUnit.Length; i++)
        {
            if(!map.ArrUnit[i].AmDead(map.ArrUnit[i]))
            {
                if (map.ArrUnit[i] != null)
                {
                    if (map.ArrUnit[i].Symbol == 'M')
                    {
                        Instantiate(Resources.Load("Hero_Melee"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                    }
                    if (map.ArrUnit[i].Symbol == 'm')
                    {
                        Instantiate(Resources.Load("Enemy_Melee"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                    }
                    if (map.ArrUnit[i].Symbol == 'R')
                    {
                        Instantiate(Resources.Load("Hero_Ranged"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                    }
                    if (map.ArrUnit[i].Symbol == 'r')
                    {
                        Instantiate(Resources.Load("Enemy_Ranged"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -1), Quaternion.identity);
                    }
                }
            }
        }
    }

    string determineHP(int hp, int Maxhp)
    {
        string temp = "hp";
        double HPpercentage = ((double)hp / (double)Maxhp) * 20;
        HPpercentage = Math.Ceiling(HPpercentage);
        temp += Convert.ToInt32(HPpercentage);
        return temp;
    }


}
