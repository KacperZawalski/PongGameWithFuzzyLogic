using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.UiComponents;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class ViewManager : IGameComponent
    {
        private readonly PongGame _pongGame;
        private readonly List<Component> _components = new List<Component>();
        private readonly SpriteFont _font14;
        private readonly SpriteFont _font24;
        private DefaultButton pvpButton;
        private DefaultButton pveButton;
        private DefaultButton restartGameButton;
        private DefaultTextLabel scoreLabel;
        public DefaultPanel TopPanel { get; internal set; }
        public DefaultPanel GamePanel { get; internal set; }
        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
            _font14 = pongGame.Content.Load<SpriteFont>("font14");
            _font24 = pongGame.Content.Load<SpriteFont>("font24");
        }

        public void Initialize()
        {
            CreatePanels();
            CreateButtons();
            CreateLabels();
            AddEventListenersToButtons();
            AddButtonsToPanels();
            AddLabelsToPanels();
            AddPanelsToGame();
        }
        public void DrawComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _components.ForEach(component => component.Draw(gameTime, spriteBatch));
        }
        public void UpdateComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            UpdateScore();
            _components.ForEach(component => component.Update(gameTime, spriteBatch));
        }

        private void AddLabelsToPanels()
        {
            TopPanel.Add(scoreLabel);
        }

        private void CreateLabels()
        {
            var x = TopPanel.Dimensions.X / 2;
            var y = TopPanel.Position.Y + 10;
            scoreLabel = new DefaultTextLabel(_font24, new Vector2(100, 40), new Vector2(x, y), _pongGame.GraphicsDevice);
            scoreLabel.Text = "0:0";
        }

        private void AddEventListenersToButtons()
        {
            pveButton.SetClickAction(() =>
            {
                //TODO Add AI controls
                _pongGame.RightRacket.IsControlledByAi = true;
            });
            pvpButton.SetClickAction(() => 
            {
                _pongGame.RightRacket.IsControlledByAi = false;
                _pongGame.RightRacket.MoveUp = Keys.Up;
                _pongGame.RightRacket.MoveDown = Keys.Down;
            });
            restartGameButton.SetClickAction(() =>
            {
                _pongGame.Restart();
            });
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
            TopPanel.Add(restartGameButton);
        }

        private void CreateButtons()
        {
            pvpButton = new DefaultButton(_font14, new Vector2(150, 40), new Vector2(830, 10), _pongGame.GraphicsDevice);
            pvpButton.Text = "Player vs Player";
            pveButton = new DefaultButton(_font14, new Vector2(150, 40), new Vector2(830, 60), _pongGame.GraphicsDevice);
            pveButton.Text = "Player vs AI";

            restartGameButton = new DefaultButton(_font14, new Vector2(150, 40), new Vector2(670, 10), _pongGame.GraphicsDevice);
            restartGameButton.Text = "Restart game";
        }

        private void UpdateScore()
        {
            switch (_pongGame.GameState)
            {
                case GameState.LeftScored:
                    _pongGame.LeftScore++;
                    break;
                case GameState.RightScored:
                    _pongGame.RightScore++;
                    break;
                case GameState.FirstServe:
                    _pongGame.LeftScore = 0;
                    _pongGame.RightScore = 0;
                    break;
            }
            scoreLabel.Text = $"{_pongGame.LeftScore}:{_pongGame.RightScore}";
        }
    }
}