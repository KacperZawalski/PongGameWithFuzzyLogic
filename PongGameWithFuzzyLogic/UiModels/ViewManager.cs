using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.UiComponents;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class ViewManager : IGameComponent
    {
        private readonly PongGame _pongGame;
        private readonly List<Component> _components = new List<Component>();
        private DefaultButton pvpButton;
        private DefaultButton pveButton;
        public DefaultPanel TopPanel { get; internal set; }
        public DefaultPanel GamePanel { get; internal set; }
        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
        }

        public void Initialize()
        {
            CreatePanels();
            CreateButtons();
            AddButtonsToPanels();
            AddPanelsToGame();
        }

        private void AddPanelsToGame()
        {
            _components.Add(TopPanel);
            _components.Add(GamePanel);
        }

        private void CreatePanels()
        {
            TopPanel = new DefaultPanel(new Vector2(996, 146), new Vector2(0, 0), _pongGame.GraphicsDevice);

            GamePanel = new DefaultPanel(
                dimensions: new Vector2(996, _pongGame.GraphicsDevice.Viewport.Height - TopPanel.Dimensions.Y - 4),
                position: new Vector2(0, TopPanel.Dimensions.Y),
                _pongGame.GraphicsDevice);
        }

        private void AddButtonsToPanels()
        {
            TopPanel.Add(pvpButton);
            TopPanel.Add(pveButton);
        }

        private void CreateButtons()
        {
            var font = _pongGame.Content.Load<SpriteFont>("font14");

            pvpButton = new DefaultButton(font, new Vector2(150, 40), new Vector2(830, 10), _pongGame.GraphicsDevice);
            pvpButton.Text = "Gracz vs Gracz";
            pveButton = new DefaultButton(font, new Vector2(150, 40), new Vector2(830, 60), _pongGame.GraphicsDevice);
            pveButton.Text = "Gracz vs AI";
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