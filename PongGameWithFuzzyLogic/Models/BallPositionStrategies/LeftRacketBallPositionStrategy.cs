using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public class LeftRacketBallPositionStrategy : IBallPositionStrategy
    {
        public void SetBallPosition(Ball ball, PongGame pongGame)
        {
            ball.Position = new Vector2(pongGame.LeftRacket.Position.X + pongGame.LeftRacket.Texture.Height * pongGame.LeftRacket.Scale, pongGame.LeftRacket.Position.Y);
            ball.Moving = false;
        }
    }
}
