using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiComponents;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class DefaultTextBox : TextBox
    {
        public DefaultTextBox(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(font, dimensions, position, graphicsDevice)
        {
            TextColor = Color.White;
            Color = Color.Black;
            HoverTextColor = Color.White;
            HoverColor = Color.Black;
            BorderColor = Color.White;
            BorderWidth = 2;
        }
    }
}
