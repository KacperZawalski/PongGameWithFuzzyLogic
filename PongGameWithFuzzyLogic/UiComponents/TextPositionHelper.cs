using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public sealed class TextPositionHelper
    {
        public static Vector2 CalculateTextPosition(TextPosition textPosition, SpriteFont font, Vector2 position, Vector2 padding, string text, Texture2D texture)
        {
            Vector2 textSize = font.MeasureString(text);

            float horizontalLeft = position.X + padding.X;
            float horizontalRight = horizontalLeft + texture.Width - textSize.X;
            float horizontalCenter = horizontalLeft + texture.Width / 2 - textSize.X / 2;
            float verticalCenter = position.Y + texture.Height / 2 - textSize.Y / 2 + padding.Y;

            switch (textPosition)
            {
                case TextPosition.Left:
                    return new Vector2(horizontalLeft, verticalCenter);
                case TextPosition.Right:
                    return new Vector2(horizontalRight, verticalCenter);
                default:
                    return new Vector2(horizontalCenter, verticalCenter);
            }
        }
    }
}
