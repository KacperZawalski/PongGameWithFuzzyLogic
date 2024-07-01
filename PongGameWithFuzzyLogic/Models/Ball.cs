using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PongGameWithFuzzyLogic.Models
{
    public class Ball : Sprite
    {
        public Ball(SpriteBatch spriteBatch, Texture2D texture) : base(spriteBatch, texture)
        {
            Scale = 0.3f;

        }
        public override void Update(GameTime gameTime)
        {
        }
    }
}
