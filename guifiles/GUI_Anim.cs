using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace guifiles
{
    //Sophia Baker, Group 12, GUI-centric code 3/22/17
    //anim class
    //animates dynamic objects
    class GUI_Anim : GUI_Graphics
    {
        //animation attributes
        private int frame; // current frame number
        private int timeSinceLastFrame; // elapsed time since frame was drawn
        private int millisecondsPerFrame; // millisec to display a frame

        //-constructor
        public GUI_Anim(Vector2 pPos, Texture2D img, Point pSpriteSize, int pNumSprites, int pRows, int pCols, int msPerFrame)
        {
            position = pPos;
            image = img;
            spriteSize = pSpriteSize;
            numSprites = pNumSprites;
            rows = pRows;
            cols = pCols;
            millisecondsPerFrame = msPerFrame;
            currentFrame.X = 0;
            currentFrame.Y = 0;
        }

        //methods
        //update
        public void Update(GameTime gameTime)
        {
            //time + animation
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0; //frame duration over
                frame++;

                // animation loop over
                if (frame >= numSprites)
                {
                    frame = 0; // restart
                }

                // set location of frame to display
                switch (frame)
                {
                    case 0:
                        currentFrame.X = 0;
                        currentFrame.Y = 0;
                        break;
                    case 1:
                        currentFrame.X = (spriteSize.X / rows) *1;
                        currentFrame.Y = (spriteSize.Y / cols) * 1;
                        break;
                    case 2:
                        currentFrame.X = (spriteSize.X / rows) *2;
                        currentFrame.Y = (spriteSize.Y / cols) * 2;
                        break;
                }
            }
        }

        //draw
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, new Rectangle(currentFrame.X, currentFrame.Y, (spriteSize.X / cols), (spriteSize.Y / rows)), // draws image based on given size and frame num
                Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1);


        }


    }
}
