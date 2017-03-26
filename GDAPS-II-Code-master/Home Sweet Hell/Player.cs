using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Sweet_Hell
{
    class Player
    {
        //attributes 
        private int health;
        private int points;

        //property
        public int Health
        {
            get { return health; }

            set
            {
                if (value > 0 && value < 100)
                {
                    health = value;
                }
            }
        }
        public int Points
        {
            get { return points; }

            set { points = value; }
        }

        //constructor 
        public Player()
        {
            health = 100;
            points = 0;
        }
    }
}
