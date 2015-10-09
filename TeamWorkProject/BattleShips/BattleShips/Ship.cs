using System;

namespace GameClasses
{
    public class Battleship
    {
       
        public string rank;
        public int x;
        public int y;
        public int size;
        public char orientation;
        public int health;
        //added a specific character for each ship
        public char signature;

        public Battleship(string rank, int x, int y, int size, char orientation, char signature)
        {
            this.rank = rank;
            this.x = x;
            this.y = y;
            this.size = size;
            this.orientation = orientation;
            this.health = size;
            this.signature = signature;
        }

        public string Rank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }
        public int CurrentX
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int CurrentY
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public char Direction
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
            }
        }
        public int HealthLeft
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public char Signature
        {
            get
            {
                return signature;
            }
            set
            {
                signature = value;
            }
        }
    }
}
