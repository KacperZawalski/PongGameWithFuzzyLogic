using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

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
                _borderTexture = new Texture2D(_graphicsDevice, (int)Dimensions.X + _borderWidth*2, (int)Dimensions.Y + _borderWidth*2);
            }
        }
        private readonly List<Component> _children = new List<Component>();
        public Panel(Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawBorder(spriteBatch, Position, BorderColor);
            DrawRectangle(spriteBatch, Position, Color);

            foreach (var child in _children)
            {
                child.Draw(gameTime, spriteBatch);
            }
        }
        public void Add(Component component)
        {
            _children.Add(component);
        }
        public void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var child in _children.ToList())
            {
                child.Update(gameTime, spriteBatch);
            }
            base.Update(gameTime, spriteBatch);
        }
    }
}
