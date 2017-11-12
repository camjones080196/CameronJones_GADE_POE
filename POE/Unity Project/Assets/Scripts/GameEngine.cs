using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEngine : MonoBehaviour
{


    //**************************************************************************************************************** Variables *************************************************************************************************************************************

    Map map = new Map();
    
    FactoryBuilding factory = new FactoryBuilding("None", 0, 0);
    Building tempBuilding = null;
    Unit tempEnemyUnit = null;
    Unit tempUnit;
    int move;
    int arraySize = 10;
    int GameTick = 1;
    int frameRate = 60;
    int UnitTotalDiff, buildingTotalDiff;
    bool gameOver, inUnitRange, inBuildingRange;


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

           

            if (map.ArrUnit[i] != null)
            {
                if (map.ArrUnit[i].AmDead(map.ArrUnit[i].Currenthealth) == true)
                {
                    map.ArrUnit[i] = null;
                }
                else
                {

                    Debug.Log("I am a " + map.ArrUnit[i].Faction + ", " + map.ArrUnit[i].Name + " unit at index " + i + " and my current health is " + map.ArrUnit[i].Currenthealth + ". My location is X: " + map.ArrUnit[i].XPos + ", Y: " + map.ArrUnit[i].YPos);

                    if (map.ArrUnit[i].Currenthealth < 25)
                    {
                        move = map.ArrUnit[i].RunAway();

                        switch (move)
                        {
                            case 1:
                                if (map.ArrUnit[i].XPos + 1 != 21)
                                {
                                    Debug.Log("I have run away.");
                                    map.ArrUnit[i].XPos = map.ArrUnit[i].XPos + 1;
                                    //map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos);
                                }
                                break;
                            case 2:
                                if (map.ArrUnit[i].XPos - 1 != -1)
                                {
                                    Debug.Log("I have run away.");
                                    map.ArrUnit[i].XPos = map.ArrUnit[i].XPos - 1;
                                    //map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos);
                                }
                                break;
                            case 3:
                                if (map.ArrUnit[i].YPos + 1 != 21)
                                {
                                    Debug.Log("I have run away.");
                                    map.ArrUnit[i].YPos = map.ArrUnit[i].YPos + 1;
                                    //map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos);
                                }
                                break;
                            case 4:
                                if (map.ArrUnit[i].YPos - 1 != -1)
                                {
                                    Debug.Log("I have run away.");
                                    map.ArrUnit[i].YPos = map.ArrUnit[i].YPos - 1;
                                    //map.UpdateUnit(map.ArrUnit[i], map.ArrUnit[i].XPos, map.ArrUnit[i].YPos);
                                }
                                break;
                        }
                    }

                    else
                    {
                        tempEnemyUnit = map.ArrUnit[i].CheckClosestUnit(map.ArrUnit, map.ArrUnit[i], tempEnemyUnit);
                        tempBuilding = map.ArrUnit[i].CheckClosestBuilding(map.ArrBuilding, map.ArrUnit[i], tempBuilding);
                        Debug.Log(tempEnemyUnit);
                        Debug.Log(tempBuilding);

                        if (tempEnemyUnit != null && tempEnemyUnit.AmDead(tempEnemyUnit.Currenthealth) != true)
                        {
                            Debug.Log("I am the closest Unit at X:" + tempEnemyUnit.XPos + ", Y: " + tempEnemyUnit.YPos);
                            UnitTotalDiff = Math.Abs((map.ArrUnit[i].XPos - tempEnemyUnit.XPos)) + Math.Abs((map.ArrUnit[i].YPos - tempEnemyUnit.YPos));
                        }
                        else
                        {
                            UnitTotalDiff = 600000000;
                            tempEnemyUnit = null;
                        }

                        if (tempBuilding != null && tempBuilding.AmDead(tempBuilding.HP) != true)
                        {
                            Debug.Log("I am the closest Building at X:" + tempBuilding.Xpos + ", Y: " + tempBuilding.Ypos);
                            buildingTotalDiff = Math.Abs((map.ArrUnit[i].XPos - tempBuilding.Xpos)) + Math.Abs((map.ArrUnit[i].YPos - tempBuilding.Ypos));
                        }
                        else
                        {
                            buildingTotalDiff = 600000000;
                            tempBuilding = null;
                        }

                        Debug.Log(UnitTotalDiff);
                        Debug.Log(buildingTotalDiff);

                        if (UnitTotalDiff <= buildingTotalDiff && tempEnemyUnit != null)
                        {
                          

                            if (map.ArrUnit[i].InCombat == true)
                            {
                                Debug.Log("I am still attacking a unit.");
                                map.ArrUnit[i].Combat(tempEnemyUnit);
                            }
                            else
                            {
                                inUnitRange = map.ArrUnit[i].CheckAttackRange(map.ArrUnit[i], tempEnemyUnit);

                                if (inUnitRange == true)
                                {
                                    Debug.Log("I am attacking a unit.");
                                    map.ArrUnit[i].InCombat = true;
                                    map.ArrUnit[i].Combat(tempEnemyUnit);
                                }
                                else if (GameTick % map.ArrUnit[i].Speed == 0)
                                {
                                    move = map.ArrUnit[i].Move(map.ArrUnit[i], tempEnemyUnit);

                                    switch (move)
                                    {
                                        case 1:
                                            Debug.Log("I have moved towards the Unit.");
                                            map.ArrUnit[i].XPos = map.ArrUnit[i].XPos - 1;
                                            break;
                                        case 2:
                                            Debug.Log("I have moved towards the Unit.");
                                            map.ArrUnit[i].XPos = map.ArrUnit[i].XPos + 1;
                                            break;
                                        case 3:
                                            Debug.Log("I have moved towards the Unit.");
                                            map.ArrUnit[i].YPos = map.ArrUnit[i].YPos - 1;
                                            break;
                                        case 4:
                                            Debug.Log("I have moved towards the Unit.");
                                            map.ArrUnit[i].YPos = map.ArrUnit[i].YPos + 1;
                                            break;
                                    }


                                }
                            }

                            if (tempEnemyUnit.AmDead(tempEnemyUnit.Currenthealth) == true)
                            {
                                map.ArrUnit[i].InCombat = false;
                            }

                        }
                        else if (tempBuilding != null)
                        {
                           if (map.ArrUnit[i].InCombat == true)
                           {
                                Debug.Log("I am still attacking a building.");
                                map.ArrUnit[i].BuildingCombat(tempBuilding);
                           }
                            else
                            {
                                inBuildingRange = map.ArrUnit[i].CheckBuildingRange(map.ArrUnit[i], tempBuilding);

                                if ( inBuildingRange == true)
                                {
                                    Debug.Log("I am attacking a building.");
                                    map.ArrUnit[i].InCombat = true;
                                    map.ArrUnit[i].BuildingCombat(tempBuilding);
                                }

                                else if (GameTick % map.ArrUnit[i].Speed == 0)
                                {
                                    move = map.ArrUnit[i].BuildingMove(map.ArrUnit[i], tempBuilding);

                                    switch (move)
                                    {
                                        case 1:
                                            Debug.Log("I have moved towards the building.");
                                            map.ArrUnit[i].XPos = map.ArrUnit[i].XPos - 1;
                                            break;
                                        case 2:
                                            Debug.Log("I have moved towards the building.");
                                            map.ArrUnit[i].XPos = map.ArrUnit[i].XPos + 1;
                                            break;
                                        case 3:
                                            Debug.Log("I have moved towards the building.");
                                            map.ArrUnit[i].YPos = map.ArrUnit[i].YPos - 1;
                                            break;
                                        case 4:
                                            Debug.Log("I have moved towards the building.");
                                            map.ArrUnit[i].YPos = map.ArrUnit[i].YPos + 1;
                                            break;
                                        case 5:
                                            break;
                                    }


                                }
                            }

                            if (tempBuilding.AmDead(tempBuilding.HP) == true)
                            {
                                map.ArrUnit[i].InCombat = false;
                            }

                        }
                    }

                }
            }

           
        
        }




        if (GameTick % factory.GameTicksPerProduction == 0)
        {
            System.Random r = new System.Random();
            int number = r.Next(1,10);

            if (number % 2 == 0 && map.ArrBuilding[0].HP > 0)
            {
                tempUnit = map.ArrBuilding[0].UnitSpawn(map.ArrBuilding[0].Faction);
            }
            else if(map.ArrBuilding[1].HP > 0)
            {
                tempUnit = map.ArrBuilding[1].UnitSpawn(map.ArrBuilding[1].Faction);
            }

            if (tempUnit != null)
            {
                Unit[] newarrUnit = new Unit[arraySize + 1];

                for (int i = 0; i < map.ArrUnit.Length; i++)
                {
                    newarrUnit[i] = map.ArrUnit[i];
                }

                newarrUnit[arraySize - 1] = tempUnit;

                arraySize++;

                map.ArrUnit = newarrUnit;

                Map.ArrMap[tempUnit.XPos, tempUnit.YPos] = tempUnit.Symbol;
            }
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

        

            if (map.ArrBuilding[0].AmDead(map.ArrBuilding[0].HP) == false)
            {
                Instantiate(Resources.Load("Factory_Building"), new Vector3(19, 19, -1), Quaternion.identity);
                GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrBuilding[0].HP, map.ArrBuilding[0].MaxHP)), new Vector3(19, 19 + 0.5f, -1), Quaternion.identity);
            }

            if (map.ArrBuilding[1].AmDead(map.ArrBuilding[1].HP) == false)
            {
                Instantiate(Resources.Load("Factory_Building"), new Vector3(0, 19, -1), Quaternion.identity);
                GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrBuilding[1].HP, map.ArrBuilding[1].MaxHP)), new Vector3(0, 19 + 0.5f, -1), Quaternion.identity);
            }

            if (map.ArrBuilding[2].AmDead(map.ArrBuilding[2].HP) == false)
            {
                Instantiate(Resources.Load("Resource_Building"), new Vector3(0, 0, -1), Quaternion.identity);
                GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrBuilding[2].HP, map.ArrBuilding[2].MaxHP)), new Vector3(0, 0 + 0.5f, -1), Quaternion.identity);
            }
            if (map.ArrBuilding[3].AmDead(map.ArrBuilding[3].HP) == false)
            {
                Instantiate(Resources.Load("Resource_Building"), new Vector3(19, 0, -1), Quaternion.identity);
                GameObject hp = (GameObject)Instantiate(Resources.Load(determineHP(map.ArrBuilding[3].HP, map.ArrBuilding[3].MaxHP)), new Vector3(19, 0 + 0.5f, -1), Quaternion.identity);
            }


            for (int i = 0; i < arraySize; i++)
            {
                if (map.ArrUnit[i] != null)
                {
                    if (map.ArrUnit[i].AmDead(map.ArrUnit[i].Currenthealth) == false)
                    {
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
                else
                {
                    Debug.Log("Destroyed");
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
