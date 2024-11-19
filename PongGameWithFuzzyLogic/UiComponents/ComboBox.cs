using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        public List<string> Values
        {
            get
            {
                return _values;
            }
            set
            {
                Text = value[0] != null ? value[0] : string.Empty;
                _values = value;
            }
        }
        private List<string> _values = new List<string>();
        public ComboBox(SpriteFont font, Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice, List<string> values) : base(font, dimensions, position, graphicsDevice)
        {
            ItemsHoverColor = HoverColor;
            ItemsColor = Color;
            ItemsTextColor = TextColor;
            ItemsHoverTextColor = HoverTextColor;
            Values = values;
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Clicked)
            {
                DisplayComboElements = !DisplayComboElements;
            }

            float comboY = Position.Y;
            for (int i = 0; i < Values.Count; i++)
            {
                comboY += Dimensions.Y + BorderWidth;
                var position = new Vector2(Position.X, comboY);
                if (new Rectangle(position.ToPoint(), Dimensions.ToPoint()).Contains(Mouse.GetState().Position)
                    && Mouse.GetState().LeftButton == ButtonState.Pressed
                    && DisplayComboElements)
                {
                    DisplayComboElements = false;
                    Text = Values[i];
                }
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
                    DrawComboItem(spriteBatch, position, ItemsHoverColor);
                    DrawText(spriteBatch, value, position, ItemsHoverTextColor);
                }
                else
                {
                    DrawComboItem(spriteBatch, position, ItemsColor);
                    DrawText(spriteBatch, value, position, ItemsTextColor);
                }
            }
        }
        private void DrawComboItem(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            var texture = new Texture2D(_graphicsDevice, (int)Dimensions.X, (int)Dimensions.Y);
            Color[] data = new Color[(int)Dimensions.X * (int)Dimensions.Y];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = color;
            }
            texture.SetData(data);
            //spriteBatch.Draw(texture, position, null, color, 0f, new Vector2(), 1f, SpriteEffects.None, 1f);
            spriteBatch.Draw(texture, position, color);
        }
    }
}
