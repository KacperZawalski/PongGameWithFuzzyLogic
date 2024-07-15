using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiModels;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.UiComponents
{
    public class ViewManager : IGameComponent
    {
        private readonly PongGame _pongGame;
        private readonly List<Component> _components = new List<Component>();
        private readonly SpriteFont _font;

        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
            _font = _pongGame.Content.Load<SpriteFont>("font12");
        }

        public void Initialize()
        {
            Panel panel = new Panel(new Vector2(1000, 150), new Vector2(0, 0), _pongGame.GraphicsDevice);
            panel.Color = new Color(100,100,100);

            DefaultButton pvpButton = new DefaultButton(_font, new Vector2(130, 40), new Vector2(0, 30), _pongGame.GraphicsDevice);
            pvpButton.Text = "Gracz vs Gracz";

            panel.Add(pvpButton);
            _components.Add(panel);
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