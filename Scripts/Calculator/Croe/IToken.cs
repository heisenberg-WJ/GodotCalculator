namespace Calculator
{
    public interface IToken//这个东西要改，Token是Token，Key是Key
    {
        public enum Type
        {
            Value, Operator, BackSpace, Clear, Equals
        }

        public string Text { get; set; }

        /// <summary>
        /// return false时应该要删除这个对象，因为他已经是空的字符了
        /// </summary>
        /// <returns></returns>
        bool Backspace();

        void Input(string input);
    }

    public class TokenValue : IToken
    {
        public string Text { get; set; }//表面值
        public double Value => Parse(Text);
        public int Length => Text.Length;

        private int _maxLength = 15;
        public TokenValue()
        {
            Text = "0";
        }



        public void Input(string input)
        {
            bool outLength = Text.Length >= _maxLength;
            if (outLength) return;
            //检查小数点
            if (input == ".")
            {
                AddPoint();
                return;
            }
             

            if (Text == "0")
                Text = input;
            else
                Text += input;


            void AddPoint()
            {
                if (Text.Contains('.'))
                    return;
                Text += '.';
            }
        }



        public bool Backspace()
        {
            Text = Text.Substring(0, Length - 1);
            if (Length <= 0) return false;
            return true;
        }

        private double Parse(string number)
        {
            if (Length == 0) return 0;
            var b = number[number.Length - 1] == '.';
            if (b)
            {
                number = number.Substring(0, number.Length - 1);
            }
            return double.Parse(number);
        }

        private readonly char[] _numbers = ['.', '0', '1', '2', '3'];//合法的输入集合

        private bool CheckInputrValid(char s)//在考虑要不要做检查
        {
              
            return true;
        }


    }

    public class TokenOperator : IToken
    {
        public enum OperatorType
        {
            Add,Sub
        }

        public string Text { get; set; }



        public bool Backspace()
        {
            Text = Text.Substring(0, Text.Length - 1);
            if (Text.Length <= 0) return false;
            return true;
        }

        public void Input(string input)
        {
            Text = input;
        }


    }

}




