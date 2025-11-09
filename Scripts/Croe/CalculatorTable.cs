using Godot;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Calculator
{
    /// <summary>
    /// 用于计算的工作台
    /// </summary>
    public class CalculateTable
    {
        public IToken _currentToken;

        public List<IToken> Tokens = [];

        /// <summary>
        /// Token的数量
        /// </summary>
        public int TokenQuantity => GetLengthList(Tokens);

        public List<IToken> Values = [];
        public List<IToken> Operators = [];

        public CalculateTable()
        {
            _currentToken = CreateToken<TokenValue>();
 
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
                case IToken.Type.BackSpace:
                    BackSpace();
                    break;
                case IToken.Type.Clear:
                    Clear();
                    break;
                case IToken.Type.Equals:
                    Equles();
                    break;
                default:
                    break;
            }

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
        }

        public string GetTexts()
        {
            string _all_text = "";
            foreach (IToken token in Tokens)
            {
                _all_text += token.Text;
            }
            return _all_text;
        }

        public void BackSpace()
        {
            bool is_empty = _currentToken.Backspace();

            if (!is_empty)
            {
                //检查是否是最后一个值token
                if (TokenQuantity == 1)
                {
                    _currentToken.Input("0");//就给他强制设置为0
                }
                else//否则
                {
                    RemoveToken(_currentToken);  //删除这个token
                    _currentToken = Tokens[TokenQuantity - 1];
                }
            }
        }

        public void Clear()
        {
            Tokens.Clear();
            Values.Clear();
            Operators.Clear();
            _currentToken = CreateToken<TokenValue>();
        }

        private T CreateToken<T>() where T : IToken, new()
        {
            var token = new T();
            RecordToken<T>(token);
            return token;
        }

        /// <summary>
        /// 记录这个Token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        private T RecordToken<T>(T token) where T : IToken, new()
        {
            if (token == null) return token;

            Tokens.Add(token);
            if (token is TokenValue)
            {
                Values.Add(token);
            }
            else
            {
                Operators.Add(token);
            }
            return token;
        }

        /// <summary>
        /// 在所有列表中移除这个Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool RemoveToken(IToken token)
        {
            bool _removed;

            if (token is TokenValue)
                _removed = Values.Remove(token);
            else
                _removed = Operators.Remove(token);

            _removed |= Tokens.Remove(token);
            return _removed;
        }


        public int GetLengthList<T>(List<T> values) where T : class
        {
            int _length = 0;
            foreach (T value in values)
            {
                _length++;
            }
            return _length;
        }

        public void Equles()//需要优化
        {
            double equals = CalculateCore.Equals2(Values, Operators);
            var equals_op = CreateToken<TokenOperator>();
            equals_op.Input("=");
            var equals_value = CreateToken<TokenValue>();
            equals_value.Input(equals.ToString());
        }

    }




    /// <summary>
    /// 计算算法核心
    /// </summary>
    public class CalculateCore
    {
        private List<IToken> Values;
        private List<IToken> Operators;

        public static double Equals2(List<IToken> values, List<IToken> operators)
        {
            //将Token列表转换成数字列表和字符列表。
            double result = 0;

            foreach (var item in operators)
            {
                if (item.ToString() != "+")
                {
                    double rigth = ((TokenValue)values[values.Count - 1]).Value;
                    values.RemoveAt(values.Count - 1);
                    double left = ((TokenValue)values[values.Count - 1]).Value;
                    result =  left + rigth;
                    GD.Print($" {left} + {rigth} = {result}");
                }
            }
            return result; 
        }

    }
}
