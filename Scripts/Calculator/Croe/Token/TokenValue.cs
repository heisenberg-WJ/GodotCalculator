


namespace Calculator.Tokens
{


    public class TokenValue : Token//后续修改，只有符合规定的值才能输入.创建时可以选择一个初始值
    {

        public double Value => Parse(Text);
        public int Length => Text.Length;

        private int _maxLength = 15;

        #region  C T O R 
        public TokenValue()
        {

        }
        public TokenValue(string str)
        {
            Text = str;
        }
        public TokenValue(double value)
        {
            Text = value.ToString();
        }
        #endregion

        public override void Input(string input)
        {
            //后续会完成输入检测
            if (!IsEmpty())
            {
                bool outLength = Text.Length >= _maxLength;
                if (outLength) return;
            }

            if (input == ".")
            {
                InputPint();
                return;
            }

            if (Text == "0")
                Text = input;
            else
                Text += input;

        }

        public void Input(int value)
        {
            Input(value.ToString());
        }

        public bool InputPint()
        {
            if (CheckPoint()) return false;
            Text += '.';
            return true;
        }

        public bool CheckPoint() => Text.Contains(".");


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

    }//增加了表示数字的方法功能

   


}




