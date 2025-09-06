using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_0
{
    public enum Direction
    {
        Down = 0,
        Right = 1,
        Up = 2,
        Left,
    }

    public class VehicleSprite
    {

        private Texture2D texture;

        private double directionTimer;

        public Direction Direction;

        public Vector2 restartLocation;

        public Vector2 Position;
        
        public float ScreenWidth;

        /// <summary>
        /// Loads the bat sprite texture
        /// </summary>
        /// <param name="content">The content manager to load</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Car");
        }

        /// <summary>
        /// Updates the bat sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime"> The game time </param>
        public void Update(GameTime gameTime)
        {
            //Update the direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(Position.X > ScreenWidth)
            {
                Position = restartLocation;
            }

            switch (Direction)
            {
                case Direction.Up:
                    Position += new Vector2(0, -1) * 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Down:
                    Position += new Vector2(0, 1) * 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 200 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        /// <summary>
        /// Draws the animated sprite
        /// </summary>
        /// <param name="gameTime"> The game time </param>
        /// <param name="spriteBatch"> The SpriteBatch to draw with </param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Using a car sprite if the random number is odd
                spriteBatch.Draw(texture, Position, Color.Purple);
        }
    }
}
