using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Players;

namespace TicTacToe.Core.GameRules
{
    public class SquareWinningCordinateSetGenerator
    {
        private readonly int GRID_WIDTH = 3; 
        private readonly int GRID_HEIGHT = 3;
        public IEnumerable<CordinateSet> GetWinningCordinateSetPermutations()
        {
            var lines = new List<CordinateSet>();
            try
            {
                lines.AddRange(GetRowCordinateSets());
                lines.AddRange(GetColumnCordinateSets());
                lines.Add(GetLeftDiagonalCordinates());
                lines.Add(GetRightDiagonalCordinates());
            }
            catch (Exception e)
            {
            }

            return lines;
        }


        private IEnumerable<CordinateSet> GetRowCordinateSets()
        {
            
            return Enumerable.Range(1, GRID_WIDTH).Select(GetRowCordinates);
        }

        private IEnumerable<CordinateSet> GetColumnCordinateSets()
        {
            
            return Enumerable.Range(1, GRID_HEIGHT).Select(GetColumnCordinates);
        }

        private CordinateSet GetRowCordinates(int rowNumber)
        {
            var winningCordinates = new CordinateSet();
            for (var c = 1; c <= GRID_WIDTH; c++)
            {
                var cords = new Cordinate
                {
                    X = rowNumber,
                    Y = c
                };
                winningCordinates.Set(cords);
            }

            return winningCordinates;
        }

        private CordinateSet GetColumnCordinates(int columnNumber)
        {
            var winningCordinates = new CordinateSet();
            for (var r = 1; r <= GRID_HEIGHT; r++)
            {
                var cords =
                    new Cordinate
                    {
                        X = r,
                        Y = columnNumber
                    };
                winningCordinates.Set(cords);
            }

            return winningCordinates;
        }

        private CordinateSet GetLeftDiagonalCordinates()
        {
            var rowCounter = 0;
            var winningCordinates = new CordinateSet();
            foreach (var set in GetRowCordinateSets())
            {
                var cords = set.Get().ToArray()[rowCounter];
                rowCounter++;
                winningCordinates.Set(cords);
            }

            return winningCordinates;
        }

        private CordinateSet GetRightDiagonalCordinates()
        {
            var rowCounter = GRID_WIDTH - 1;
            var winningCordinates = new CordinateSet();
            foreach (var set in GetRowCordinateSets())
            {
                var cords = set.Get().ToArray()[rowCounter];
                rowCounter--;
                winningCordinates.Set(cords);
            }
            return winningCordinates;
        }
    }
}

