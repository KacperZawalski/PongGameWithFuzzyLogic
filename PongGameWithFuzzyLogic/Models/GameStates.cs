namespace PongGameWithFuzzyLogic.Models
{
    public enum GameState
    {
        Running = 0,
        FirstServe = 1,
        LeftScored = 2,
        RightScored = 3,
        LeftServed = 4,
        RightServed = 5,
        WaitingForRight = 6,
        WaitingForLeft = 7,
        LeftWon = 8,
        RightWon = 9,
    }
}
