using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameronJones_GADE1B_A2
{
    abstract class Building
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************
        private int xpos;
        private int ypos;
        private int health;
        private string faction;
        private char symbol;
        private char buildingSymbol;

        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

        protected int Xpos { get => xpos; set => xpos = value; }
        protected int Ypos { get => ypos; set => ypos = value; }
        protected int Health { get => health; set => health = value; }
        protected string Faction { get => faction; set => faction = value; }
        protected char Symbol { get => symbol; set => symbol = value; }
        public char Buildingsymbol { get => buildingSymbol; set => buildingSymbol = value; }

        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

        public Building()
        {
            //code
        }

        ~Building()
        {
            //code
        }

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public abstract override string ToString();
       

    }
}
