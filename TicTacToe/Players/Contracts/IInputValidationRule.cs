namespace TicTacToe.Core.Players.Contracts
{
    public interface IInputValidationRule
    {
        int RuleID { get;  }

        MoveResult Validate(string input);
    }
}
