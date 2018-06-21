namespace TicTacToe.Core.Players
{
    public class MoveResult
    {
        public MoveResult()
        {
            Cordinate = new Cordinate();
        }

        public MoveStatus Status { get; set; }

        public Cordinate Cordinate { get; set; }
    }
}
