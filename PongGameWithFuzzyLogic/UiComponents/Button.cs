using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class Button : Component
    {
        public new Color Color
        {
            get => _color;
            set
            {
                _color = value;
                _colorCopy = value;
            }
        }
        public int PaddingTop { get; set; }
        public int PaddingLeft { get; set; }
        public TextPosition TextPosition { get; set; }
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                _textColorCopy = value;
            }
        }
        public Color HoverColor { get; set; }
        public Color HoverTextColor { get; set; }
       
        private Color _textColorCopy;
        private Color _textColor;
        private Color _colorCopy;
        private Action _clickAction;


        private Vector2 _textPosition
        {
            get
            {
                return new Vector2(Position.X + PaddingLeft, Position.Y + PaddingTop);
            }
        }
        public Button(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
            TextPosition = TextPosition.Center;
            Font = font;
            Text = "";
            TextColor = Color.Black;
            PaddingTop = 0;
            PaddingLeft = 0;
            HoverColor = Color.DimGray;
            HoverTextColor = Color.LightGray;
            _colorCopy = Color;
            _textColorCopy = TextColor;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawBorder(spriteBatch);
            DrawRectangle(spriteBatch);
            DrawText(spriteBatch);
        }



        public override void Update(GameTime gameTime)
        {
            if (IsMouseHovering())
            {
                SetHoverStyling();
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    _clickAction?.Invoke();
                }
            }
            else
            {
                SetDefaultStyling();
            }
        }
        public void SetClickListener(Action action)
        {
            _clickAction = action;
        }
        private void DrawText(SpriteBatch spriteBatch)
        {
            Vector2 newTextPosition = TextPositionHelper.CalculateTextPosition(
                TextPosition,
                Font,
                Position,
                new Vector2(PaddingLeft, PaddingTop),
                Text,
                _texture);

            spriteBatch.DrawString(Font, Text, newTextPosition, _textColor);
        }

        private bool IsMouseHovering()
        {
            MouseState mouseState = Mouse.GetState();
            return Position.X < mouseState.X
                && Position.Y < mouseState.Y
                && Position.X + Dimensions.X > mouseState.X
                && Position.Y + Dimensions.Y > mouseState.Y;
        }
        private void SetHoverStyling()
        {
            _color = HoverColor;
            _textColor = HoverTextColor;
        }
        private void SetDefaultStyling()
        {
            _color = _colorCopy;
            _textColor = _textColorCopy;
        }
    }
}
