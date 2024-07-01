using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models
{
    public class SpritesManager : IGameComponent
    {
        public List<Sprite> Sprites;
        private readonly PongGame _pongGame;
        public SpritesManager(PongGame pongGame)
        {
            _pongGame = pongGame;
        }
        public void Initialize()
        {
        }
        public void DrawSprites(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in Sprites)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
        }

        public void UpdateSprites(GameTime gameTime)
        {
            foreach (var sprite in Sprites)
            {
                sprite.Update(gameTime);
            }
        }
    }
}
