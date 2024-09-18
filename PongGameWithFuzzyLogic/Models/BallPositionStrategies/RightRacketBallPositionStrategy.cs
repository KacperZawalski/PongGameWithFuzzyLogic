using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class RightRacketBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            var x = pongGame.RightRacket.Position.X - pongGame.RightRacket.Texture.Height * pongGame.RightRacket.Scale - ball.Diameter / 2;
            ball.Position = new Vector2(x, pongGame.RightRacket.Position.Y);
            ball.Moving = false;
        }
    }
}
