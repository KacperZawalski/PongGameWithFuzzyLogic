using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.UiComponents.Helpers;
using System;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class TextLabel : Component
    {
        public TextPosition TextPosition { get; set; }
        public SpriteFont Font { get; set; }
        public string Text { get; set; } = string.Empty;
        public int PaddingTop { get; set; }
        public int PaddingLeft { get; set; }
        public Color HoverColor { get; set; }
        public Color HoverTextColor { get; set; }
        public Color TextColor { get; set; }
        protected Action _clickAction;

        protected Vector2 _textPosition
        {
            get
            {
                return new Vector2(Position.X + PaddingLeft, Position.Y + PaddingTop);
            }
        }
        public TextLabel(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
            HoverColor = Color;
            HoverTextColor = TextColor;
            Font = font;
            TextPosition = TextPosition.Center;
            TextColor = Color.Black;
        }

        protected void DrawText(SpriteBatch spriteBatch, string text, Vector2 position, Color textColor)
        {
            Vector2 newTextPosition = TextPositionFactory.CalculateTextPosition(
                TextPosition,
                Font,
                position,
                new Vector2(PaddingLeft, PaddingTop),
                text,
                _texture);

            spriteBatch.DrawString(Font, text, newTextPosition, textColor);
        }
        public override void Update(GameTime gameTime, SpriteBatch spritebatch)
        {
            base.Update(gameTime, spritebatch);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawBorder(spriteBatch, Position, BorderColor);
            if (IsMouseHovering())
            {
                DrawRectangle(spriteBatch, Position, HoverColor);
                DrawText(spriteBatch, Text, Position, HoverTextColor);
            }
            else
            {
                DrawRectangle(spriteBatch, Position, Color);
                DrawText(spriteBatch, Text, Position, TextColor);
            }
        }
    }
}
