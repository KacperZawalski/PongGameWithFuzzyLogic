using Microsoft.Xna.Framework.Input;

namespace PongGameWithFuzzyLogic.UiComponents.Interfaces
{
    public interface IKeyboardInputStrategy
    {
        public void HandleInput(TextBox textBox, Keys pressedKey);
    }
}
