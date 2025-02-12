using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class LeftRacketBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            ball.Position = new Vector2(pongGame.LeftRacket.Rectangle.Right, pongGame.LeftRacket.Rectangle.Center.Y - ball.Rectangle.Width / 2);
            ball.Moving = false;
            ball.SetDefaultVelocity();
        }
    }
}
