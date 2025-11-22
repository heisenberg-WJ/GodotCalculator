


namespace Calculator.Tokens
{
    //考虑如何加入括号
    public enum TokenType
    {
        Value, Operator1, Operator2
    }

    public class Token
    {
        public TokenType Type;

        /// <summary>
        /// 显示的文本
        /// </summary>
        public string Text { get; set; }

        public virtual void Input(string input)
        {
            Text = input;
        }

        public bool IsEmpty() => string.IsNullOrEmpty(Text);



    }//一个最Token最基本的功能是存储一个字符串
}
