using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class Panel : Component
    {
        private List<Component> _children = new List<Component>();
        public Panel(Vector2 dimensions, Vector2 position, GraphicsDevice graphicsDevice) : base(dimensions, position, graphicsDevice)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var child in _children)
            {
                child.Draw(gameTime, spriteBatch);
            }
        }
        public void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
