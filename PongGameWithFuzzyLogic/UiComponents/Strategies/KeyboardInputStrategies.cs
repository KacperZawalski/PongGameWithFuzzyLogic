using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.UiComponents.Interfaces;
using System.Linq;

namespace PongGameWithFuzzyLogic.UiComponents.Strategies
{
    public class KeyboardInputCharacterStrategy : IKeyboardInputStrategy
    {
        public void HandleInput(TextBox textBox, Keys pressedKey)
        {
            textBox.Text = textBox.Text.Insert(textBox.CursorPosition, pressedKey.ToString());
            textBox.CursorPosition++;
        }
    }
    public class KeyboardInputNumberStrategy : IKeyboardInputStrategy
    {
        public void HandleInput(TextBox textBox, Keys pressedKey)
        {
            textBox.Text = textBox.Text.Insert(textBox.CursorPosition, pressedKey.ToString().Last().ToString());
            textBox.CursorPosition++;
        }
    }
    public class KeyboardInputBackStrategy : IKeyboardInputStrategy
    {
        public void HandleInput(TextBox textBox, Keys pressedKey)
        {
            if (textBox.CursorPosition >= 1)
            {
                textBox.CursorPosition--;
                textBox.Text = textBox.Text.Remove(textBox.CursorPosition, 1);
            }
        }
    }
    public class KeyboardInputLeftArrowStrategy : IKeyboardInputStrategy
    {
        public void HandleInput(TextBox textBox, Keys pressedKey)
        {
            if (textBox.CursorPosition >= 1)
            {
                textBox.Text = textBox.Text.Replace(textBox.CursorCharacter.ToString(), string.Empty);
                textBox.CursorPosition--;
                textBox.Text = textBox.Text.Insert(textBox.CursorPosition, textBox.CursorCharacter.ToString());
            }
        }
    }
    public class KeyboardInputRightArrowStrategy : IKeyboardInputStrategy
    {
        public void HandleInput(TextBox textBox, Keys pressedKey)
        {
            if (textBox.CursorPosition < textBox.Text.Length - 1)
            {
                textBox.Text = textBox.Text.Replace(textBox.CursorCharacter.ToString(), string.Empty);
                textBox.CursorPosition++;
                textBox.Text = textBox.Text.Insert(textBox.CursorPosition, textBox.CursorCharacter.ToString());
            }
        }
    }
    public class KeyboardWrongInputStrategy : IKeyboardInputStrategy
    {
        public void HandleInput(TextBox textBox, Keys pressedKey)
        {
        }
    }
}
