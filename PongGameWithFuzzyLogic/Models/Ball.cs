using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PongGameWithFuzzyLogic.Models
{
    public class Ball : Sprite
    {
        public Ball(SpriteBatch spriteBatch, Texture2D texture) : base(spriteBatch, texture)
        {
        }
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
