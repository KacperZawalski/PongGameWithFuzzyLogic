using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class Button : Component
    {
        private Vector2 _textPosition
        {
            get
            {
                return new Vector2(Position.X + PaddingLeft, Position.Y + PaddingTop);
            }
        }

        public int PaddingTop { get; set; }
        public int PaddingLeft { get; set; }
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public Color TextColor { get; set; }
        public Color HoverColor { get; set; }

        public Button(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
            Font = font;
            Text = "";
            TextColor = Color.Black;
            PaddingTop = 0;
            PaddingLeft = 0;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawRectangle(spriteBatch);
            spriteBatch.DrawString(Font, Text, _textPosition, TextColor);
        }

        public override void Update(GameTime gameTime)
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
            Color = Color.White;
        }
        private void SetDefaultStyling()
        {
            Color = Color.Red;
        }
    }
}
