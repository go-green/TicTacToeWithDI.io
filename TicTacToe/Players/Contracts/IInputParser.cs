namespace TicTacToe.Core.Players.Contracts
{
    public interface IInputParser
    {
        MoveResult Parse(string input);
    }
}