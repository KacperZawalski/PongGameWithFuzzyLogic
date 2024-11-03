﻿using Microsoft.Xna.Framework.Input;

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
                return GameState.RightScored;
            }
            else if (pongGame.Ball.Position.X >= panelRightBorder)
            {
                return GameState.LeftScored;
            }
            else if (pongGame.Ball.Moving)
            {
                return GameState.Running;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) || pongGame.LeftRacket.IsControlledByAi)
            {
                return GameState.LeftServed;
            }
            else if (pongGame.GameState == GameState.RightScored || pongGame.GameState == GameState.WaitingForLeft)
            {
                return GameState.WaitingForLeft;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Enter) || pongGame.RightRacket.IsControlledByAi)
            {
                return GameState.RightServed;
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
