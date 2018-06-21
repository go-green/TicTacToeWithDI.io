using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Core.Game
{
    public class Constants
    {
        public const char X = 'X';
        public const char O = 'O';
        public const string CURRENTBOARD = "Here's the current board:";
        public const string POSITIONOCCUPIED = "Oh no, a piece is already at this place! Try again...";
        public const string MOVEACCEPTED = "Move accepted, Here's the current board:";
        public const string WELCOME = "Welcome to Tic Tac Toe!";
        public const string YOUWON = "Move accepted, well done you've won the game!";
        public const string INVALIDCORDINATES = "Invalid cordinates provided, Please try again!";
        public const string ENTERCORDINATES = "Player {0} enter a coord x,y to place your {1} or enter 'q' to give up:";
        public const string ALLPOSITIONSOCCUPIED = "Oh no, All positions filled without winning cordinates and the game draws!";
    }
}
