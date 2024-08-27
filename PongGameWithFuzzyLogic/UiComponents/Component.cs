using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public abstract class Component
    {
        public Vector2 Position { get; set; }
        public Vector2 Dimensions { get; set; }
        public Color BorderColor { get; set; }
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                _colorCopy = value;
            }
        }
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                Position = new Vector2(Position.X + value, Position.Y + value);
                _borderWidth = value;

                _borderTexture = new Texture2D(_graphicsDevice, (int)Dimensions.X + value * 2, (int)Dimensions.Y + value * 2);
            }
        }
        protected Color _colorCopy;
        protected Texture2D _borderTexture;
        protected int _borderWidth;
        protected Color _color;
        protected Texture2D _texture;
        protected readonly GraphicsDevice _graphicsDevice;
        public Component(Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice)
        {
            Color = Color.White;
            Dimensions = dimensions;
            Position = position;
            _graphicsDevice = graphicsDevice;
            BorderColor = Color.Black;
            BorderWidth = 0;
        }
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime, SpriteBatch spriteBatch);

        protected void DrawRectangle(SpriteBatch spriteBatch)
        {
            if (_texture == null)
            {
                _texture = new Texture2D(_graphicsDevice, (int)Dimensions.X, (int)Dimensions.Y);
            }
            Color[] data = new Color[(int)Dimensions.X * (int)Dimensions.Y];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = _color;
            }
            _texture.SetData(data);
            spriteBatch.Draw(_texture, Position, _color);
        }
        protected void DrawBorder(SpriteBatch spriteBatch)
        {
            if (BorderWidth <= 0)
            {
                return;
            }

            Color[] data = new Color[_borderTexture.Width * _borderTexture.Height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = BorderColor;
            }
            _borderTexture.SetData(data);
            spriteBatch.Draw(_borderTexture, new Vector2(Position.X - _borderWidth, Position.Y - _borderWidth), BorderColor);
        }

    }
}
