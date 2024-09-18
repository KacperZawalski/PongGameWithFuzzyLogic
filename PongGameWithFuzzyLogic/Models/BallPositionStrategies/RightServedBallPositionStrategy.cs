using Microsoft.Xna.Framework;
using System;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class RightServedBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            ball.Moving = true;
            var rand = new Random();
            ball.Direction = new Vector2(-ball.Velocity, ball.Direction.Y);
            ball.Position = new Vector2(ball.Position.X - ball.Velocity, ball.Position.Y + rand.Next() % 16 - 8);
        }
    }
}