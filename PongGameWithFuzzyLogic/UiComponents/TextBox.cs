using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.UiComponents.Helpers;
using System;
using System.Linq;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class TextBox : TextComponent
    {
        public char CursorCharacter { get; set; } = '|';
        public bool CursorMissing { get; set; } = true;
        public int CursorPosition { get; set; }
        public bool Focused { get; set; }
        private bool _acceptInput;
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

            if (Focused)
            {
                if (CursorMissing)
                {
                    Text += CursorCharacter;
                    CursorPosition = Text.Length - 1;
                    CursorMissing = false;
                }
                var pressedKey = Keyboard.GetState().GetPressedKeys().FirstOrDefault();
                
                if (_acceptInput)
                {
                    new KeyboardInputHelper().HandleInput(this, pressedKey);
                    _acceptInput = false;
                }

                _acceptInput = Keyboard.GetState().IsKeyUp(pressedKey);
            }
            else
            {
                Text = Text.Replace(CursorCharacter.ToString(), string.Empty);
                CursorMissing = true;
            }
        }
    }
}
