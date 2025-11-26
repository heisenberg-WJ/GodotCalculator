using System;
using System.Collections.Generic;
using System.Data;
using Calculator.Tokens;

namespace Calculator
{
    /// <summary>
    /// 计算器的工作台
    /// </summary>
    public class CalculateTable
    {
        private Token _currentToken;
        public Token CurrentToken => _currentToken;//对比一下这两种方式，确定一个规范

        private List<Token> _tokens;
        public List<Token> GetTokens() => _tokens;//对比一下这两种方式，确定一个规范

        /// <summary>
        /// 计算器执行操作时的事件(输入)
        /// </summary>
        public event Action TableUpdate;

        /// <summary>
        /// 发布事件
        /// </summary>
        public void OnUpdateTable() => TableUpdate?.Invoke();


        public void Init()
        {
            _tokens = [];
            Input(new TokenValue(0));

        }

        //==========================================================


        public void Input(Token token)
        {
            if (_currentToken is TokenValue && token is TokenValue)
            {
                _currentToken.Input(token.Text);
            }
            else if (_currentToken is TokenOperator && token is TokenOperator)
            {
                RemoveToken();
                AddToken(token);
            }
            else
            {
                AddToken(token);
            }


            OnUpdateTable();
        }

        /// <summary>
        /// 增加小数点
        /// </summary>
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
                Input(value);
            }
        }

        /// <summary>
        /// 退格
        /// </summary>
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

        }

        /// <summary>
        /// 清空算式
        /// </summary>
        public void Clear()
        {
            _tokens.Clear();
            KeepTokensNotEmpty();

        }

        /// <summary>
        /// 等于,计算算式
        /// </summary>
        public void Equal()//需要优化
        {
            //将当前等式保存下来，用于历史记录
            //将当前Token格式转换成计算格式
            //执行核心方法来计算结果
            //输出结果 

            CalculateCore.Calculate(_tokens);


        }

        public void Command(CommandEnum command)
        {
            switch (command)
            {
                case CommandEnum.Pint:
                    InputPint();
                    break;
                case CommandEnum.BackSpace:
                    BackSpace();
                    break;
                case CommandEnum.Clear:
                    Clear();
                    break;
                case CommandEnum.Equal:
                    Equal();
                    break;
            }
            OnUpdateTable();
        }

        //==========================================================

        /// <summary>
        /// 添加一个Token，并自动更新为_currentToken
        /// </summary>
        /// <param name="token"></param>
        private void AddToken(Token token)
        {
            _tokens.Add(token);
            _currentToken = token;
        }

        /// <summary>
        /// 移除一个Token,不会导致Tokens列表为空，会始终留有一个Value
        /// </summary>
        private void RemoveToken()
        {
            _tokens.Remove(_currentToken);
            KeepTokensNotEmpty();
            _currentToken = _tokens[_tokens.Count - 1];
        }

        /// <summary>
        /// 保持Token列表不为空
        /// </summary>
        private void KeepTokensNotEmpty()
        {
            if (_tokens.Count == 0)
            {
                AddToken(new TokenValue(0));
            }
        }

        //==========================================================
    }

}
