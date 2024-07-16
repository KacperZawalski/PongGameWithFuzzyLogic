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
        private Panel topPanel;
        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
        }

        public void Initialize()
        {
            topPanel = new Panel(new Vector2(1000, 150), new Vector2(0, 0), _pongGame.GraphicsDevice);
            topPanel.Color = Color.Black;

            CreateButtons();
            AddButtonsToPanels();

            _components.Add(topPanel);
        }

        private void AddButtonsToPanels()
        {
            topPanel.Add(pvpButton);
            topPanel.Add(pveButton);
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