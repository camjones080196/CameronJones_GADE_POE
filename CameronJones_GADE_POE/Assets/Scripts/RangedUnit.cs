using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;


    class RangedUnit : Unit
    {
        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

        public RangedUnit(int x, int y, string fac, char sym) : base(100, 100, 2, 5, 2, "Ranged")
        {
            XPos = x;
            YPos = y;
            Faction = fac;
            Symbol = sym;
        }

        public RangedUnit(string name, int chealth, int attack, int attackrange, int speed)
        {
            Name = name;
            Currenthealth = chealth;
            Attack = attack;
            AttackRange = attackrange;
            Speed = speed;
        }

        ~RangedUnit()
        {
            //code
        }

    //**************************************************************************************************************** Methods *************************************************************************************************************************************

    public override bool AmDead(Unit currentUnit)
    {
        if (currentUnit.Currenthealth <= 0)
        {
            currentUnit.IsDead = true;
        }
        else
        {
            currentUnit.IsDead = false;
        }

        return currentUnit.IsDead;
    }

    public override bool CheckAttackRange(Unit currentUnit, Unit tempenemyUnit)
    {
        if (currentUnit != null && tempenemyUnit != null)
        {
            int xdiff, ydiff, bigger;

            xdiff = currentUnit.XPos - tempenemyUnit.XPos;
            ydiff = currentUnit.YPos - tempenemyUnit.YPos;

            if (Math.Abs(xdiff) > Math.Abs(ydiff))
            {
                bigger = Math.Abs(xdiff);
                if (bigger <= 1)
                {
                    currentUnit.InRange = true;
                }
                else
                {
                    currentUnit.InRange = false;
                }
            }
        }
        return currentUnit.InRange;
    }

    public override bool CheckBuildingRange(Unit currentUnit, Building tempBuilding)
    {
        if (currentUnit != null && tempBuilding != null)
        {
            int xdiff, ydiff, bigger;

            xdiff = currentUnit.XPos - tempBuilding.Xpos;
            ydiff = currentUnit.YPos - tempBuilding.Ypos;

            if (Math.Abs(xdiff) > Math.Abs(ydiff))
            {
                bigger = Math.Abs(xdiff);
                if (bigger <= 1)
                {
                    currentUnit.InRange = true;
                }
                else
                {
                    currentUnit.InRange = false;
                }
            }
        }
        return currentUnit.InRange;
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
                    if (totalDiff != 0)
                    {
                        if (totalDiff < smaller)
                        {
                            tempenemyunit = unitTemp[i];
                            smaller = totalDiff;
                        }
                    }
                }

            }

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
                if (totalDiff != 0)
                {
                    if (totalDiff < smaller)
                    {
                        tempBuilding = buildingTemp[i];
                        smaller = totalDiff;
                    }
                }
            }

        }

        return tempBuilding;
    }

    public override void Combat(Unit tempenemyUnit)
        {
            tempenemyUnit.Currenthealth = tempenemyUnit.Currenthealth - this.Attack;
        }

    public override void BuildingCombat(Building enemyBuilding)
    {
        enemyBuilding.HP = enemyBuilding.HP - this.Attack;
    }

    public override int Move(Unit currentUnit, Unit tempenemyUnit)
        {
        int xdiff, ydiff, move = 0;

        if (currentUnit != null && tempenemyUnit != null)
        {
            

            xdiff = currentUnit.XPos - tempenemyUnit.XPos;
            ydiff = currentUnit.YPos - tempenemyUnit.YPos;

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
                else
                {
                    move = 5;
                }
            }
        }

            return move;
        }

    public override int BuildingMove(Unit currentUnit, Building tempBuilding)
    {
        int xdiff, ydiff, move = 0;

        if (currentUnit != null && tempBuilding != null)
        {


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
                else
                {
                    move = 5;
                }
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

        public override void SaveUnit(Unit[] tempUnit)
        {
            if (!Directory.Exists("Units"))
            {
                Directory.CreateDirectory("Units");
                Console.WriteLine("Created the directory.");
            }

            if (!File.Exists("Units/RangedUnit.txt"))
            {
                File.Create("Units/RangedUnit.txt").Close();
                Console.WriteLine("Created the file.");
            }
            else
            {
                Console.WriteLine("File exists.");
            }

            FileStream saveFile = new FileStream("Units/RangedUnit.txt", FileMode.Open, FileAccess.Write);
            StreamWriter writer = new StreamWriter(saveFile);

            
             
                for (int k = 0; k < tempUnit.Length; k++)
                {
                    if (tempUnit[k].Name == "Ranged")
                    {
                        writer.WriteLine(tempUnit[k].ToString());
                    }
                }

                Console.WriteLine("Data written.");
               
            

            writer.Close();
            saveFile.Close();
        }

        public override void ReadUnit()
        {
            FileStream saveFile = new FileStream("Units/RangedUnit.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(saveFile);

            if (saveFile.Length != 0)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] unit = line.Split(',');
                    RangedUnit newRanged = new RangedUnit(unit[0], Convert.ToInt32(unit[1]), Convert.ToInt32(unit[2]), Convert.ToInt32(unit[3]), Convert.ToInt32(unit[4]));
                    Console.WriteLine(newRanged.ToString());
                    line = reader.ReadLine();
                }

                Console.WriteLine("Data read.");
            }
        }


        public override string ToString()
        {
        return Name + "," + Currenthealth + "," + Attack + "," + AttackRange + "," + Speed + "," + XPos + "," + YPos;
    }
    }


