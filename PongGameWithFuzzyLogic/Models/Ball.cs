using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.Models.BallPositionStrategies;

namespace PongGameWithFuzzyLogic.Models
{
    public class Ball : Sprite
    {
        public float Velocity { get; set; } = 5;
        public Vector2 Direction { get; set; } = new Vector2();
        private readonly PongGame _pongGame;   
        public Ball(Texture2D texture, PongGame pongGame) : base(texture)
        {
            Scale = 0.3f;
            _pongGame = pongGame;
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            BallPositionHelper.SetBallPosition(this, _pongGame);
        }
    }
}
