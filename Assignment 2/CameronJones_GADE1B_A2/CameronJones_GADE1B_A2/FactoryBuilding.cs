using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameronJones_GADE1B_A2
{
    class FactoryBuilding : Building
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        int unitsToProduce = 10;
        int gameTicksPerProduction = 5;
        int spawnX, spawnY;
        int xPos, yPos;
        Unit addUnit;
        Random random = new Random();

        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

        public int UnitsToProduce { get => unitsToProduce; set => unitsToProduce = value; }
        public int GameTicksPerProduction { get => gameTicksPerProduction; set => gameTicksPerProduction = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public int SpawnX { get => spawnX; set => spawnX = value; }
        public int SpawnY { get => spawnY; set => spawnY = value; }

        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

        public FactoryBuilding()
        {
            XPos = 20;
            YPos = 20;
            Buildingsymbol = '@';
        }

        ~FactoryBuilding()
        {

        }

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public override string ToString()
        {
            return Xpos + ", " + Ypos + ", " + Health + ", " + Faction + ", " + Symbol;
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
                            Symbol = 'M';
                        }

                        if (number2 % 2 != 0)
                        {
                            Faction = "Enemy";
                            Symbol = 'm';
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
                            Symbol = 'R';
                        }

                        if (number2 % 2 != 0)
                        {
                            Faction = "Enemy";
                            Symbol = 'r';
                        }

                        addUnit = new RangedUnit(spawnX, spawnY, Faction, Symbol);
                    }
            }

            unitsToProduce--;
            return addUnit;

        }

    }
}
