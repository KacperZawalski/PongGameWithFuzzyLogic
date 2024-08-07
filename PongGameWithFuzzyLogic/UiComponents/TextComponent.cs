using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.UiComponents.Helpers;
using System;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public abstract class TextComponent : Component
    {
        public TextPosition TextPosition { get; set; }
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public int PaddingTop { get; set; }
        public int PaddingLeft { get; set; }
        public Color HoverColor { get; set; }
        public Color HoverTextColor { get; set; }
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                _textColorCopy = value;
            }
        }
        protected Action _clickAction;
        protected Color _textColorCopy;
        protected Color _textColor;

        protected Vector2 _textPosition
        {
            get
            {
                return new Vector2(Position.X + PaddingLeft, Position.Y + PaddingTop);
            }
        }
        protected TextComponent(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
            HoverColor = Color.DimGray;
            HoverTextColor = Color.LightGray;
            Font = font;
            TextPosition = TextPosition.Center;
            Text = "";
            TextColor = Color.Black;
            PaddingTop = 0;
            PaddingLeft = 0;
            _colorCopy = Color;
            _textColorCopy = TextColor;
        }

        protected void DrawText(SpriteBatch spriteBatch)
        {
            Vector2 newTextPosition = TextPositionFactory.CalculateTextPosition(
                TextPosition,
                Font,
                Position,
                new Vector2(PaddingLeft, PaddingTop),
                Text,
                _texture);

            spriteBatch.DrawString(Font, Text, newTextPosition, _textColor);
        }
        public override void Update(GameTime gameTime, SpriteBatch spritebatch)
        {
            if (IsMouseHovering())
            {
                SetHoverStyling();
            }
            else
            {
                SetDefaultStyling();
            }
        }
        protected bool IsMouseHovering()
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
