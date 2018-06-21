
using System.Reflection;
using Ninject;
using TicTacToe.Core.Game;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var gameManager = kernel.Get<IGameManager>();
            gameManager.StartNewGame();
        }
    }
}
