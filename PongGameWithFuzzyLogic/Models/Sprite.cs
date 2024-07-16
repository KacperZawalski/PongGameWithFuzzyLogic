using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Sprite
    {
        protected Texture2D texture;
        public float Scale { get; set; }
        public Vector2 Position { get; set; }
        public Sprite(Texture2D texture)
        {
            Position = new Vector2(0, 0);
            Scale = 1;
            this.texture = texture;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
        public abstract void Update(GameTime gameTime);
    }
}
