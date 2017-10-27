using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    class ResourceBuilding : Building
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        char resourceType;
        int resourcesPerGameTick;
        int resourcesRemaining = 50;
        int xPos, yPos;
        System.Random r = new System.Random();


        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

        public char ResourceType
        {
            get
            {
                return resourceType;
            }
            set
            {
                resourceType = value;
            }
        }
        public int ResourcesPerGameTick
        {
            get
            {
                return resourcesPerGameTick;
            }
            set
            {
                resourcesPerGameTick = value;
            }
        }
        public int ResourcesRemaining {
            get
            {
                return resourcesRemaining;
            }
            set
            {
                resourcesRemaining = value;
            }
        }
        public int XPos {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
            }
        }
        public int YPos {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
            }
        }

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

