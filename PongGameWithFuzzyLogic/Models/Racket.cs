using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.Models.FuzzyLogic;

namespace PongGameWithFuzzyLogic.Models
{
    public class Racket : Sprite
    {
        public bool IsControlledByAi { get; set; }
        public Keys MoveUp { get; set; } = Keys.W;
        public Keys MoveDown { get; set; } = Keys.S;
        protected readonly PongGame _pongGame;
        public int MovementSensitivity { get; set; }
        public Racket(Texture2D texture, PongGame pongGame) : base(texture)
        {
            MovementSensitivity = 9;
            Scale = 0.1f;
            _pongGame = pongGame;
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IsControlledByAi)
            {
                new AiControls(this, _pongGame).HandleControls();
            }
            else
            {
                new RacketControls(this, _pongGame).HandleControls();
            }
        }
        public bool IsWithinUpperBound()
        {
            return Position.Y > _pongGame.ViewManager.GamePanel.Position.Y + _pongGame.ViewManager.GamePanel.BorderWidth / 2;
        }
        public bool IsWithinLowerBound()
        {
            return Position.Y + Rectangle.Height < _pongGame.ViewManager.GamePanel.Position.Y + _pongGame.ViewManager.GamePanel.Dimensions.Y;
        }

    }
}
