using Calculator.Tokens;

namespace Calculator
{
    public class CommandKey : CalculatorKey
    {
        public CommandEnum Command;

        public CommandKey(int id, string input, CommandEnum command) : base(id, input)
        {
            Command = command;
        }
 
        protected override Token CreateToken() => new TokenCommand(Command);
 
    }
}