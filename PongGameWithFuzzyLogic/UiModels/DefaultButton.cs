using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiComponents;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class DefaultButton : Button
    {
        public DefaultButton(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(font, dimensions, position, graphicsDevice)
        {
            Color = Color.Black;
            BorderColor = Color.White;
            BorderWidth = 2;
            TextColor = Color.White;
            HoverColor = Color.LightGray;
            HoverTextColor = Color.White;
        }
    }
}
