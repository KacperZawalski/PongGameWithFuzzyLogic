using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiComponents;
using System.Collections.Generic;
using System.Data;

namespace PongGameWithFuzzyLogic.UiModels
{
    public sealed class DefaultComboBox : ComboBox
    {
        public DefaultComboBox(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice, List<string> values) : base(font, dimensions, position, graphicsDevice, values)
        {
            Color = Color.Black;
            BorderColor = Color.White;
            BorderWidth = 2;
            TextColor = Color.White;
            HoverColor = Color.LightGray;
            HoverTextColor = Color.White;
            ItemsColor = Color.Black;
            ItemsHoverColor = Color.LightGray;
            ItemsTextColor = Color.White;
            ItemsHoverTextColor = Color.White;
        }
    }
}
