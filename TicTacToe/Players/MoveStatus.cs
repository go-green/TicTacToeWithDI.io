namespace TicTacToe.Core.Players
{
    public enum MoveStatus
    {
        Successful,
        Invalid,
        MoveToNextRule,
        Skpipped,
        AlreadyOccupied
    }
}