using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models
{
    public class SpritesManager : IGameComponent
    {
        public List<Sprite> Sprites { get; } = new List<Sprite>();
        private readonly PongGame _pongGame;
        public SpritesManager(PongGame pongGame)
        {
            _pongGame = pongGame;
        }
        public void Initialize()
        {
            SetRacketsPositions();
            SetRacketsControls();
        }

        public void DrawSprites(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in Sprites)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
        }

        public void UpdateSprites(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in Sprites)
            {
                sprite.Update(gameTime, spriteBatch);
            }
        }
        private void SetRacketsPositions()
        {
            var Y = _pongGame.ViewManager.GamePanel.Dimensions.Y / 2 + _pongGame.ViewManager.GamePanel.Position.Y;
            
            _pongGame.LeftRacket.Position = new Vector2(20, Y);
            _pongGame.RightRacket.Position = new Vector2(_pongGame.ViewManager.GamePanel.Dimensions.X - 20, Y);
        }
        private void SetRacketsControls()
        {
            _pongGame.RightRacket.MoveDown = Keys.Down;
            _pongGame.RightRacket.MoveUp = Keys.Up;
        }
    }
}
