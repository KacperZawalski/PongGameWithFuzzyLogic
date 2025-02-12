using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.Models.BallPositionStrategies;
using System;

namespace PongGameWithFuzzyLogic.Models
{
    public class Ball : Sprite
    {
        public bool Moving { get; set; }
        public float Diameter => Rectangle.Width;
        public float Radius => Rectangle.Width / 2;
        public float Velocity { get; set; } = 5;
        public Vector2 Direction { get; set; }
        private readonly PongGame _pongGame;
        public Ball(Texture2D texture, PongGame pongGame) : base(texture)
        {
            Scale = 0.2f;
            _pongGame = pongGame;
            Direction = new Vector2(Velocity, Velocity);
            Position = new Vector2(300, 300);
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            BallPositionHelper.SetBallPosition(this, _pongGame);
        }

        internal void SetDefaultVelocity()
        {
            Velocity = 5f;
        }
    }
}
