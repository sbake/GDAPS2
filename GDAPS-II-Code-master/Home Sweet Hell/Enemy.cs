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
    class Enemy
    {
        //enemy attributes to inherit
        private int health;
        private int speed;
        private int sizeX;
        private int sizeY;
        private int positionX;
        private int positionY;
        private Rectangle position;
        private bool alive;
        private Texture2D image;
        private int score;

        //properties for attributes
        public int Health
        {
            get { return health; }

            set
            {
                if (value < health && value > 0)
                {
                    health = value;
                }
            }
        }

        public int Speed
        {
            get { return speed; }

            set { speed = value; }
        }

        public int SizeX
        {
            get { return sizeX; }
        }

        public int SizeY
        {
            get { return sizeY; }
        }

        public int PositionX
        {
            get { return positionX; }

            set { positionX = value; }
        }

        public int PositionY
        {
            get { return positionY; }

            set { positionY = value; }
        }

        public Rectangle Position
        {
            get { return position; }

            set { position = value; }
        }

        public int Score
        {
            get { return score; }
        }

        public bool Alive
        {
            get { return alive; }

            set { alive = value; }
        }
        //constructor
        public Enemy(int hp, int sp, int w, int h, int x, int y,int scr)
        {
            health = hp;
            speed = sp;
            sizeX = w;
            sizeY = h;
            positionX = x;
            positionY = y;
            position = new Rectangle(new Point(x, y), new Point(w, h));
            alive = true;
            score = scr;
        }

        //take damage method
        public void TakeDamage(int dmg, Player p1)
        {
            int finalHealth = health - dmg;
            if (finalHealth > 0)
            {
                health = finalHealth;
            }
            else if (finalHealth <= 0)
            {
                alive = false;
                p1.Points = p1.Points + score;
            }

        }

        //override draw method so it only draws alive enemies
        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive == true)
            {
                spriteBatch.Draw(image);
            }
            else if (alive == false)
            {

            }
        }

        public void Move(Tile[,] map, int[,] tiles)//method to cause enemies to move toward the base
        {

            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int column = 0; column < tiles.GetLength(1); column++)
                {
                        if (position.Intersects(map[row, column].Position) == true)
                        {
                        if (map[row, column].TileValue == 2)
                        {
                            if (map[map[row, column].Position.X - 50, map[row, column].Position.Y].TileValue == 3)//checks 1 tile to the right for the next path
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X + 50, map[row, column].Position.Y].TileValue == 3)//checks 1 tile to the left
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 3)//checks 1 tile up
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 3)//checks 1 tile down
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                        }
                        else if (map[row, column].TileValue == 3)
                        {
                            if (map[map[row, column].Position.X - 50, map[row, column].Position.Y].TileValue == 4)//checks 1 tile to the right for the next path
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X + 50, map[row, column].Position.Y].TileValue == 4)//checks 1 tile to the left
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 4)//checks 1 tile up
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 4)//checks 1 tile down
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                        }
                        else if (map[row, column].TileValue == 4)
                        {
                            if (map[map[row, column].Position.X - 50, map[row, column].Position.Y].TileValue == 5)//checks 1 tile to the right for the next path
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X + 50, map[row, column].Position.Y].TileValue == 5)//checks 1 tile to the left
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 5)//checks 1 tile up
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 5)//checks 1 tile down
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                        }
                        else if (map[row, column].TileValue == 5)
                        {
                            if (map[map[row, column].Position.X - 50, map[row, column].Position.Y].TileValue == 6)//checks 1 tile to the right for the next path
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X + 50, map[row, column].Position.Y].TileValue == 6)//checks 1 tile to the left
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 6)//checks 1 tile up
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                            else if (map[map[row, column].Position.X, map[row, column].Position.Y + 50].TileValue == 6)//checks 1 tile down
                            {
                                position = new Rectangle(new Point(map[row, column].Position.X, map[row, column].Position.Y), new Point(sizeX, sizeY));
                            }
                        }
                    }
                }
            }
        }

        public void Breach(Player p1,Tile[,] map, int[,] tiles)//if the enemy isn't killed in time it damages the player
        {
            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int column = 0; column < tiles.GetLength(1); column++)
                {
                    if (position.Intersects(map[row, column].Position) == true)
                    {
                        if (map[row, column].TileValue == 6)
                        {
                            alive = false;
                            p1.Health = p1.Health - 1;

                        }
                    }
                }
            }
        }
    }
}
