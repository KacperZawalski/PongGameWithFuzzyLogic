using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Sprite
    {
        public Texture2D Texture { get; internal set; }
        public float Scale { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin
        {
            get
            {
                return new Vector2(Texture.Width / 2, Texture.Height / 2);
            }
        }
        public Sprite(Texture2D texture)
        {
            Rotation = 0;
            Scale = 1;
            Texture = texture;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0);
        }
        public abstract void Update(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
