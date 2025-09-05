using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Game Project 0 Requirements:
// At least 4 images rendered with spriteBatch
// At least 1 moving sprite
// Text rendered with a spriteFont COMPLETED
// Instructions on exiting the game using player input


namespace GameProject_0
{
    public class Game1 : Game
    {
        private string _sillyMessage = "WOW, look at that timer go!!!";

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D atlas;

        private Texture2D _movingSpriteTexture;
        private Vector2 _movingSpritePosition;
        private Vector2 _movingSpriteVelocity;

        private SpriteFont _arial;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _movingSpritePosition = new Vector2((_graphics.GraphicsDevice.Viewport.Width - 16) / 2, (_graphics.GraphicsDevice.Viewport.Height - 16) / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            atlas = Content.Load<Texture2D>("colored_packed");
            _arial = Content.Load<SpriteFont>("arial");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleVioletRed);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_arial, $"You have been playing my game for {gameTime.TotalGameTime.TotalSeconds:f} seconds", new Vector2(2, 2), Color.Beige);
            if(gameTime.TotalGameTime.TotalSeconds > 10.0)
            {
                _spriteBatch.DrawString(_arial, $"{_sillyMessage}",
                    new Vector2((_graphics.GraphicsDevice.Viewport.Width - _arial.MeasureString(_sillyMessage).X) / 2,
                        (_graphics.GraphicsDevice.Viewport.Height - _arial.MeasureString(_sillyMessage).Y) / 2),
                    Color.Black);
            }
            _spriteBatch.Draw(atlas, new Vector2(2, (_graphics.GraphicsDevice.Viewport.Height - 16) / 2), new Rectangle(192, 320, 32, 16), Color.Purple, 
                0, Vector2.Zero, new Vector2(2.0f, 2.0f), SpriteEffects.None, 0.0f);
            
            _spriteBatch.Draw(atlas, _movingSpritePosition, new Rectangle(400, 112, 16, 16), Color.Purple,
                0, Vector2.Zero, new Vector2(2.0f, 2.0f), SpriteEffects.None, 0.0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

