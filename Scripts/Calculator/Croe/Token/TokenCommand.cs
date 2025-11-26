 

namespace Calculator.Tokens
{
    public enum CommandEnum
    {
        Pint, BackSpace, Clear, Equal
    }
    public class TokenCommand : Token
    {
        public readonly CommandEnum Command;

        public TokenCommand(CommandEnum command)
        {
            this.Command = command;
        }
    }

}

