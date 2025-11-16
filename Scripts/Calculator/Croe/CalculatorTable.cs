using System;
using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// 计算器的工作台，用于计算
    /// </summary>
    public class CalculateTable//增加状态管理，计算中和计算结束
    {
        private IToken _currentToken;

        public List<IToken> Tokens = [];

        public event Action OnTableUpdate;//还没有覆盖完所有场景，如果主动调用BackSpace等方法，不会触发事件

        public CalculateTable()
        {
           // _currentToken = CreateToken<TokenValue>();
        }

        public void Init()
        {
            Input("0", IToken.Type.Value);
        }

        public void Input(string str, IToken.Type type)
        {
            switch (type)
            {
                case IToken.Type.Value:
                    AddNumber(str);
                    break;
                case IToken.Type.Operator:
                    AddOperator(str);
                    break;
                default:
                    break;
            }

            OnTableUpdate?.Invoke();

            #region SubMethod
            void AddNumber(string str)
            {
                if (_currentToken is TokenValue)
                {
                    _currentToken.Input(str);
                }
                else
                {
                    //创建新的Token
                    _currentToken = CreateToken<TokenValue>();
                    _currentToken.Input(str);
                }
            }

            void AddOperator(string str)
            {
                if (_currentToken is TokenOperator)
                {
                    _currentToken.Input(str);
                }
                else
                {
                    //创建新的Token
                    _currentToken = CreateToken<TokenOperator>();
                    _currentToken.Input(str);
                }
            }
            #endregion
        }

        public void BackSpace()
        {
            bool is_empty = _currentToken.Backspace();

            if (!is_empty)
            {
                //检查是否是最后一个值token
                if (Tokens.Count == 1)
                {
                    _currentToken.Input("0");//就给他强制设置为0
                }
                else//否则
                {
                    Tokens.Remove(_currentToken);  //删除这个token
                    _currentToken = Tokens[Tokens.Count - 1];
                }
            }
        }

        public void Clear()
        {
            Tokens.Clear();
            _currentToken = CreateToken<TokenValue>();
        }

        public void Equles()//需要优化
        {
            //将当前等式保存下来，用于历史记录
            //将当前Token格式转换成计算格式
            //执行核心方法来计算结果
            //输出结果




            // double equals = CalculateCore.Calculate(Values, Operators);
            // var equals_op = CreateToken<TokenOperator>();
            // equals_op.Input("=");
            //  var equals_value = CreateToken<TokenValue>();
            //  equals_value.Input(equals.ToString());
        }

        private T CreateToken<T>() where T : IToken, new()
        {
            var token = new T();
            Tokens.Add(token);
            return token;
        }

    }

}
