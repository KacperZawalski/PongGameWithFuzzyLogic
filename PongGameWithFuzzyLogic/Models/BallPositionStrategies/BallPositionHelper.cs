namespace PongGameWithFuzzyLogic.Models.BallPositionStrategies
{
    public static class BallPositionHelper
    {
        public static void SetBallPosition(Ball ball, PongGame pongGame)
        {
            IBallPositionStrategy strategy;

            switch (pongGame.GameState)
            {
                case GameState.Running:
                    strategy = new MovingBallPositionStrategy();
                    break;
                case GameState.LeftScored:
                    strategy = new LeftRacketBallPositionStrategy();
                    break;
                case GameState.RightScored:
                    strategy = new RightRacketBallPositionStrategy();
                    break;
                case GameState.FirstServe:
                    //will be random in future
                    strategy = new LeftRacketBallPositionStrategy();
                    break;
                default:
                    strategy = new MovingBallPositionStrategy();
                    break;
            }
            strategy.SetBallPosition(ball);
        }
    }
}
