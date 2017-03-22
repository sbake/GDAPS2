using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace guifiles
{
    //Sophia Baker, Group 12, GUI-centric code 3/22/17
    //Loads static images: map tiles. 
    class GUI_StatGraphics : GUI_Graphics
    {
        //attributes
        string mapPath;

        //constructor
        /// <summary>
        /// Static Objects constructor. Use 6th parameter for map.
        /// </summary>
        /// <param name="pImage">Sprite sheet</param>
        /// <param name="pSpriteSize">PixXPix size</param>
        /// <param name="pNumSprites">Total</param>
        /// <param name="pRows">Rows of sprites</param>
        /// <param name="pCols">Columns of sprites</param>
        public GUI_StatGraphics(Texture2D pImage, Point pSpriteSize, int pNumSprites, int pRows, int pCols, Vector2 pPos)
        {
            position = pPos;
            image = pImage; //graph parent class
            spriteSize = pSpriteSize;
            numSprites = pNumSprites;
            rows = pRows;
            cols = pCols;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pImage">Sprite sheet</param>
        /// <param name="pSpriteSize">PixXPix size</param>
        /// <param name="pNumSprites">Total</param>
        /// <param name="pRows">Rows of sprites</param>
        /// <param name="pCols">Columns of sprites</param>
        /// <param name="pMapPath">Path to map text file</param>
        public GUI_StatGraphics(Texture2D pImage, Point pSpriteSize, int pNumSprites, int pRows, int pCols, string pMapPath)
        {
            image = pImage; //graph parent class
            spriteSize = pSpriteSize;
            numSprites = pNumSprites;
            rows = pRows;
            cols = pCols;
            mapPath = pMapPath;
        }

        //methods
        /// <summary>
        /// Handles reading the map file and making an int array
        /// Use is no longer necesary if other parts of the program handle parsing the map file into an int array
        /// </summary>
        /// <returns>An int array</returns>
        public int[] MapArray() //this turns the text file into an int array- may delete later if another portion of he project handles this
        {
            //put map 
            //take file path and set up reader
            graphReader = new StreamReader(mapPath);
            
            //read map file to int[]
            int[] mapResult = new int[150]; //maps always 10x15
            //skip blank lines and save ints to int[]
            string line;
            int lineCount = 1;
            int inRowCount = 0;
            while ((line = graphReader.ReadLine()) != null)
            {
                lineCount++; //keep track of line number

                foreach (char c in line) //for each character
                {
                    inRowCount++; //in row number

                    int parsedInt = 10; //10 isn't an option, multiple chars
                    if (c != ' ') //don't handle spaces, they don't matter/shouldn't exist
                    {
                        parsedInt = (int)char.GetNumericValue(c);
                        mapResult[((((int)lineCount/2)-1) * 15) + (inRowCount-1)] = parsedInt;
                        
                    }
                    
                }

                //set row back to 0 after in row loop
                inRowCount = 0;
            }

            return mapResult;
        }

        /// <summary>
        /// Draws the map
        /// Uses MapArray()+MapTile()
        /// </summary>
        public void MapDraw(SpriteBatch spriteBatch)
        {
            //If MapArray is replaced with another int[] retrieval option in consolidating the programs, MapDraw() will need to either
            //a) take a int[] as a parameter
            //b) run the other method
            int[] mapInts = MapArray(); //run mapArray
            double pointFive = 0.5; //makes sure i converts to double when adding .5

            for (int i = 0; i < mapInts.Length; i++)
            {
                //coordinates on a 15x10 grid
                int Y = (int)((i + pointFive) / 15); //avoids dividing by 0 y adding .5, but keeps last column on correct row. back to int, drop decimal and get just row num
                int X = i - (Y * 15);
                //y 0-9
                //x 0-14

                MapTile(X, Y, mapInts[i], spriteBatch); //send each individual tile coordinate and type to MapTile
            }
        }

        /// <summary>
        /// Takes Coordinates and tile type and draws a 50x50 map tile
        /// </summary>
        /// <param name="x">X coordinate on 15x10 grid</param>
        /// <param name="y">Y coordinate on 15x10 grid</param>
        /// <param name="type">0-6</param>
        public void MapTile(int x, int y, int type, SpriteBatch spritebatch)
        {
            //50x150 spritesheet
            //0 bg default
            //1 tower
            //2 path start
            //3-5 path
            //6 path end
            //this changes what part of the file the sprite takes

            //consolidate textures
            if (type >= 2) //set this for math, may not be necesary in later iterations (with multiple tile textures)
            {
                type = 2;
            }
            //now type:
            //0 bg default
            //1 tower
            //2 path start

            //15x10 to 750x500
            position.X = (x * 50);
            position.Y = (y * 50);

            spritebatch.Draw(image, position, new Rectangle((type * 50), 0, 50, 50), Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

        }

        public void StaticImage(int layer, float size, SpriteBatch spritebatch)
        {
            spritebatch.Draw(image, position, new Rectangle(0, 0, spriteSize.X, spriteSize.Y), Color.White, 0, Vector2.Zero, size, SpriteEffects.None, layer);

        }

    }
}
