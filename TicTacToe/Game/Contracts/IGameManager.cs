namespace TicTacToe.Core.Game.Contracts
{
    public interface IGameManager
    {
        void Play();
        void StartNewGame();
        void Stop();
        void Reset();
    }
}