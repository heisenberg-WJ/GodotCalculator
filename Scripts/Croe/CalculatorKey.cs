using System;

namespace Calculator
{
    /// <summary>
    /// 计算器按键
    /// </summary>
    public class CalculatorKey
    {
        /// <summary>
        /// 外部通过ID绑定按键
        /// </summary>
        public readonly int Id;

        public string Input = "0";
        public IToken.Type Type = IToken.Type.Value;

        public Action<string, IToken.Type> OnButton;

        public CalculatorKey(int id)
        {
            Id = id;
        }
  
        public void Init(string str, IToken.Type type)
        {
            Input = str;
            this.Type = type; 
        }

        public void Clicked()
        {
            OnButton.Invoke(Input, Type);
        }
    }
}
