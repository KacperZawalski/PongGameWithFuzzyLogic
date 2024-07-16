using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class TextBox : TextComponent
    {
        private bool coursorMissing = true;

        public bool Focused { get; set; }
        public TextBox(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(font, dimensions, position, graphicsDevice)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawBorder(spriteBatch);
            DrawRectangle(spriteBatch);
            DrawText(spriteBatch);
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Update(gameTime, spriteBatch);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                _clickAction?.Invoke();
                Focused = IsMouseHovering();
            }
            if (Focused && coursorMissing)
            {
                DrawTextCursor(spriteBatch);
                coursorMissing = false;
            }
            else if (!Focused)
            {
                RemoveCoursor();
                coursorMissing = true;
            }
        }

        private void RemoveCoursor()
        {
            Text = Text.Trim('|');
        }

        private void DrawTextCursor(SpriteBatch spriteBatch)
        {
            Text += "|";
        }
    }
}
