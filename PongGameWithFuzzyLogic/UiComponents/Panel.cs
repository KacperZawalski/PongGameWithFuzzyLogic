using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class Panel : Component
    {
        public new int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                Position = new Vector2(Position.X + value, Position.Y + value);
                _borderWidth = value;
                _borderTexture = new Texture2D(_graphicsDevice, (int)Dimensions.X, (int)Dimensions.Y);
            }
        }
        private List<Component> _children = new List<Component>();
        public Panel(Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawBorder(spriteBatch);
            DrawRectangle(spriteBatch);

            foreach (var child in _children)
            {
                if (_texture.Bounds.Contains(child.Position))
                {
                    child.Draw(gameTime, spriteBatch);
                }
            }
        }
        public void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var child in _children)
            {
                child.Update(gameTime);
            }
        }
    }
}
