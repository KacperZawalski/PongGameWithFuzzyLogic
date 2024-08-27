using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class Button : TextLabel
    {
        public Button(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(font, dimensions, position, graphicsDevice)
        {
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawBorder(spriteBatch);
            DrawRectangle(spriteBatch);
            DrawText(spriteBatch);
        }

        public void SetClickAction(Action action)
        {
            _clickAction = action;
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Update(gameTime, spriteBatch);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && IsMouseHovering())
            {
                _clickAction?.Invoke();
            }
        }

    }
}
