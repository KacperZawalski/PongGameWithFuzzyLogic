using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public abstract class Component
    {
        public bool Display { get; set; } = true;
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
        protected bool Clicked = false;
        protected bool LMBPressed = false;
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
        public virtual void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Clicked = false;
            if (!LMBPressed && IsMouseHovering() && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                LMBPressed = true;
            }
            else if (LMBPressed && Mouse.GetState().LeftButton == ButtonState.Released && IsMouseHovering())
            {
                LMBPressed = false;
                Clicked = true;
            }
        }

        protected void DrawRectangle(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            if (_texture == null)
            {
                _texture = new Texture2D(_graphicsDevice, (int)Dimensions.X, (int)Dimensions.Y);
            }
            Color[] data = new Color[(int)Dimensions.X * (int)Dimensions.Y];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = color;
            }
            _texture.SetData(data);
            spriteBatch.Draw(_texture, position, color);
        }
        protected void DrawBorder(SpriteBatch spriteBatch, Vector2 position, Color borderColor)
        {
            if (BorderWidth <= 0)
            {
                return;
            }

            Color[] data = new Color[_borderTexture.Width * _borderTexture.Height];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = borderColor;
            }
            _borderTexture.SetData(data);
            spriteBatch.Draw(_borderTexture, new Vector2(position.X - _borderWidth, position.Y - _borderWidth), borderColor);
        }
        protected bool IsMouseHovering()
        {
            MouseState mouseState = Mouse.GetState();
            return Position.X < mouseState.X
                && Position.Y < mouseState.Y
                && Position.X + Dimensions.X > mouseState.X
                && Position.Y + Dimensions.Y > mouseState.Y;
        }
    }
}
