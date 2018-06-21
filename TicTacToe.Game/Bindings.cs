
using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Modules;
using TicTacToe.Core.Game;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.GameRules;
using TicTacToe.Core.GameRules.Contracts;
using TicTacToe.Core.Logger;
using TicTacToe.Core.Logger.Contracts;
using TicTacToe.Core.Players;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Game
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<NLogger>();
            Bind<IGameStatusUpdateService>().To<GameStatusUpdateService>().WithConstructorArgument("players", GetPlayers());
            Bind<IPlayerInteractionService>().To<ConsoleInteractionService>().InSingletonScope();
            Bind<IGameRule>().To<GameRuleService>().InSingletonScope();
            Bind<IGameBoard>().To<GameBoard>();
            Bind<IGameStatus>().To<GameStatus>().InSingletonScope();
            Bind<IGameManager>().To<GameManager>();
        }

        private static IEnumerable<IPlayer> GetPlayers()
        {
            IList<IPlayer> players = new List<IPlayer>();
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IInputParser>().To<InputParser>().InSingletonScope();
                kernel.Bind<IPlayerInteractionService>().To<ConsoleInteractionService>().InSingletonScope();
                kernel.Bind<ILogger>().To<NLogger>();
                kernel.Bind<IPlayer>().To<Player>();
                var player1 = kernel.Get<IPlayer>();
                var player2 = kernel.Get<IPlayer>();
                players.Add(player1);
                players.Add(player2);
            }
            return players;
        }
    }
}
