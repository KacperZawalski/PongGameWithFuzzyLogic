using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.Models.BallPositionStrategies;

namespace PongGameWithFuzzyLogic.Models
{
    public class Ball : Sprite
    {
        public bool Moving { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Position.ToPoint(), new Point((int)Diameter, (int)Diameter));
            }
        }

        public float Diameter => Texture.Width * Scale;
        public int Velocity { get; } = 5;
        public Vector2 Direction { get; set; }
        private readonly PongGame _pongGame;   
        public Ball(Texture2D texture, PongGame pongGame) : base(texture)
        {
            Scale = 0.3f;
            _pongGame = pongGame;
            Direction = new Vector2(Velocity, Velocity);
            Position = new Vector2(300, 300);
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            BallPositionHelper.SetBallPosition(this, _pongGame);
        }
    }
}
