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
        private Random random;

        private Texture2D texture;

        private double directionTimer;

        public Direction Direction;

        public Vector2 Position;

        public VehicleSprite()
        {
            random = new System.Random();
        }

        /// <summary>
        /// Loads the bat sprite texture
        /// </summary>
        /// <param name="content">The content manager to load</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("colored_packed");
        }

        /// <summary>
        /// Updates the bat sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime"> The game time </param>
        public void Update(GameTime gameTime)
        {
            //Update the direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(directionTimer > 3.5)
            {
                switch (Direction)
                {
                    case Direction.Up:
                        Direction = Direction.Right;
                        break;
                    case Direction.Right:
                        Direction = Direction.Down;
                        break;
                    case Direction.Down:
                        Direction = Direction.Left;
                        break;
                    case Direction.Left:
                        Direction = Direction.Up;
                        break;
                }
                directionTimer -= 3.5;
            }

            switch (Direction)
            {
                case Direction.Up:
                    Position += new Vector2(0, -1) * random.NextInt64(100, 600) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Down:
                    Position += new Vector2(0, 1) * random.NextInt64(100, 600) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Left:
                    Position += new Vector2(-1, 0) * random.NextInt64(100, 600) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * random.NextInt64(100, 600) * (float)gameTime.ElapsedGameTime.TotalSeconds;
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
            //Using a truck sprite if the random number is odd
            if(random.NextInt64() % 2 == 1)
            {
                spriteBatch.Draw(texture, Position, new Rectangle(192, 320, 32, 16), Color.Purple);
            }
            else
            {
                spriteBatch.Draw(texture, Position, new Rectangle(224, 336, 16, 16), Color.Crimson);
            }
        }
    }
}
