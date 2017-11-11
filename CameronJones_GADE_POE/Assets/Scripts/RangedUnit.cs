using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;


    class RangedUnit : Unit
    {
        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

        public RangedUnit(int x, int y, string fac, char sym)
        {
            XPos = x;
            YPos = y;
            Faction = fac;
            Symbol = sym;
            Maxhealth = 100;
            Currenthealth = 100;
            Speed = 2;
            Attack = 5;
            AttackRange = 2;
            Name = "Ranged";
        }




    //**************************************************************************************************************** Methods *************************************************************************************************************************************

    public override bool AmDead(int HP)
    {
        bool dead;

        if (HP <= 0)
        {
            Debug.Log("I am dead.");
            dead = true;
        }
        else
        {
            Debug.Log("I am not dead.");
            dead = false;
        }

        return dead;
    }

    public override bool CheckAttackRange(Unit currentUnit, Unit tempenemyUnit)
    {
        bool Inrange = false;

        int xdiff, ydiff, total;

        xdiff = currentUnit.XPos - tempenemyUnit.XPos;
        ydiff = currentUnit.YPos - tempenemyUnit.YPos;

        total = Math.Abs(xdiff) + Math.Abs(ydiff);

            if (total <= 2)
            {
                Inrange = true;
                Debug.Log("I am in range of a unit.");
            }
            else
            {
                Inrange = false;
                Debug.Log("I am not in range of a unit.");
            }
        

        return Inrange;
    }

    public override bool CheckBuildingRange(Unit currentUnit, Building tempBuilding)
    {
        bool Inrange = false;


        int xdiff, ydiff, total;

        xdiff = currentUnit.XPos - tempBuilding.Xpos;
        ydiff = currentUnit.YPos - tempBuilding.Ypos;

        total = Math.Abs(xdiff) + Math.Abs(ydiff);

            if (total <= 2)
            {
                Inrange = true;
                Debug.Log("I am in range of a building.");
            }
            else
            {
                Inrange = false;
                Debug.Log("I am not in range of a building.");
            }
        

        return Inrange;
    }

    public override Unit CheckClosestUnit(Unit[] unitTemp, Unit currentUnit, Unit tempenemyunit)
    {
        int xdiff, ydiff, totalDiff, smaller = 1000000000;

        for (int i = 0; i < unitTemp.Length; i++)
        {
            if (unitTemp[i] != null && currentUnit.Faction != unitTemp[i].Faction)
            {
                xdiff = currentUnit.XPos - unitTemp[i].XPos;
                ydiff = currentUnit.YPos - unitTemp[i].YPos;
                totalDiff = Math.Abs(xdiff) + Math.Abs(ydiff);
                Debug.Log(totalDiff);
                if (totalDiff != 0)
                {
                    if (totalDiff < smaller)
                    {
                        tempenemyunit = unitTemp[i];
                        smaller = totalDiff;
                        Debug.Log("I am not your friend.");
                    }
                }
            }
            else
            {
                Debug.Log("I am your friend.");
            }

        }

       

        Debug.Log("Unit checking done.");
        return tempenemyunit;
    }

    public override Building CheckClosestBuilding(Building[] buildingTemp, Unit currentUnit, Building tempBuilding)
    {

        int xdiff, ydiff, totalDiff, smaller = 1000000000;

        for (int i = 0; i < buildingTemp.Length; i++)
        {
            if (buildingTemp[i] != null && currentUnit.Faction != buildingTemp[i].Faction)
            {
                xdiff = currentUnit.XPos - buildingTemp[i].Xpos;
                ydiff = currentUnit.YPos - buildingTemp[i].Ypos;
                totalDiff = Math.Abs(xdiff) + Math.Abs(ydiff);
                Debug.Log(totalDiff);
                if (totalDiff != 0)
                {
                    if (totalDiff < smaller)
                    {
                        tempBuilding = buildingTemp[i];
                        smaller = totalDiff;
                        Debug.Log("I am not your friend.");
                    }
                }
            }
            else
            {
                Debug.Log("I am your friend.");
            }

        }


        Debug.Log("Building checking done.");
        return tempBuilding;
    }

    public override void Combat(Unit tempenemyUnit)
    {
        tempenemyUnit.Currenthealth = tempenemyUnit.Currenthealth - this.Attack;
        Debug.Log("Unit attacked successfully");
    }

    public override void BuildingCombat(Building enemyBuilding)
    {
        enemyBuilding.HP = enemyBuilding.HP - this.Attack;
        Debug.Log("Building attacked successfully");
    }


    public override int Move(Unit currentUnit, Unit tempenemyUnit)
    {
        int xdiff, ydiff, move = 0;


        xdiff = currentUnit.XPos - tempenemyUnit.XPos;
        ydiff = currentUnit.YPos - tempenemyUnit.YPos;

        if (xdiff > ydiff)
        {
            if (xdiff > 0 && currentUnit.XPos - 1 != 0)
            {
                move = 1;
            }
            else if (currentUnit.XPos + 1 != 21)
            {
                move = 2;
            }
        }
        else
        {
            if (ydiff > 0 && currentUnit.YPos - 1 != 0)
            {
                move = 3;
            }
            else if (currentUnit.YPos + 1 != 21)
            {
                move = 4;
            }
        }


        return move;
    }

    public override int BuildingMove(Unit currentUnit, Building tempBuilding)
    {
        int xdiff, ydiff, move = 0;


        xdiff = currentUnit.XPos - tempBuilding.Xpos;
        ydiff = currentUnit.YPos - tempBuilding.Ypos;

        if (xdiff > ydiff)
        {
            if (xdiff > 0 && currentUnit.XPos - 1 != 0)
            {
                move = 1;
            }
            else if (currentUnit.XPos + 1 != 20)
            {
                move = 2;
            }
        }
        else
        {
            if (ydiff > 0 && currentUnit.YPos - 1 != 0)
            {
                move = 3;
            }
            else if (currentUnit.YPos + 1 != 20)
            {
                move = 4;
            }
        }


        return move;
    }

    public override int RunAway()
    {
        System.Random r = new System.Random();
        int move = r.Next(1, 4);
        return move;
    }

  


        public override string ToString()
        {
        return Name + "," + Currenthealth + "," + Attack + "," + AttackRange + "," + Speed + "," + XPos + "," + YPos;
    }
    }


