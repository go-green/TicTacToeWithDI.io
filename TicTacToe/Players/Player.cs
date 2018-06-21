using System;
using System.Collections.Generic;
using TicTacToe.Core.Logger;
using TicTacToe.Core.Logger.Contracts;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Players
{
    public class Player : IPlayer
    {
        private readonly IPlayerInteractionService _interactionService;
        private readonly IInputParser _inputParser;
        private string _playerInput;
        private readonly ILogger _logger;

        public Player(IPlayerInteractionService interactionService, IInputParser inputParser, ILogger logger)
        {
            _interactionService = interactionService;
            _inputParser = inputParser;
            _logger = logger;
            MoveCount = 0;
        }
        public char Symbol { get; set; }
        public int MoveCount { get; set; }
        public int Id { get; set; }

        public MoveResult Move()
        {
            try
            {
                _playerInput = _interactionService.GetPlayerInput();
            }
            catch (Exception e)
            {
                var entry = new LogEntry(LoggingEventType.Error, e.Message, e.InnerException);
                _logger.Log(entry);
            }
            return _inputParser.Parse(_playerInput);
        }
    }
}
