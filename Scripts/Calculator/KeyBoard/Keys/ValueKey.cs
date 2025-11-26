using Calculator.Tokens;

namespace Calculator
{
    public class ValueKey : CalculatorKey
    {
        public ValueKey(int id, string input) : base(id, input)
        {

        }

 
        protected override Token CreateToken() => new TokenValue();
       
    }
}