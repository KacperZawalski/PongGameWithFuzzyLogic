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
                case GameState.WaitingForRight:
                    strategy = new RightRacketBallPositionStrategy();
                    break;
                case GameState.RightScored:
                case GameState.WaitingForLeft:
                    strategy = new LeftRacketBallPositionStrategy();
                    break;
                case GameState.FirstServe:
                    strategy = new LeftRacketBallPositionStrategy();
                    break;
                case GameState.LeftServed:
                    strategy = new LeftServedBallPositionStrategy();
                    break;
                case GameState.RightServed:
                    strategy = new RightServedBallPositionStrategy();
                    break;
                default:
                    strategy = new MovingBallPositionStrategy();
                    break;
            }

            strategy.SetBallPosition(ball, pongGame);
        }
    }
}
