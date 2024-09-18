using Microsoft.Xna.Framework;
using System;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class MovingBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            var gamePanel = pongGame.ViewManager.GamePanel;
            var gamePanelTop = gamePanel.Position.Y;
            var gamePanelBottom = gamePanelTop + gamePanel.Dimensions.Y;

            if (ball.Position.Y <= gamePanelTop)
            {
                ball.Direction = new Vector2(ball.Direction.X, ball.Velocity);
            }
            else if (ball.Position.Y + ball.Rectangle.Height > gamePanelBottom)
            {
                ball.Direction = new Vector2(ball.Direction.X, -ball.Velocity);
            }

            HandleRacketCollision(pongGame.RightRacket.Rectangle, ball, -1);
            HandleRacketCollision(pongGame.LeftRacket.Rectangle, ball, 1);

            ball.Position += ball.Direction;
        }
        private void HandleRacketCollision(Rectangle racketRectangle, Ball ball, int velocityInverter)
        {
            if (ball.Rectangle.Intersects(racketRectangle))
            {
                int rand = new Random().Next(-8, 8);
                ball.Direction = new Vector2(ball.Velocity * velocityInverter, rand);
            }
        }
    }
}