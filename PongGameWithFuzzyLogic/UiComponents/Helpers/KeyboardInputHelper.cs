using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.UiComponents.Interfaces;
using PongGameWithFuzzyLogic.UiComponents.Strategies;

namespace PongGameWithFuzzyLogic.UiComponents.Helpers
{
    public class KeyboardInputHelper
    {
        public void HandleInput(TextBox textBox, Keys pressedKey)
        {
            IKeyboardInputStrategy strategy;

            if (pressedKey == Keys.Back)
            {
                strategy = new KeyboardInputBackStrategy();
            }
            else if (pressedKey == Keys.Left)
            {
                strategy = new KeyboardInputLeftArrowStrategy();
            }
            else if (pressedKey == Keys.Right)
            {
                strategy = new KeyboardInputRightArrowStrategy();
            }
            else if (IsACharacter(pressedKey))
            {
                strategy = new KeyboardInputCharacterStrategy();
            }
            else if (IsANumber(pressedKey))
            {
                strategy = new KeyboardInputNumberStrategy();
            }
            else
            {
                strategy = new KeyboardWrongInputStrategy();
            }

            strategy.HandleInput(textBox, pressedKey);
        }
        private static bool IsACharacter(Keys pressedKey)
        {
            return pressedKey >= Keys.A && pressedKey <= Keys.Z;
        }
        private static bool IsANumber(Keys pressedKey)
        {
            return (pressedKey >= Keys.D0 && pressedKey <= Keys.D9) || (pressedKey >= Keys.NumPad0 && pressedKey <= Keys.NumPad9);
        }
    }
}
