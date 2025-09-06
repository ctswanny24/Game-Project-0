using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

// Game Project 0 Requirements:
// At least 4 images rendered with spriteBatch
// At least 1 moving sprite
// Text rendered with a spriteFont COMPLETED
// Instructions on exiting the game using player input


namespace GameProject_0
{
    public class Game1 : Game
    {
        private string gameTitle = "Night Drive";

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D atlas;
        private Texture2D moonSprite;
        private Texture2D streetLampSprite;

        private Vector2 moonPosition;
        private Vector2 moonVelocity;

        private SpriteFont arial;
        private VehicleSprite vehicle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            moonPosition = new Vector2(0, 30);
            moonVelocity = new Vector2(.01f, 0);
            moonVelocity.Normalize();
            moonVelocity *= 100;
            vehicle = new VehicleSprite() {Position =  new Vector2(0, graphics.GraphicsDevice.Viewport.Height - 92), Direction = Direction.Right, restartLocation = new Vector2(-90, graphics.GraphicsDevice.Viewport.Height - 92), ScreenWidth =  graphics.GraphicsDevice.Viewport.Width };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            vehicle.LoadContent(Content);
            atlas = Content.Load<Texture2D>("colored_packed");
            arial = Content.Load<SpriteFont>("arial");
            moonSprite = Content.Load<Texture2D>("Moon");
            streetLampSprite = Content.Load<Texture2D>("Streetlamp");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            moonPosition += moonVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(moonPosition.X > graphics.GraphicsDevice.Viewport.Width)
            {
                moonPosition = new Vector2(-32, 30);
            }

            vehicle.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.DrawString(arial, $"{gameTitle}", new Vector2((graphics.GraphicsDevice.Viewport.Width - arial.MeasureString(gameTitle).X) / 2, 100), Color.Yellow);
            spriteBatch.DrawString(arial, $"Press 'Esc' key to exit the game", new Vector2((graphics.GraphicsDevice.Viewport.Width - arial.MeasureString("Press 'Esc' key to exit the game").X / 2) / 2,
                graphics.GraphicsDevice.Viewport.Height - 50), Color.PaleGoldenrod, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.0f);

            spriteBatch.Draw(moonSprite, moonPosition, Color.White);

            for(int x = 0; x < graphics.GraphicsDevice.Viewport.Width; x += 100)
            {
                spriteBatch.Draw(streetLampSprite, new Vector2(x, graphics.GraphicsDevice.Viewport.Height - 150), null, Color.White, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
            }

            spriteBatch.Draw(atlas, new Vector2(50, graphics.GraphicsDevice.Viewport.Height - 86), new Rectangle(35 * 16, 21 * 16, 16, 16), Color.White);
            spriteBatch.Draw(atlas, new Vector2(600, graphics.GraphicsDevice.Viewport.Height - 86), new Rectangle(36 * 16, 21 * 16, 16, 16), Color.White);
            spriteBatch.Draw(atlas, new Vector2(200, graphics.GraphicsDevice.Viewport.Height - 86), new Rectangle(37 * 16, 21 * 16, 16, 16), Color.White);



            vehicle.Draw(gameTime, spriteBatch);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

