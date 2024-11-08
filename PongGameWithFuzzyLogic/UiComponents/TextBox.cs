using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.UiComponents.Helpers;
using System;
using System.Linq;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class TextBox : TextLabel
    {
        public char CursorCharacter { get; set; } = '|';
        public bool CursorMissing { get; set; } = true;
        public int CursorPosition { get; set; }

        public bool Focused { get; set; }
        private Action _textChangedAction;
        private bool _acceptInput;

        public TextBox(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(font, dimensions, position, graphicsDevice)
        {
        }
        public void SetTextChangeAction(Action action)
        {
            _textChangedAction = action;
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            HandleMouseInput();

            if (Focused)
            {
                UpdateCursorState();
                HandleKeyboardInput();
            }
            else
            {
                RemoveCursor();
            }
            base.Update(gameTime, spriteBatch);
        }

        private void HandleMouseInput()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                _clickAction?.Invoke();
                Focused = IsMouseHovering();
            }
        }

        private void UpdateCursorState()
        {
            if (CursorMissing)
            {
                Text += CursorCharacter;
                CursorPosition = Text.Length - 1;
                CursorMissing = false;
            }
        }

        private void HandleKeyboardInput()
        {
            var keyboardState = Keyboard.GetState();
            var pressedKey = keyboardState.GetPressedKeys().FirstOrDefault();

            if (_acceptInput && pressedKey != Keys.None)
            {
                var oldText = Text;
                new KeyboardInputHelper().HandleInput(this, pressedKey);

                if (oldText != Text)
                {
                    _textChangedAction?.Invoke();
                }

                _acceptInput = false;
            }

            _acceptInput = keyboardState.IsKeyUp(pressedKey);
        }

        private void RemoveCursor()
        {
            Text = Text.Replace(CursorCharacter.ToString(), string.Empty);
            CursorMissing = true;
        }
    }
}
