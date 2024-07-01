using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class Button : Component
    {
        private Vector2 _textPosition
        {
            get
            {
                return new Vector2(Position.X + PaddingLeft, Position.Y + PaddingTop);
            }
        }

        public int PaddingTop { get; set; }
        public int PaddingLeft { get; set; }
        public SpriteFont Font { get; set; }
        public string Text { get; set; }
        public Color TextColor { get; set; }

        public Button(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
            Font = font;
            Text = "";
            TextColor = Color.Black;
            PaddingTop = 0;
            PaddingLeft = 0;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawRectangle(spriteBatch);
            spriteBatch.DrawString(Font, Text, _textPosition, TextColor);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
