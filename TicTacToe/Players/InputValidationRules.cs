using System;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Players
{
    public class InputValidationRules
    {

        public class NullChecker : IInputValidationRule
        {
            private readonly MoveResult _moveResult;

            public NullChecker()
            {
                _moveResult = new MoveResult();
            }
            public int RuleID => 0;
            public MoveResult Validate(string playerInput)
            {
                if (string.IsNullOrWhiteSpace(playerInput))
                {
                    _moveResult.Status = MoveStatus.Invalid;
                    return _moveResult;
                }
                _moveResult.Status = MoveStatus.MoveToNextRule;
                return _moveResult;
            }
        }

        public class SkippCodeChecker : IInputValidationRule
        {
            public const string SKIPPEDPCODE = "q";
            private readonly MoveResult _moveResult;

            public SkippCodeChecker()
            {
                _moveResult = new MoveResult();
            }
            public int RuleID => 1;
            public MoveResult Validate(string playerInput)
            {
                if (playerInput.ToLower().Trim().Equals(SKIPPEDPCODE))
                {
                    _moveResult.Status = MoveStatus.Skpipped;
                    return _moveResult;
                }
                _moveResult.Status = MoveStatus.MoveToNextRule;
                return _moveResult;
            }
        }

        public class InputParser : IInputValidationRule
        {
            private readonly MoveResult _moveResult;

            public InputParser()
            {
                _moveResult = new MoveResult();
            }
            public int RuleID => 2;

            public MoveResult Validate(string playerInput)
            {
                try
                {
                    playerInput.Split(',');
                    _moveResult.Status = MoveStatus.MoveToNextRule;
                }
                catch (Exception)
                {
                    _moveResult.Status = MoveStatus.Invalid;
                    return _moveResult;
                }
                return _moveResult;
            }
        }


        public class InputLengthChecker : IInputValidationRule
        {
            private readonly MoveResult _moveResult;

            public InputLengthChecker()
            {
                _moveResult = new MoveResult();
            }
            public int RuleID => 3;

            public MoveResult Validate(string playerInput)
            {

                if (playerInput.Split(',').Length > 2)
                {
                    _moveResult.Status = MoveStatus.Invalid;
                    return _moveResult;
                }
                _moveResult.Status = MoveStatus.MoveToNextRule;
                return _moveResult;
            }
        }


        public class IntegerParser : IInputValidationRule
        {
            private readonly MoveResult _moveResult;

            public IntegerParser()
            {
                _moveResult = new MoveResult();
            }
            public int RuleID => 4;

            public MoveResult Validate(string playerInput)
            {
                try
                {
                    var cordsAsArray = playerInput.Split(',');
                    var x = Convert.ToInt32(cordsAsArray[0]);
                    var y = Convert.ToInt32(cordsAsArray[1]);
                    if (x >= 1 && y >= 1 && y <= 3 && x <= 3)
                    {
                        _moveResult.Cordinate.X = x;
                        _moveResult.Cordinate.Y = y;
                        _moveResult.Status = MoveStatus.Successful;
                        return _moveResult;
                    }
                    throw new Exception();
                }
                catch (Exception)
                {
                    _moveResult.Status = MoveStatus.Invalid;
                    return _moveResult;
                }
            }
        }
    }
}
