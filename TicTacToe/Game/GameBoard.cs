using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Game.Contracts;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.Game
{
    public class GameBoard : IGameBoard
    {
        private const int GRID_WIDTH = 3;
        private const int GRID_HEIGHT = 3;
        private const char SYMBOL = '*';

        public GameBoard()
        {
            Cordinates = InitializeGrid(GRID_HEIGHT, GRID_WIDTH, SYMBOL);
        }

        public IEnumerable<Cordinate> Cordinates { get; set; }

        private bool IsOccupied(Cordinate cords)
        {
            return Cordinates.Single(x => x.X == cords.X && x.Y == cords.Y).IsOccupied;
        }

        public void Update(Cordinate cords)
        {
            if (!IsOccupied(cords))
            {
                UpdateGridStatus(cords);
            }
        }

        private void UpdateGridStatus(Cordinate cords)
        {
            var cordinate = Cordinates.Single(x => x.X == cords.X && x.Y == cords.Y);
            cordinate.IsOccupied = true;
            cordinate.Symbol = cords.Symbol;
        }

        public void Reset()
        {
            Cordinates = InitializeGrid(GRID_HEIGHT, GRID_WIDTH, SYMBOL);
        }


        public void Draw()
        {
            var rows = Cordinates.GroupBy(g => g.X);
            foreach (var row in rows)
            {
                foreach (var cordinate in row.Select(c => c)) Console.Write($"{cordinate.Symbol} ");
                Console.WriteLine();
            }
        }

        private static IList<Cordinate> InitializeGrid(int _length, int _height, char symbol)
        {
            var cordinates = new List<Cordinate>();
            for (var i = 1; i <= _length; i++)
                for (var j = 1; j <= _height; j++)
                {
                    var cord = new Cordinate(i, j, symbol) { IsOccupied = false };
                    cordinates.Add(cord);
                }
            return cordinates;
        }
    }
}