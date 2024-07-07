using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public abstract class Component
    {
        public Vector2 Position { get; set; }
        public Vector2 Dimensions { get; set; }
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
            }
        }
        protected Color _color;
        protected Texture2D _texture;
        protected readonly GraphicsDevice _graphicsDevice;
        public Component(Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice)
        {
            Color = Color.White;
            Dimensions = dimensions;
            Position = position;
            _graphicsDevice = graphicsDevice;
            _texture = new Texture2D(_graphicsDevice, (int)Dimensions.X, (int)Dimensions.Y);
        }
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);

        public void DrawRectangle(SpriteBatch spriteBatch)
        {
            Color[] data = new Color[(int)Dimensions.X * (int)Dimensions.Y];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = _color;
            }
            _texture.SetData(data);
            spriteBatch.Draw(_texture, Position, _color);
        }

    }
}
