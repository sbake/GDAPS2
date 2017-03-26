using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Home_Sweet_Hell
{
    //Sophia Baker, Group 12, GUI-centric code 3/22/17
    //Parent class for StatGraphics and Anim
    //requires basic sprite unpacking classes, things both graphic classes need
    //all graphics classes inherit from
    class GUI_Graphics
    {
        //attributes, need image and reader
        protected Texture2D image;
        protected StreamReader graphReader;

        //all objects need position
        protected Vector2 position;
        //most files have multiple sprites, including static objects (map)
        protected Point spriteSize; // width and height of image
        protected int numSprites; // number of sprites on sheet
        protected int rows, cols; // sheet layout
        protected Point currentFrame; // location of current sprite

        //-constructor, graphics should never be called on it's own


        //methods
        //handles things like loading up sprite sheets/single sprites, but does not unpack sprites
    }
}
