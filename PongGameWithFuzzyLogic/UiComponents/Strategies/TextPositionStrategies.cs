using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiComponents.Interfaces;

namespace PongGameWithFuzzyLogic.UiComponents.Strategies
{
    public class LeftTextPositionStrategy : ITextPositionStrategy
    {
        public Vector2 CalculateTextPosition(SpriteFont font, Vector2 position, Vector2 padding, string text, Texture2D texture)
        {
            Vector2 textSize = font.MeasureString(text);
            float horizontalLeft = position.X + padding.X;
            float verticalCenter = position.Y + texture.Height / 2 - textSize.Y / 2 + padding.Y;
            return new Vector2(horizontalLeft, verticalCenter);
        }
    }

    public class RightTextPositionStrategy : ITextPositionStrategy
    {
        public Vector2 CalculateTextPosition(SpriteFont font, Vector2 position, Vector2 padding, string text, Texture2D texture)
        {
            Vector2 textSize = font.MeasureString(text);
            float horizontalRight = position.X + padding.X + texture.Width - textSize.X;
            float verticalCenter = position.Y + texture.Height / 2 - textSize.Y / 2 + padding.Y;
            return new Vector2(horizontalRight, verticalCenter);
        }
    }

    public class CenterTextPositionStrategy : ITextPositionStrategy
    {
        public Vector2 CalculateTextPosition(SpriteFont font, Vector2 position, Vector2 padding, string text, Texture2D texture)
        {
            Vector2 textSize = font.MeasureString(text);
            float horizontalCenter = position.X + padding.X + texture.Width / 2 - textSize.X / 2;
            float verticalCenter = position.Y + texture.Height / 2 - textSize.Y / 2 + padding.Y;
            return new Vector2(horizontalCenter, verticalCenter);
        }
    }
}
