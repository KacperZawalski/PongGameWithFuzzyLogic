using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiComponents;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class DefaultTextLabel : TextLabel
    {
        public DefaultTextLabel(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(font, dimensions, position, graphicsDevice)
        {
            Color = Color.Black;
            HoverColor = Color.Black;
            TextColor = Color.White;
            HoverTextColor = Color.White;
            BorderColor = Color.White;
            BorderWidth = 0;
        }
    }
}
