using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;


    class MeleeUnit : Unit
    {
        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

        public MeleeUnit(int x, int y, string fac, char sym) : base(100, 100, 1, 10, 1, "Melee")
        {
            XPos = x;
            YPos = y;
            Faction = fac;
            Symbol = sym;
        }

        public MeleeUnit(string name, int chealth, int attack, int attackrange, int speed)
        {
            Name = name;
            Currenthealth = chealth;
            Attack = attack;
            AttackRange = attackrange;
            Speed = speed;
        }

        ~MeleeUnit()
        {
            //code
        }

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public override bool AmDead(Unit currentUnit)
        {
            if (currentUnit.Currenthealth <= 0)
            {
                IsDead = true;
            }
            return IsDead;
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

        public override void Combat(Unit tempenemyUnit)
        {
            tempenemyUnit.Currenthealth = tempenemyUnit.Currenthealth - this.Attack;
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

            if (!File.Exists("Units/MeleeUnit.txt"))
            {
                File.Create("Units/MeleeUnit.txt").Close();
                Console.WriteLine("Created the file.");
            }
            else
            {
                Console.WriteLine("File exists.");
            }

            FileStream saveFile = new FileStream("Units/MeleeUnit.txt", FileMode.Open, FileAccess.Write);
            StreamWriter writer = new StreamWriter(saveFile);

            
                for (int k = 0; k < tempUnit.Length; k++)
                {
                    if (tempUnit[k].Name == "Melee")
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
            FileStream saveFile = new FileStream("Units/MeleeUnit.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(saveFile);

            if(saveFile.Length != 0)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] unit = line.Split(',');
                    MeleeUnit newMelee = new MeleeUnit(unit[0], Convert.ToInt32(unit[1]), Convert.ToInt32(unit[2]), Convert.ToInt32(unit[3]), Convert.ToInt32(unit[4]));
                    Console.WriteLine(newMelee.ToString());
                    line = reader.ReadLine();
                }

                Console.WriteLine("Data read.");
            }
        }
            
        public override string ToString()
        {
            return name + "," + currentHealth + "," + attack + "," + attackRange + "," + speed + "," + xPos + "," + yPos;
        }

    }

