using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Home_Sweet_Hell
{
    class Tile
    {
        //needed attributes
        Rectangle position;
        int tileValue;

        //constructor
        public Tile(int posX, int posY, int sizeX, int sizeY, int value)
        {
            position = new Rectangle(new Point(posX, posY), new Point(sizeX, sizeY));
            tileValue = value;
        }

        //properties
        public Rectangle Position
        {
            get { return position; }

            set { position = value; }
        }

        public int TileValue
        {
            get { return tileValue; }

            set { tileValue = value; }
        }
    }
}
