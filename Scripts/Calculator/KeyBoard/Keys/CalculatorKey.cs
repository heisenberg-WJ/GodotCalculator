using Calculator.Tokens;
using System;

namespace Calculator
{
    //可以专门搞一个类，用来存储所有的按键，需要绑定的时候就直接从这个类里面调用响应的方法即可,外部就不用分那么多的枚举了

    public static class CalculatorKeyCreate
    {
        public static void BackSpace()
        {


        }
    }


    public abstract class CalculatorKey
    {
        public readonly int ID;
        public readonly string InputText;

        public CalculatorKey(int id, string input)
        {
            ID = id;
            InputText = input;
        }

        public event Action<Token> KeyClicked;

        /// <summary>
        /// 清空KeyClicked事件
        /// </summary>
        public void KeyClear() => KeyClicked = null;


        public virtual void Click()
        {
            Token token = CreateToken();
            if (token.IsEmpty())
                token.Input(InputText);
            OnKeyClicked(token);
        }

        protected void OnKeyClicked(Token token) => KeyClicked?.Invoke(token);


        protected abstract Token CreateToken();


    }

}
