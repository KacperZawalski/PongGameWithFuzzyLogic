using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class RightRacketBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            ball.Position = new Vector2(pongGame.RightRacket.Position.X - pongGame.RightRacket.Texture.Height * pongGame.RightRacket.Scale, pongGame.RightRacket.Position.Y);
            ball.Moving = false;
        }
    }
}
