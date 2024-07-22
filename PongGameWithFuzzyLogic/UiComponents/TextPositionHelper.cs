using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public sealed class TextPositionHelper
    {
        public static Vector2 CalculateTextPosition(TextPosition textPosition, SpriteFont font, Vector2 position, Vector2 padding, string text, Texture2D texture)
        {
            Vector2 textSize = font.MeasureString(text);
            ITextPositionStrategy strategy;
            switch (textPosition)
            {
                case TextPosition.Left:
                    strategy = new LeftTextPositionStrategy();
                    break;
                case TextPosition.Right:
                    strategy = new RightTextPositionStrategy();
                    break;
                default:
                    strategy = new CenterTextPositionStrategy();
                    break;
            }

            return strategy.CalculateTextPosition(font, position, padding, text, texture);
        }
    }
}
