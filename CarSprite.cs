using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

    public class CarSprite
    {
        private Texture2D texture;

        private double directionTimer;

        public Direction Direction;

        //public Vector2 Position;

        /// <summary>
        /// Loads the bat sprite texture
        /// </summary>
        /// <param name="content">The content manager to load</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("32x32-bat-sprite");
        }

        /// <summary>
        /// Updates the bat sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime"> The game time </param>
        public void Update(GameTime gameTime)
        {
            //Update the direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

        }

        /// <summary>
        /// Draws the animated sprite
        /// </summary>
        /// <param name="gameTime"> The game time </param>
        /// <param name="spriteBatch"> The SpriteBatch to draw with </param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
    }
}
