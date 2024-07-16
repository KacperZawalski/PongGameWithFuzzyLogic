﻿using Microsoft.Xna.Framework;
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
        private readonly SpriteFont _font;
        private DefaultButton pvpButton;
        private DefaultButton pveButton;
        private TextBox sensitivityTextBox;
        public DefaultPanel TopPanel { get; internal set; }
        public DefaultPanel GamePanel { get; internal set; }
        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
            _font = pongGame.Content.Load<SpriteFont>("font14");
        }

        public void Initialize()
        {
            CreatePanels();
            CreateButtons();
            AddButtonsToPanels();
            CreateTextBoxes();
            AddTextBoxesToPanels();
            AddPanelsToGame();
        }

        private void AddTextBoxesToPanels()
        {
            TopPanel.Add(sensitivityTextBox);
        }

        private void CreateTextBoxes()
        {
            sensitivityTextBox = new TextBox(_font, new Vector2(50, 30), new Vector2(10, 50), _pongGame.GraphicsDevice);
            sensitivityTextBox.Text = "5";
            sensitivityTextBox.TextColor = Color.White;
            sensitivityTextBox.Color = Color.Black;
            sensitivityTextBox.BorderColor = Color.White;
            sensitivityTextBox.BorderWidth = 2;
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
            pvpButton = new DefaultButton(_font, new Vector2(150, 40), new Vector2(830, 10), _pongGame.GraphicsDevice);
            pvpButton.Text = "Gracz vs Gracz";
            pveButton = new DefaultButton(_font, new Vector2(150, 40), new Vector2(830, 60), _pongGame.GraphicsDevice);
            pveButton.Text = "Gracz vs AI";
        }

        public void DrawComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public void UpdateComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime, spriteBatch);
            }
        }
    }
}