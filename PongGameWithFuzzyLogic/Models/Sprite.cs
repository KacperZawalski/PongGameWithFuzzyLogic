using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Sprite
    {
        protected Texture2D _texture;
        protected SpriteBatch _spriteBatch;
        public float Scale { get; set; }
        public Vector2 Position { get; set; }
        public Sprite(SpriteBatch spriteBatch, Texture2D texture)
        {
            Position = new Vector2(0, 0);
            Scale = 1;
            _spriteBatch = spriteBatch;
            _texture = texture;
        }
        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime);
    }
}
