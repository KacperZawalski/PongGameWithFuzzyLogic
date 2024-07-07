using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class ViewManager : IGameComponent
    {
        private PongGame _pongGame;
        private List<Component> _components = new List<Component>();
        private SpriteFont _font;

        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
            _font = _pongGame.Content.Load<SpriteFont>("defaultFont");
        }

        public void Initialize()
        {
            Button button = new Button(_font, new Vector2(100, 100), new Vector2(50, 200), _pongGame.GraphicsDevice);
            button.Text = "xd";
            button.TextPosition = TextPosition.Left;
            button.SetClickListener(() =>
            {
                button.Color = Color.Red;
            });
            _components.Add(button);
        }
        public void DrawComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public void UpdateComponents(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}