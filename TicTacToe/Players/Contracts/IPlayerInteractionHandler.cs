namespace TicTacToe.Core.Players.Contracts
{
    public interface IPlayerInteractionService
    {
        string GetPlayerInput();
        void SetPlayerOutPut(string output);
    }
}