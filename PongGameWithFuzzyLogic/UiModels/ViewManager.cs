using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.Models.FuzzyLogic;
using PongGameWithFuzzyLogic.UiComponents;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PongGameWithFuzzyLogic.UiModels
{
    public class ViewManager : IGameComponent
    {
        public DefaultPanel TopPanel { get; internal set; }
        public DefaultPanel GamePanel { get; internal set; }
        public DefaultPanel RulesPanel { get; internal set; }
        public DefaultPanel ScoresPanel { get; internal set; }
        public ViewManager(PongGame pongGame)
        {
            _pongGame = pongGame;
            _font14 = pongGame.Content.Load<SpriteFont>("font14");
            _font22 = pongGame.Content.Load<SpriteFont>("font22");
            _font30 = pongGame.Content.Load<SpriteFont>("font30");
            _font40 = pongGame.Content.Load<SpriteFont>("font40");
        }
        private readonly PongGame _pongGame;
        private readonly List<Component> _components = new List<Component>();
        private readonly SpriteFont _font14;
        private readonly SpriteFont _font22;
        private readonly SpriteFont _font30;
        private readonly SpriteFont _font40;
        private DefaultButton _pvpButton;
        private DefaultButton _pveButton;
        private DefaultButton _eveButton;
        private DefaultButton _restartGameButton;
        private DefaultButton _rulesButton;
        private DefaultButton _closeRulesButton;
        private DefaultButton _openScoresButton;
        private DefaultButton _closeScoresButton;
        private DefaultTextLabel _scoreValueLabel;
        private DefaultTextLabel _descriptionScoreLabel;
        private DefaultTextLabel _playerWonTextLabel;
        private DefaultTextLabel _scoresTitle;
        private DefaultTextLabel _scoresList;
        private List<ComboBox> _movementBoxes = new List<ComboBox>();
        private List<TextLabel> _distanceLabels = new List<TextLabel>();
        private List<DefaultButton> _disableRuleButtons = new List<DefaultButton>();
        private List<string> _movementValues = new List<string>()
        {
            "NoneMovementTerm",
            "VerySlowMovementTerm",
            "SlowMovementTerm",
            "MediumMovementTerm",
            "FastMovementTerm",
            "VeryFastMovementTerm"
        };
        private List<string> _distanceValues = new List<string>()
        {
            "VeryShortDistanceTerm",
            "ShortDistanceTerm",
            "MediumDistanceTerm",
            "LongDistanceTerm",
            "VeryLongDistanceTerm"
        };

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

            for (int i = _pongGame.AIRules.Count - 1; i >= 0; i--)
            {
                var movementBox = new DefaultComboBox(_font14, dimesions, position + new Vector2(240, yOffset), _pongGame.GraphicsDevice, _movementValues);
                var distanceLabel = new DefaultTextLabel(_font14, dimesions, position + new Vector2(0, yOffset), _pongGame.GraphicsDevice);

                distanceLabel.Text = _distanceValues[i];

                Vector2 disableButtonPosition = position + new Vector2(490, yOffset + 10);
                var disableRuleButton = GenerateDisableRuleButton(disableButtonPosition, i);
                RulesPanel.Add(disableRuleButton);
                RulesPanel.Add(movementBox);
                RulesPanel.Add(distanceLabel);
                yOffset -= 50;
                _movementBoxes.Add(movementBox);
                _disableRuleButtons.Add(disableRuleButton);
                _distanceLabels.Add(distanceLabel);
            }
            _disableRuleButtons.Reverse();
            _movementBoxes.Reverse();
            _distanceLabels.Reverse();
        }

        private DefaultButton GenerateDisableRuleButton(Vector2 position, int index)
        {
            var button = new DefaultButton(_font30, new Vector2(20, 20), position, _pongGame.GraphicsDevice);
            button.Color = Color.Green;
            button.HoverColor = Color.LightGreen;
            button.SetClickAction(() =>
            {
                _pongGame.AIRules[index].Enabled = !_pongGame.AIRules[index].Enabled;
                if (_pongGame.AIRules[index].Enabled)
                {
                    button.Color = Color.Green;
                    button.HoverColor = Color.LightGreen;
                }
                else
                {
                    button.Color = Color.IndianRed;
                    button.HoverColor = Color.Red;
                }
            });
            return button;
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
            UpdateSavedScores();
            _components.ForEach(component => component.Update(gameTime, spriteBatch));
            UpdateRulesFromComboBoxes();
            for (int i = 0; i < _disableRuleButtons.Count; i++)
            {
                Debug.WriteLine(i + ": " + _pongGame.AIRules[i].Enabled);
            }
        }

        private void UpdateRulesFromComboBoxes()
        {
            for (int i = 0; i < _pongGame.AIRules.Count && i < _movementBoxes.Count; i++)
            {
                var rule = new Rule(new DistanceTermFactory().GetTerm(_distanceLabels[i].Text),
                    new MovementTermFactory().GetTerm(_movementBoxes[i].Text),
                    _pongGame.AIRules[i].Enabled);

                _pongGame.AIRules[i] = rule;
            }
        }

        private void UpdateSavedScores()
        {
            if (ScoresPanel.Display)
            {
                StringBuilder sb = new StringBuilder();
                string[] scores = ScoreManager.RetrieveScores();
                for (int i = 0; i < scores.Length / 2; i++)
                {
                    sb.AppendLine($"{i + 1}. {scores[i]}          {scores.Length / 2 + i + 1}. {scores[scores.Length / 2 + i + 1]}");
                }
                _scoresList.Text = sb.ToString();
            }
        }

        private void AddLabelsToPanels()
        {
            TopPanel.Add(_scoreValueLabel);
            TopPanel.Add(_descriptionScoreLabel);
            GamePanel.Add(_playerWonTextLabel);
            ScoresPanel.Add(_scoresTitle);
            ScoresPanel.Add(_scoresList);
        }

        private void CreateLabels()
        {
            var scoreLabelPosition = new Vector2(TopPanel.Dimensions.X / 2 - 50, TopPanel.Dimensions.Y / 2 - 10);
            var labelSize = new Vector2(100, 40);

            _scoreValueLabel = new DefaultTextLabel(_font30, labelSize, scoreLabelPosition, _pongGame.GraphicsDevice);
            _scoreValueLabel.Text = "0:0";

            var descriptionLabelPosition = new Vector2(scoreLabelPosition.X, scoreLabelPosition.Y - 45);

            _descriptionScoreLabel = new DefaultTextLabel(_font30, labelSize, descriptionLabelPosition, _pongGame.GraphicsDevice);
            _descriptionScoreLabel.Text = "SCORE";

            var playerWonLabelPosition = new Vector2(GamePanel.Dimensions.X / 2 - 100, GamePanel.Dimensions.Y / 2 - 40);
            _playerWonTextLabel = new DefaultTextLabel(_font40, new Vector2(200, 80), playerWonLabelPosition, _pongGame.GraphicsDevice);
            _playerWonTextLabel.TextColor = Color.Green;
            _playerWonTextLabel.HoverTextColor = Color.Green;
            _playerWonTextLabel.Display = false;

            var scoresTitlePosition = new Vector2(GamePanel.Dimensions.X / 2 - 100, ScoresPanel.Position.Y + 10);
            _scoresTitle = new DefaultTextLabel(_font30, new Vector2(200, 80), scoresTitlePosition, _pongGame.GraphicsDevice);
            _scoresTitle.Text = $"Scores of last {ScoreManager.NumberOfSavedScores} games";

            var scoresListPosition = ScoresPanel.Position + new Vector2(10, 100);
            _scoresList = new DefaultTextLabel(_font22, ScoresPanel.Dimensions - new Vector2(20, 200), scoresListPosition, _pongGame.GraphicsDevice);
        }

        private void AddEventListenersToButtons()
        {
            _pveButton.SetClickAction(() =>
            {
                _pongGame.LeftRacket.IsControlledByAi = false;
                _pongGame.RightRacket.IsControlledByAi = true;
            });
            _pvpButton.SetClickAction(() =>
            {
                _pongGame.RightRacket.IsControlledByAi = false;
                _pongGame.LeftRacket.IsControlledByAi = false;
                _pongGame.RightRacket.MoveUp = Keys.Up;
                _pongGame.RightRacket.MoveDown = Keys.Down;
            });
            _eveButton.SetClickAction(() =>
            {
                _pongGame.RightRacket.IsControlledByAi = true;
                _pongGame.LeftRacket.IsControlledByAi = true;
            });
            _restartGameButton.SetClickAction(() =>
            {
                _pongGame.Restart();
            });
            _rulesButton.SetClickAction(() =>
            {
                RulesPanel.Display = true;
            });
            _closeRulesButton.SetClickAction(() =>
            {
                RulesPanel.Display = false;
            });
            _openScoresButton.SetClickAction(() =>
            {
                ScoresPanel.Display = true;
            });
            _closeScoresButton.SetClickAction(() =>
            {
                ScoresPanel.Display = false;
            });
        }
        private void AddPanelsToGame()
        {
            _components.Add(TopPanel);
            _components.Add(GamePanel);
            _components.Add(RulesPanel);
            _components.Add(ScoresPanel);
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

            ScoresPanel = new DefaultPanel(new Vector2(500, 500), new Vector2(GamePanel.Dimensions.X / 2 - 250, 200), _pongGame.GraphicsDevice);
            ScoresPanel.Display = false;
        }

        private void AddButtonsToPanels()
        {
            TopPanel.Add(_pvpButton);
            TopPanel.Add(_pveButton);
            TopPanel.Add(_eveButton);
            TopPanel.Add(_restartGameButton);
            TopPanel.Add(_rulesButton);
            TopPanel.Add(_openScoresButton);
            RulesPanel.Add(_closeRulesButton);
            ScoresPanel.Add(_closeScoresButton);
        }

        private void CreateButtons()
        {
            var size = new Vector2(150, 40);
            _pvpButton = new DefaultButton(_font14, size, new Vector2(830, 10), _pongGame.GraphicsDevice);
            _pvpButton.Text = "Player vs Player";

            _pveButton = new DefaultButton(_font14, size, new Vector2(830, 60), _pongGame.GraphicsDevice);
            _pveButton.Text = "Player vs AI";

            _eveButton = new DefaultButton(_font14, size, new Vector2(670, 60), _pongGame.GraphicsDevice);
            _eveButton.Text = "AI vs AI";

            _restartGameButton = new DefaultButton(_font14, size, new Vector2(670, 10), _pongGame.GraphicsDevice);
            _restartGameButton.Text = "Restart game";

            _rulesButton = new DefaultButton(_font14, size, new Vector2(20, 10), _pongGame.GraphicsDevice);
            _rulesButton.Text = "AI rules";

            _closeRulesButton = new DefaultButton(_font14, size, new Vector2(110, 210), _pongGame.GraphicsDevice);
            _closeRulesButton.Text = "Close";

            _openScoresButton = new DefaultButton(_font14, size, new Vector2(20, 60), _pongGame.GraphicsDevice);
            _openScoresButton.Text = "Scores";

            _closeScoresButton = new DefaultButton(_font14, size, new Vector2(590, 650), _pongGame.GraphicsDevice);
            _closeScoresButton.Text = "Close";
        }

        private void UpdateScore()
        {
            if (_pongGame.GameState == GameState.LeftWon)
            {
                _playerWonTextLabel.Text = "Player 1 won!";
                _playerWonTextLabel.Display = true;
            }
            else if (_pongGame.GameState == GameState.RightWon)
            {
                _playerWonTextLabel.Text = "Player 2 won!";
                _playerWonTextLabel.Display = true;
            }
            else if (_pongGame.GameState == GameState.Running)
            {
                _playerWonTextLabel.Display = false;
            }
            _scoreValueLabel.Text = $"{_pongGame.LeftScore}:{_pongGame.RightScore}";
        }
    }
}