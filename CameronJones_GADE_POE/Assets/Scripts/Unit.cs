using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    abstract class Unit
    {
        //**************************************************************************************************************** Variables *************************************************************************************************************************************

        protected string name = "";
        protected int xPos = 0;
        protected int yPos = 0;
        protected int maxHealth = 100;
        protected int currentHealth = 0;
        protected int speed = 0;
        protected int attack = 0;
        protected int attackRange = 0;
        protected string faction = "";
        protected char symbol = '^';
        protected bool inCombat = false;
        protected bool inRange = false;
        protected bool isDead = false;

        //**************************************************************************************************************** G&S's *************************************************************************************************************************************

    public virtual int XPos
    {
        get
        {
            return xPos;
        }
        set
        {
            xPos = value;
        }
    }
    public virtual int YPos
    {
        get
        {
            return yPos;
        }
        set
        {
            yPos = value;
        }
    }
    public virtual int Maxhealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }
    public virtual int Currenthealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }
    public virtual int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public virtual int Attack
    {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
    }
    public virtual int AttackRange
    {
        get
        {
            return attackRange;
        }
        set
        {
            attackRange = value;
        }
    }
    public virtual string Faction
    {
        get
        {
            return faction;
        }
        set
        {
            faction = value;
        }
    }
        public virtual char Symbol
    {
        get
        {
            return symbol;
        }
        set
        {
            symbol = value;
        }
    }
    public virtual bool InCombat
    {
        get
        {
            return inCombat;
        }
        set
        {
            inCombat = value;
        }
    }
    public virtual bool InRange
    {
        get
        {
            return inRange;
        }

        set
        {
            inRange = value;
        }
    }
    public virtual string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    public virtual bool IsDead
    {
        get
        {
            return isDead;
        }

        set
        {
            isDead = value;
        }
    }
       

        //**************************************************************************************************************** Constructor & Destructor *************************************************************************************************************************************

        public Unit(int maxhealth, int currenthealth, int speed, int attack, int attackRange, string name)
        {
            this.Currenthealth = currenthealth;
            this.Speed = speed;
            this.Attack = attack;
            this.AttackRange = attackRange;
            this.Name = name;
        }

        public Unit()
        {
           
        }

        ~Unit()
        {
            //code
        }

        //**************************************************************************************************************** Methods *************************************************************************************************************************************

        public abstract int Move(Unit currentUnit, Unit tempenemyUnit);
        public abstract void Combat(Unit tempenemyUnit);
        public abstract bool CheckAttackRange(Unit currentUnit, Unit tempenemyUnit);
        public abstract Unit CheckClosestUnit(Unit[] unitTemp, Unit currentUnit, Unit tempenemyunit);
        public abstract int RunAway();
        public abstract bool AmDead(Unit currentUnit);
        public abstract void SaveUnit(Unit[] tempUnit);
        public abstract void ReadUnit();
        public abstract override string ToString();
    }
    

