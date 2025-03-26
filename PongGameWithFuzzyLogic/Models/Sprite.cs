using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Sprite
    {
        public Texture2D Texture { get; internal set; }
        public float Scale { get; set; } = 1f;
        public Vector2 Position { get; set; }
        public Rectangle Rectangle => 
            new((int)Position.X, (int)Position.Y, (int)(Texture.Width * Scale), (int)(Texture.Height * Scale));
        protected Sprite(Texture2D texture)
        {
            Texture = texture;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
        public abstract void Update(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
