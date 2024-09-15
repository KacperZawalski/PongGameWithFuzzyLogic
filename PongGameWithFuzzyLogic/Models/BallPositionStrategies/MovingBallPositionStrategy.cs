using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class MovingBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            var gamePanelHeight = pongGame.ViewManager.GamePanel.Position.Y + pongGame.ViewManager.GamePanel.Dimensions.Y;

            if (ball.Position.Y <= pongGame.ViewManager.GamePanel.Position.Y)
            {
                ball.Direction = new Vector2(ball.Direction.X, ball.Velocity);
            }
            else if (ball.Position.Y > gamePanelHeight)
            {
                ball.Direction = new Vector2(ball.Direction.X, -ball.Velocity);
            }
            else if (pongGame.RightRacket.Rectangle.Intersects(ball.Rectangle))
            {
                ball.Direction = new Vector2(-ball.Velocity, ball.Direction.Y);
            }
            else if (pongGame.LeftRacket.Rectangle.Intersects(ball.Rectangle))
            {
                ball.Direction = new Vector2(ball.Velocity, ball.Direction.Y);
            }

            ball.Position = new Vector2(ball.Position.X + ball.Direction.X, ball.Position.Y + ball.Direction.Y);
        }
    }
}