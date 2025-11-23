


namespace Calculator.Tokens
{

    public class Token
    {
        /// <summary>
        /// 显示的文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 输入字符串
        /// </summary>
        /// <param name="input"></param>
        public virtual void Input(string input)
        {
            Text = input;
        }

        /// <summary>
        /// Text是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => string.IsNullOrEmpty(Text);

    }
}
