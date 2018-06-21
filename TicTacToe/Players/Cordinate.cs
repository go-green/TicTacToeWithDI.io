namespace TicTacToe.Core.Players
{
    public class Cordinate
    {
        public Cordinate(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public Cordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Cordinate()
        {
        }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsOccupied { get; set; }
        public char Symbol { get; set; }
    }
}