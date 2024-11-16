using Microsoft.Xna.Framework.Input;

namespace PongGameWithFuzzyLogic.Models
{
    public static class GameStateFactory
    {
        public static GameState GetGameState(PongGame pongGame)
        {
            var panelLeftBorder = pongGame.ViewManager.GamePanel.Position.X;
            var panelRightBorder = pongGame.ViewManager.GamePanel.Dimensions.X + pongGame.ViewManager.GamePanel.Position.X;

            if (pongGame.Ball.Position.X <= panelLeftBorder)
            {
                if (pongGame.RightScore >= pongGame.WinningScoreValue)
                {
                    return GameState.RightWon;
                }
                return GameState.RightScored;
            }
            else if (pongGame.Ball.Position.X >= panelRightBorder)
            {
                if (pongGame.LeftScore >= pongGame.WinningScoreValue)
                {
                    return GameState.LeftWon;
                }
                return GameState.LeftScored;
            }
            else if (pongGame.Ball.Moving)
            {
                return GameState.Running;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                return GameState.LeftServed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return GameState.RightServed;
            }
            else if (pongGame.GameState == GameState.RightScored || pongGame.GameState == GameState.WaitingForLeft)
            {
                return GameState.WaitingForLeft;
            }
            else if (pongGame.GameState == GameState.LeftScored || pongGame.GameState == GameState.WaitingForRight)
            {
                return GameState.WaitingForRight;
            }
            else
            {
                return GameState.FirstServe;
            }
        }
    }
}
