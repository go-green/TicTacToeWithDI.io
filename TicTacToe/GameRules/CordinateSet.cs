﻿using System.Collections.Generic;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.GameRules
{
    public class CordinateSet
    {
        private readonly IList<Cordinate> _line;
        public CordinateSet()
        {
            _line = new List<Cordinate>();
        }

        public void Set(Cordinate cords)
        {
            _line.Add(cords);
        }

        public IEnumerable<Cordinate> Get()
        {
            return _line;
        }
    }
}
