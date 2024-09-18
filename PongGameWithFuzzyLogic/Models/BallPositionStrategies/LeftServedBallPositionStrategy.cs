using Microsoft.Xna.Framework;
using System;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class LeftServedBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            ball.Moving = true;
            var rand = new Random();
            ball.Direction = new Vector2(ball.Velocity, rand.Next() % 16 - 8);
            ball.Position += ball.Direction;
        }
    }
}