using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiComponents;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class DefaultPanel : Panel
    {
        public DefaultPanel(Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
            Color = Color.Black;
            BorderColor = Color.White;
            BorderWidth = 2;
        }
    }
}
