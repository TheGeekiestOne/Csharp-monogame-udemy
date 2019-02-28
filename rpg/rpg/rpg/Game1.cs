﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpg
{
    enum Dir
    {
        Down,
        Up,
        Left,
        Right
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D player_Sprite;
        Texture2D playerDown;
        Texture2D playerUp;
        Texture2D playerLeft;
        Texture2D playerRight;

        Texture2D eyeEnemy_Sprite;
        Texture2D snakeEnemey_Sprite;
        Texture2D bush_Sprite;
        Texture2D tree_Sprite;

        Texture2D heart_Sprite;
        Texture2D bullet_Sprite;

        Player player = new Player();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

 
        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player_Sprite = Content.Load<Texture2D>("Player/player");
            playerDown = Content.Load<Texture2D>("Player/playerDown");
            playerUp = Content.Load<Texture2D>("Player/playerUp");
            playerLeft = Content.Load<Texture2D>("Player/playerLeft");
            playerRight = Content.Load<Texture2D>("Player/playerRight");

            eyeEnemy_Sprite = Content.Load<Texture2D>("Enemies/eyeEnemy");
            snakeEnemey_Sprite = Content.Load<Texture2D>("Enemies/snakeEnemy");

            bush_Sprite = Content.Load<Texture2D>("Obstacles/bush");
            tree_Sprite = Content.Load<Texture2D>("Obstacles/tree");

            heart_Sprite = Content.Load<Texture2D>("Misc/heart");
            bullet_Sprite = Content.Load<Texture2D>("Misc/bullet");

            //player.anim = new AnimatedSprite(playerDown, 1, 4);
            //AnimatedSprite walkDown = new AnimatedSprite(playerDown, 1, 4);
            //AnimatedSprite walkUp = new AnimatedSprite(playerUp, 1, 4);
            //AnimatedSprite walkLeft = new AnimatedSprite(playerLeft, 1, 4);
            //AnimatedSprite walkRight = new AnimatedSprite(playerRight, 1, 4);

            player.animations[0] = new AnimatedSprite(playerDown, 1, 4);
            player.animations[1] = new AnimatedSprite(playerUp, 1, 4);
            player.animations[2] = new AnimatedSprite(playerLeft, 1, 4);
            player.animations[3] = new AnimatedSprite(playerRight, 1, 4);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.ForestGreen);

            player.anim.Draw(spriteBatch, new Vector2(player.Position.X - 48, player.Position.Y - 48);

            spriteBatch.Begin();

            //spriteBatch.Draw(player_Sprite, player.Position, Color.White);


            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
