using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.UiComponents;
using System.Collections.Generic;
using System.Linq;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class ViewManager : IGameComponent
    {
        public DefaultPanel TopPanel { get; internal set; }
        public DefaultPanel GamePanel { get; internal set; }
        public DefaultPanel RulesPanel { get; internal set; }
        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
            _font14 = pongGame.Content.Load<SpriteFont>("font14");
            _font30 = pongGame.Content.Load<SpriteFont>("font30");
            _font40 = pongGame.Content.Load<SpriteFont>("font40");
        }
        private readonly PongGame _pongGame;
        private readonly List<Component> _components = new List<Component>();
        private readonly SpriteFont _font14;
        private readonly SpriteFont _font30;
        private readonly SpriteFont _font40;
        private DefaultButton pvpButton;
        private DefaultButton pveButton;
        private DefaultButton eveButton;
        private DefaultButton restartGameButton;
        private DefaultButton rulesButton;
        private DefaultButton closeRulesButton;
        private DefaultTextLabel scoreValueLabel;
        private DefaultTextLabel descriptionScoreLabel;

        public void Initialize()
        {
            CreatePanels();
            CreateButtons();
            CreateLabels();
            AddEventListenersToButtons();
            AddButtonsToPanels();
            AddLabelsToPanels();
            CreateRulesPanelElements();
            AddPanelsToGame();
        }

        private void CreateRulesPanelElements()
        {
            Vector2 dimesions = new Vector2(220, 40);
            Vector2 position = new Vector2(110, 210);
            int yOffset = _pongGame.AIRules.Count * 50;
            List<string> movementValues = new List<string>();
            List<string> distanceValues = new List<string>();
            for (int i = 0; i < _pongGame.AIRules.Count; i++)
            {
                movementValues.Add(_pongGame.AIRules[i].MovementTerm.GetType().Name);
                distanceValues.Add(_pongGame.AIRules[i].DistanceTerm.GetType().Name);
            }

            for (int i = _pongGame.AIRules.Count - 1; i >= 0; i--)
            {
                var movementBox = new DefaultComboBox(_font14, dimesions, position + new Vector2(0, yOffset), _pongGame.GraphicsDevice, movementValues);
                var distanceBox = new DefaultComboBox(_font14, dimesions, position + new Vector2(240, yOffset), _pongGame.GraphicsDevice, distanceValues);
                RulesPanel.Add(movementBox);
                RulesPanel.Add(distanceBox);
                var deleteButton = new DefaultButton(_font14, new Vector2(40, 40), new Vector2(600, 210 + yOffset), _pongGame.GraphicsDevice);
                deleteButton.Text = "X";
                yOffset -= 50;
                var ruleToRemove = _pongGame.AIRules[i];
                deleteButton.SetClickAction(() =>
                {
                    _pongGame.AIRules.Remove(ruleToRemove);
                    RulesPanel.Remove(movementBox);
                    RulesPanel.Remove(distanceBox);
                    RulesPanel.Remove(deleteButton);
                });
                RulesPanel.Add(deleteButton);
            }
        }

        public void DrawComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                if (component.Display)
                {
                    component.Draw(gameTime, spriteBatch);
                }
            }
        }
        public void UpdateComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            UpdateScore();
            _components.ForEach(component => component.Update(gameTime, spriteBatch));
        }

        private void AddLabelsToPanels()
        {
            TopPanel.Add(scoreValueLabel);
            TopPanel.Add(descriptionScoreLabel);
        }

        private void CreateLabels()
        {
            var scoreLabelPosition = new Vector2(TopPanel.Dimensions.X / 2 - 50, TopPanel.Dimensions.Y / 2 - 10);
            var labelSize = new Vector2(100, 40);

            scoreValueLabel = new DefaultTextLabel(_font30, labelSize, scoreLabelPosition, _pongGame.GraphicsDevice);
            scoreValueLabel.Text = "0:0";

            var descriptionLabelPosition = new Vector2(scoreLabelPosition.X, scoreLabelPosition.Y - 45);

            descriptionScoreLabel = new DefaultTextLabel(_font30, labelSize, descriptionLabelPosition, _pongGame.GraphicsDevice);
            descriptionScoreLabel.Text = "SCORE";
        }

        private void AddEventListenersToButtons()
        {
            pveButton.SetClickAction(() =>
            {
                _pongGame.LeftRacket.IsControlledByAi = false;
                _pongGame.RightRacket.IsControlledByAi = true;
            });
            pvpButton.SetClickAction(() =>
            {
                _pongGame.RightRacket.IsControlledByAi = false;
                _pongGame.LeftRacket.IsControlledByAi = false;
                _pongGame.RightRacket.MoveUp = Keys.Up;
                _pongGame.RightRacket.MoveDown = Keys.Down;
            });
            eveButton.SetClickAction(() =>
            {
                _pongGame.RightRacket.IsControlledByAi = true;
                _pongGame.LeftRacket.IsControlledByAi = true;
            });
            restartGameButton.SetClickAction(() =>
            {
                _pongGame.Restart();
            });
            rulesButton.SetClickAction(() =>
            {
                RulesPanel.Display = true;
            });
            closeRulesButton.SetClickAction(() =>
            {
                RulesPanel.Display = false;
            });
        }

        private void AddPanelsToGame()
        {
            _components.Add(TopPanel);
            _components.Add(GamePanel);
            _components.Add(RulesPanel);
        }

        private void CreatePanels()
        {
            TopPanel = new DefaultPanel(new Vector2(996, 146), new Vector2(0, 0), _pongGame.GraphicsDevice);

            GamePanel = new DefaultPanel(
                dimensions: new Vector2(996, _pongGame.GraphicsDevice.Viewport.Height - TopPanel.Dimensions.Y - 4),
                position: new Vector2(0, TopPanel.Dimensions.Y),
                _pongGame.GraphicsDevice);

            RulesPanel = new DefaultPanel(new Vector2(600, 450), new Vector2(100, 200), _pongGame.GraphicsDevice);
            RulesPanel.Display = false;
        }

        private void AddButtonsToPanels()
        {
            TopPanel.Add(pvpButton);
            TopPanel.Add(pveButton);
            TopPanel.Add(eveButton);
            TopPanel.Add(restartGameButton);
            TopPanel.Add(rulesButton);
            RulesPanel.Add(closeRulesButton);
        }

        private void CreateButtons()
        {
            var size = new Vector2(150, 40);
            pvpButton = new DefaultButton(_font14, size, new Vector2(830, 10), _pongGame.GraphicsDevice);
            pvpButton.Text = "Player vs Player";

            pveButton = new DefaultButton(_font14, size, new Vector2(830, 60), _pongGame.GraphicsDevice);
            pveButton.Text = "Player vs AI";

            eveButton = new DefaultButton(_font14, size, new Vector2(670, 60), _pongGame.GraphicsDevice);
            eveButton.Text = "AI vs AI";

            restartGameButton = new DefaultButton(_font14, size, new Vector2(670, 10), _pongGame.GraphicsDevice);
            restartGameButton.Text = "Restart game";

            rulesButton = new DefaultButton(_font14, size, new Vector2(20, 10), _pongGame.GraphicsDevice);
            rulesButton.Text = "AI rules";

            closeRulesButton = new DefaultButton(_font14, size, new Vector2(110, 210), _pongGame.GraphicsDevice);
            closeRulesButton.Text = "Close";
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
            scoreValueLabel.Text = $"{_pongGame.LeftScore}:{_pongGame.RightScore}";
        }
    }
}