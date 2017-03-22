using guifiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace guifiles
{
    //Sophia Baker, Group 12, GUI-centric code 3/22/17
    //GUI content is blocked into green boxes


    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //GUI content------------------------------
        SpriteFont font;
        private GUI_StatGraphics map;
        private GUI_Anim tower;
        private GUI_Anim enemy;
        private GUI_StatGraphics listing1;
        private GUI_StatGraphics listing2;
        private GUI_StatGraphics listing3;
        private GUI_StatGraphics storeBack;
        //GUI content------------------------------

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            //just making wondow generally wider, this should be deleted in final
            graphics.PreferredBackBufferWidth = 1050;                    //
            graphics.PreferredBackBufferHeight = 750;                    //
            graphics.ApplyChanges();                                     //
            //-------------------------------------------------------------
        }

        

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {   
                                                                                         
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //GUI content----------------------------------------------------------------------------------//
            //font
            font = Content.Load<SpriteFont>("Arial"); //TEMP FONT

            //map                                                                                          //
            Texture2D mapImage = Content.Load<Texture2D>("GUI_Assets/mapassets3type.png");                 //
            map = new GUI_StatGraphics(mapImage, new Point(150, 50), 3, 1, 3, "ExampleMap1.txt");          //
                                                                                                           //
            //tower                                                                                        //
            Texture2D towerImage = Content.Load<Texture2D>("GUI_Assets/towerplaceholder");                 //
            //tower position vector should be tower position property from tower class                     //
            tower = new GUI_Anim(new Vector2(100, 100) ,towerImage, new Point(150, 50), 3, 1, 3, 500);     //
                                                                                                           //
            //enemy                                                                                        //
            Texture2D enemyImage = Content.Load<Texture2D>("GUI_Assets/enemyplaceholder");                 //
            //enemy position vector should be enemy position property from enemy class                     //
            enemy = new GUI_Anim(new Vector2(150, 350), enemyImage, new Point(150, 50), 3, 1, 3, 500);     //
            
            
            //listing                                                                                     //
            Texture2D listingImage = Content.Load<Texture2D>("GUI_Assets/storelistingplaceholder");        //
            listing1 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(450, 500)); //   
            listing2 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(550, 500)); //  
            listing3 = new GUI_StatGraphics(listingImage, new Point(150, 150), 1, 1, 1, new Vector2(650, 500)); //           
            //store                                                                                        //
            Texture2D backStoreImage = Content.Load<Texture2D>("GUI_Assets/storebackplaceholder");         //
            storeBack = new GUI_StatGraphics(backStoreImage, new Point(750, 100), 1, 1, 1, new Vector2(0, 500));//

            //GUI content----------------------------------------------------------------------------------//
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //GUI content=========================================================================================//
            spriteBatch.Begin();                                                                                  //
            //map drawing                                                                                         //
            map.MapDraw(spriteBatch);                                                                             //
            //enemies+towers drawing                                                                              //
            tower.Draw(gameTime, spriteBatch);                                                                    //
            enemy.Draw(gameTime, spriteBatch);                                                                    //
                                                                                                                  //
            //storedrawing                                                                                        //
            storeBack.StaticImage(0, 1f, spriteBatch);                                                            //
            listing1.StaticImage(1, .66f, spriteBatch);                                                           //
            listing2.StaticImage(1, .66f, spriteBatch);                                                           //
            listing3.StaticImage(1, .66f, spriteBatch);                                                           //
                                                                                                                  //
            //TEMPORARY Writing                                                                                   //
            //not aesthetically pleasing, but communicates the idea. Will need to replace later on.               //
            spriteBatch.DrawString(font, "Tower Name \n Price: " + 200, //replace with price variable later       //
                new Vector2(465, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);               //
            spriteBatch.DrawString(font, "Tower Name \n Price: " + 150, //replace with price variable later       //
                new Vector2(565, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);               //
            spriteBatch.DrawString(font, "Tower Name \n Price: " + 100, //replace with price variable later       //
                new Vector2(665, 515), Color.Black, 0, Vector2.Zero, 0.45f, SpriteEffects.None, 1);               //
                                                                                                                  //
            spriteBatch.DrawString(font, "Level: " + 1, //replace with level ver at some point                    //
                new Vector2(665, 15), Color.White, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);                 //
            spriteBatch.DrawString(font, "Funds available: " + 500, //replace with money variable later           //
                new Vector2(10, 510), Color.Black, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);                 //
            spriteBatch.DrawString(font, "Score: " + 700, //replace with score variable                           //
                new Vector2(10, 535), Color.Black, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);                 //
                                                                                                                  //
            spriteBatch.End();                                                                                    //
            //GUI content=========================================================================================//

            base.Draw(gameTime);
        }
    }
}
