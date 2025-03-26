using System;
using System.IO;

namespace PongGameWithFuzzyLogic.Models
{
    public static class ScoreManager
    {
        public static int NumberOfSavedScores { get; set; } = 15;
        private static string _path = "./Scores.txt";
        public static void SaveScore(PongGame pongGame)
        {
            string[] scores = RetrieveScores();
            if (scores.Length >= NumberOfSavedScores)
            {
                string[] scoresToSave = new string[NumberOfSavedScores];
                Array.Copy(scores, 0, scoresToSave, 1, NumberOfSavedScores - 1);
                scoresToSave[0] = PrepareScore(pongGame);
                File.WriteAllLines(_path, scoresToSave);
            }
            else
            {
                File.AppendAllText(_path, PrepareScore(pongGame));
            }
        }


        public static string[] RetrieveScores()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path);
            }
            return File.ReadAllLines(_path);
        }
        private static string PrepareScore(PongGame pongGame)
        {
            return $"{pongGame.LeftScore}:{pongGame.RightScore}\n";
        }

        public static void UpdateScore(PongGame pongGame)
        {
            switch (pongGame.GameState)
            {
                case GameState.LeftScored:
                    pongGame.LeftScore++;
                    break;
                case GameState.RightScored:
                    pongGame.RightScore++;
                    break;
                case GameState.FirstServe:
                    pongGame.LeftScore = 0;
                    pongGame.RightScore = 0;
                    break;
                case GameState.LeftWon:
                    pongGame.LeftScore++;
                    SaveScore(pongGame);
                    break;
                case GameState.RightWon:
                    pongGame.RightScore++;
                    SaveScore(pongGame);
                    break;
            }
        }
    }
}

