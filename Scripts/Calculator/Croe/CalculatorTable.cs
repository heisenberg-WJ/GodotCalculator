using System;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator
{
    /// <summary>
    /// 计算器的工作台，用于计算
    /// </summary>
    public class CalculateTable//增加状态管理，计算中和计算结束
    {
        private Token _currentToken;//这个还有一点问题，等后续
        public Token CurrentToken => _currentToken;

        public List<Token> Tokens = [];

        public event Action OnTableUpdate;//还没有覆盖完所有场景，如果主动调用BackSpace等方法，不会触发事件

        public CalculateTable()
        {
            
        }

        public void InputToken(Token token)
        {
            //三种情况1输入token 2value 3operator
            if (token is Token)
            {

            }

            if (_currentToken is TokenValue)
            {
                if (token is TokenValue)
                {
                    _currentToken.Input(token.Text);
                }
                else
                {
                    Tokens.Add(token);
                    _currentToken = token;
                }

            }
            else if (_currentToken is TokenOperator)
            {
                if (token is TokenOperator)
                {
                    Tokens.Remove(_currentToken);
                }
                Tokens.Add(token);
                _currentToken = token;

            }

            OnTableUpdate?.Invoke();
        }

        public void InputPint()
        {
            if (_currentToken is TokenValue tokenValue)
            {
                tokenValue.InputPint();
            }
            else
            {
                TokenValue value = new TokenValue(0);
                value.InputPint();
                AddToken(value);
            }
            OnTableUpdate?.Invoke();
        }

        public void BackSpace()
        {
            if (_currentToken is TokenValue tokenvalue)//只有value会判断是否为空，并调用他的查空方法。
            {
                tokenvalue.Backspace();
                if (tokenvalue.IsEmpty())
                    RemoveToken();
            }
            else
            {
                RemoveToken();
            }
            OnTableUpdate?.Invoke();
        }

        public void Clear()
        {
            Tokens.Clear();
            IfTokensEmpyt();
            OnTableUpdate?.Invoke();
        }

        public void Equal()//需要优化
        {
            //将当前等式保存下来，用于历史记录
            //将当前Token格式转换成计算格式
            //执行核心方法来计算结果
            //输出结果 

            CalculateCore.Calculate(Tokens);

           // OnTableUpdate?.Invoke();
        }


        private void AddToken(Token token)
        {
            Tokens.Add(token);
            _currentToken = token;
        }

        /// <summary>
        /// 移除一个Token,不会导致Tokens列表为空，会始终留有一个Value
        /// </summary>
        private void RemoveToken()
        {
            Tokens.Remove(_currentToken);
            IfTokensEmpyt();
            _currentToken = Tokens[Tokens.Count - 1];
        }

        private void IfTokensEmpyt()
        {
            if (Tokens.Count == 0)
            {
                AddToken(new TokenValue(0));
            }
        }

        public void Init()
        {
            AddToken(new TokenValue(0));
            OnTableUpdate?.Invoke();
        }

    }

}
