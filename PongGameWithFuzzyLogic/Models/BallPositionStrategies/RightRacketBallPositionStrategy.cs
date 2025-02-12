using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class RightRacketBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            ball.Position = new Vector2(pongGame.RightRacket.Position.X - ball.Rectangle.Width, pongGame.RightRacket.Rectangle.Center.Y - ball.Rectangle.Width / 2);
            ball.Moving = false;
            ball.SetDefaultVelocity();
        }
    }
}
