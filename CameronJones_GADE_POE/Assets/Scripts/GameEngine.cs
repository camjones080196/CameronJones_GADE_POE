﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEngine : MonoBehaviour
{


    //**************************************************************************************************************** Variables *************************************************************************************************************************************

    Map map = new Map();
    FactoryBuilding fh = new FactoryBuilding("Hero", 19, 19);
    FactoryBuilding fe = new FactoryBuilding("Enemy", 0, 19);
    ResourceBuilding rh = new ResourceBuilding("Hero", 0, 0);
    ResourceBuilding re = new ResourceBuilding("Enemy", 19, 0);
    Building tempBuilding;
    Unit tempEnemyUnit;
    Unit tempUnit;
    int move;
    int arraySize = 10;
    int GameTick = 1;
    int frameRate = 30;


    //**************************************************************************************************************** G&S's *************************************************************************************************************************************

    
    
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

        

        for (int i = 0; i < arraySize; i++)
        {
          
            if (map.ArrUnit[i] != null && map.ArrUnit[i].AmDead(map.ArrUnit[i]) != true)
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

                    if (tempEnemyUnit != null)
                    {

                        if (map.ArrUnit[i].InCombat == true)
                        {
                            map.ArrUnit[i].Combat(tempEnemyUnit);
                            if(tempEnemyUnit.AmDead(tempEnemyUnit) == true)
                            {
                                map.ArrUnit[i].InCombat = false;
                            }
                        }
                        else
                        {
                            map.ArrUnit[i].CheckAttackRange(map.ArrUnit[i], tempEnemyUnit);

                            if (map.ArrUnit[i].InRange == true)
                            {
                                map.ArrUnit[i].InCombat = true;
                                map.ArrUnit[i].Combat(tempEnemyUnit);
                            }
                            else if (GameTick % map.ArrUnit[i].Speed == 0)
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
                    else
                    {
                        tempBuilding = map.ArrUnit[i].CheckClosestBuilding(map.ArrBuilding, map.ArrUnit[i], tempBuilding);

                        if (map.ArrUnit[i].InCombat == true)
                        {
                            map.ArrUnit[i].BuildingCombat(tempBuilding);
                            if (tempEnemyUnit.AmDead(tempEnemyUnit) == true)
                            {
                                map.ArrUnit[i].InCombat = false;
                            }
                        }
                        else
                        {
                            map.ArrUnit[i].CheckBuildingRange(map.ArrUnit[i], tempBuilding);

                            if (map.ArrUnit[i].InRange == true)
                            {
                                map.ArrUnit[i].InCombat = true;
                                map.ArrUnit[i].BuildingCombat(tempBuilding);
                            }

                            else if (GameTick % map.ArrUnit[i].Speed == 0)
                            {
                                move = map.ArrUnit[i].BuildingMove(map.ArrUnit[i], tempBuilding);

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

        }




        if (GameTick % fe.GameTicksPerProduction == 0)
        {
            System.Random r = new System.Random();
            int number = r.Next(1,10);

            if (number % 2 == 0)
            {
                tempUnit = fh.UnitSpawn(fh.Faction);
            }
            else
            {
                tempUnit = fe.UnitSpawn(fe.Faction);
            }

            Unit[] newarrUnit = new Unit[arraySize + 1];

            for (int i = 0; i < map.ArrUnit.Length; i++)
            {
                newarrUnit[i] = map.ArrUnit[i];
            }

            newarrUnit[arraySize] = tempUnit;

            arraySize++;

            map.ArrUnit = newarrUnit;

            //Map.ArrMap[tempUnit.XPos, tempUnit.YPos] = tempUnit.Symbol;

        }

        

        

    }

   

    // Use this for initialization
    void Start ()
    {
        map.PopulateBattlefield();

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Instantiate(Resources.Load("Grass_Tiles"), new Vector3(i, j, 0), Quaternion.identity);
            }
        }

        Instantiate(Resources.Load("Resource_Building"), new Vector3(19, 0, -1), Quaternion.identity);
        Instantiate(Resources.Load("Resource_Building"), new Vector3(0, 0, -1), Quaternion.identity);
        Instantiate(Resources.Load("Factory_Building"), new Vector3(19, 19, -1), Quaternion.identity);
        Instantiate(Resources.Load("Factory_Building"), new Vector3(0, 19, -1), Quaternion.identity);

        for (int i = 0; i < arraySize; i++)
        {
            if (map.ArrUnit[i].Symbol == '$')
                {
                    Instantiate(Resources.Load("Hero_Melee"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                    GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
                }
                else if (map.ArrUnit[i].Symbol == '%')
                {
                    Instantiate(Resources.Load("Enemy_Melee"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                    GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
                }
                else if (map.ArrUnit[i].Symbol == '^')
                {
                    Instantiate(Resources.Load("Hero_Ranged"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                    GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
                }
                else if (map.ArrUnit[i].Symbol == '&')
                {
                    Instantiate(Resources.Load("Enemy_Ranged"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                    GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
                }

        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameTick++;

        if (GameTick % frameRate == 0)
        {
            PlayGame();

            for(int i = 0; i < map.ArrUnit.Length; i++)
            {
                Debug.Log(map.ArrUnit[i].Name + "," + map.ArrUnit[i].Faction + "," + map.ArrUnit[i].Currenthealth + "," + map.ArrUnit[i].AmDead(map.ArrUnit[i]));
            }

            Redraw();
        }
	}

    void Redraw()
    {
        GameObject[] toDelete = GameObject.FindGameObjectsWithTag("ToDelete");
        foreach (GameObject temp in toDelete)
        {
            Destroy(temp.gameObject);
        }

        if(fh.AmDead(fh.HP) == false)
        {
            Instantiate(Resources.Load("Factory_Building"), new Vector3(19, 19, -1), Quaternion.identity);
            GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(fh.HP, fh.MaxHP)), new Vector3(19, 19 + 0.5f, -1), Quaternion.identity);
        }

        if (fe.AmDead(fe.HP) == false)
        {
            Instantiate(Resources.Load("Factory_Building"), new Vector3(0, 19, -1), Quaternion.identity);
            GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(fe.HP, fe.MaxHP)), new Vector3(0, 19 + 0.5f, -1), Quaternion.identity);
        }

        if (rh.AmDead(rh.HP) == false)
        {
            Instantiate(Resources.Load("Resource_Building"), new Vector3(0, 0, -1), Quaternion.identity);
            GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(rh.HP, rh.MaxHP)), new Vector3(rh.Xpos, rh.Ypos + 0.5f, -1), Quaternion.identity);
        }
        if (rh.AmDead(re.HP) == false)
        {
            Instantiate(Resources.Load("Resource_Building"), new Vector3(19, 0, -1), Quaternion.identity);
            GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(re.HP, re.MaxHP)), new Vector3(re.Xpos, re.Ypos + 0.5f, -1), Quaternion.identity);
        }


        for (int i = 0; i < arraySize; i++)
        {
            Debug.Log(map.ArrUnit[i].AmDead(map.ArrUnit[i]) + "," + map.ArrUnit[i].Symbol);

            if (map.ArrUnit[i].AmDead(map.ArrUnit[i]) == false)
                {
                    Debug.Log("Entered Loop");

                    if (map.ArrUnit[i].Symbol == '$')
                    {
                        Instantiate(Resources.Load("Hero_Melee"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
                    }
                    if (map.ArrUnit[i].Symbol == '%')
                    {
                        Instantiate(Resources.Load("Enemy_Melee"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
                    }
                    if (map.ArrUnit[i].Symbol == '^')
                    {
                        Instantiate(Resources.Load("Hero_Ranged"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
                    }
                    if (map.ArrUnit[i].Symbol == '&')
                    {
                        Instantiate(Resources.Load("Enemy_Ranged"), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos, -2), Quaternion.identity);
                        GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrUnit[i].Currenthealth, map.ArrUnit[i].Maxhealth)), new Vector3(map.ArrUnit[i].XPos, map.ArrUnit[i].YPos + 0.5f, -2), Quaternion.identity);
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
