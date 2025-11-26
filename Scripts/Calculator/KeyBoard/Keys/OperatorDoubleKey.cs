using Calculator.Tokens;

namespace Calculator
{
    public class OperatorDoubleKey : CalculatorKey
    {
        public DoubleOperatorType OperatorType;

        public OperatorDoubleKey(int id, string input, DoubleOperatorType operatortype) : base(id, input)
        {
            OperatorType = operatortype;
        }

        protected override Token CreateToken() => new TokenOperatorDouble(OperatorType);


    }
}