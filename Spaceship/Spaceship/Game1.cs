﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D ship_Sprite;
        Texture2D asteroid_Sprite;
        Texture2D space_Sprite;

        SpriteFont gameFont;
        SpriteFont timerFont;

        Ship player = new Ship();

        //test asteroid
        //Asteroid testAsteroid = new Asteroid(250);

        Controller gameController = new Controller();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Set Resolution
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

 
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

 
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            ship_Sprite = Content.Load<Texture2D>("ship");
            asteroid_Sprite = Content.Load<Texture2D>("asteroid");
            space_Sprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");
        }

 
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.shipUpdate(gameTime);
            //player.postition.X++;

            //testAsteroid.asteroidUpdate(gameTime);
            gameController.conUpdate(gameTime);
        
            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].asteroidUpdate(gameTime);

            }

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(space_Sprite, new Vector2(0, 0), Color.White) ;
            //spriteBatch.Draw(ship_Sprite, player.postition, Color.White);
            spriteBatch.Draw(ship_Sprite, new Vector2(player.postition.X - 34, player.postition.Y - 50), Color.White);

            //draw test asteroid
            //spriteBatch.Draw(asteroid_Sprite, new Vector2(testAsteroid.postion.X - testAsteroid.radius, testAsteroid.postion.Y - testAsteroid.radius), Color.White);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                Vector2 tempPos = gameController.asteroids[i].postion;
                int tempRadius = gameController.asteroids[i].radius;
                spriteBatch.Draw(asteroid_Sprite, new Vector2(tempPos.X - tempRadius, tempPos.Y - tempRadius), Color.White);

            }

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
