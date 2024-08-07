using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.UiComponents.Interfaces
{
    public interface ITextPositionStrategy
    {
        Vector2 CalculateTextPosition(SpriteFont font, Vector2 position, Vector2 padding, string text, Texture2D texture);
    }
}