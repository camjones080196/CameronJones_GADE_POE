using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameronJones_GADE1B_A2
{
    class ResourceBuilding : Building
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        char resourceType;
        int resourcesPerGameTick;
        int resourcesRemaining = 50;
        int xPos, yPos;
        Random r = new Random();


        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

        public char ResourceType { get => resourceType; set => resourceType = value; }
        public int ResourcesPerGameTick { get => resourcesPerGameTick; set => resourcesPerGameTick = value; }
        public int ResourcesRemaining { get => resourcesRemaining; set => resourcesRemaining = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }

        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

        public ResourceBuilding()
        {
            XPos = 0;
            YPos = 0;
            Buildingsymbol = '#';
        }

        ~ResourceBuilding()
        {

        }

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public override string ToString()
        {
            return "Resource type: " + resourceType;
        }

        public void GenerateResource()
        {

            resourcesPerGameTick = r.Next(1, 3);
            resourcesRemaining = resourcesRemaining - resourcesPerGameTick;
        }
    }
}
