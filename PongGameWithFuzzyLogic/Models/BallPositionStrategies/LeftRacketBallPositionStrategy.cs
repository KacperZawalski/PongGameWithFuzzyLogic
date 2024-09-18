using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class LeftRacketBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            var x = pongGame.LeftRacket.Position.X + pongGame.LeftRacket.Texture.Height * pongGame.LeftRacket.Scale + ball.Diameter / 2;
            ball.Position = new Vector2(x, pongGame.LeftRacket.Position.Y);
            ball.Moving = false;
        }
    }
}
