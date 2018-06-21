using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Players.Contracts;

namespace TicTacToe.Core.Players
{
    public class InputParser : IInputParser
    {
        private IList<IInputValidationRule> _inputValidationRules;
        public InputParser()
        {
            _inputValidationRules = new List<IInputValidationRule>
            {
                new InputValidationRules.NullChecker(),
                new InputValidationRules.SkippCodeChecker(),
                new InputValidationRules.InputParser(),
                new InputValidationRules.InputLengthChecker(),
                new InputValidationRules.IntegerParser()
            };
        }
        public MoveResult Parse(string input)
        {
            return _inputValidationRules
                .OrderBy(x => x.RuleID)
                .Select(x => x.Validate(input))
                .FirstOrDefault(x => x.Status != MoveStatus.MoveToNextRule);
        }
    }
}
