using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class ComboBox : Button
    {
        public Color ItemsColor { get; set; }
        public Color ItemsHoverColor { get; set; }
        public Color ItemsTextColor { get; set; }
        public Color ItemsHoverTextColor { get; set; }
        public bool DisplayComboElements { get; set; }
        public List<string> Values { get; set; } = new List<string>();
        public string SelectedValue { get; set; }
        public ComboBox(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(font, dimensions, position, graphicsDevice)
        {
            ItemsHoverColor = HoverColor;
            ItemsColor = Color;
            ItemsTextColor = TextColor;
            ItemsHoverTextColor = HoverTextColor;
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Clicked)
            {
                DisplayComboElements = !DisplayComboElements;
            }
            base.Update(gameTime, spriteBatch);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if (DisplayComboElements)
            {
                DisplayOptions(spriteBatch);
            }
        }
        private void DisplayOptions(SpriteBatch spriteBatch)
        {
            float comboY = Position.Y;
            foreach (var value in Values)
            {
                comboY += Dimensions.Y + BorderWidth;
                var position = new Vector2(Position.X, comboY);
                DrawBorder(spriteBatch, position, BorderColor);
                if (new Rectangle(position.ToPoint(), Dimensions.ToPoint()).Contains(Mouse.GetState().Position))
                {
                    DrawRectangle(spriteBatch, position, ItemsHoverColor);
                    DrawText(spriteBatch, value, position, ItemsHoverTextColor);
                }
                else
                {
                    DrawRectangle(spriteBatch, position, ItemsColor);
                    DrawText(spriteBatch, value, position, ItemsTextColor);
                }
            }
        }
    }
}
