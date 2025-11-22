using System;
using System.Collections.Generic;
using System.Data;

namespace Calculator
{


    /// <summary>
    /// 为Gui界面提供绑定锚点
    /// </summary>
    public class CalculatorKeyBoard//还需要完善
    {
        private CalculateTable _table;
        private readonly Dictionary<int, CalKey> Keys = [];
        public CalculatorKeyBoard(CalculateTable table)
        {
            _table = table;
        }

        public void KeyInput(KeyType keytype, Token token)
        {

            switch (keytype)
            {
                case KeyType.Token:
                    
                    break;

                case KeyType.Value:
                    _table.InputToken(token);

                    break;

                case KeyType.Operator:

                    _table.InputToken(token);

                    break;


                case KeyType.Command:

                    string str = token.Text;
                    if (str == "AddPint")
                    {
                        _table.InputPint();
                    }
                    if (str == "BackSpace")
                    {
                        _table.BackSpace();
                    }
                    if (str == "Clear")
                    {
                        _table.Clear();
                    }
                    if (str == "Equal")
                    {
                        _table.Equal();
                    }
                  
                    break;


            }
        }

        //public void KeyInput(string input, KeyType keytype)
        //{
        //    switch (keytype)
        //    {
        //        case KeyType.None:
        //            break;

        //        case KeyType.Value:
        //            //  _table.Input(input, IToken.TokenType.Value);
        //            break;

        //        case KeyType.Operator:
        //            var op = new TokenOperatorSingle();
        //            op.Init(DoubleOperatorType.Add);
        //            //  _table.Input(input, IToken.TokenType.Operator);

        //            break;


        //        case KeyType.Command:

        //            break;


        //    }
        //}


        /// <summary>
        /// 自动使用key中定义的ID
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool TryAdd(CalKey key)
        {
            bool _added = Keys.TryAdd(key.ID, key);
            if (_added)
            {
                key.OnClicked += KeyInput;
            }
            return _added;
        }

        public bool Remove(int index)
        {
            bool _geted = Keys.TryGetValue(index, out CalKey key);
            if (_geted)
            {
                key.Clear();
            }
            return Keys.Remove(index);
        }

        public bool Remove(CalKey key)
        {
            bool _geted = Keys.TryGetValue(key.ID, out CalKey _outkey);
            if (_geted)
            {
                _outkey.Clear();
            }
            return Keys.Remove(_outkey.ID);
        }

        public bool Clear()
        {
            foreach (CalKey key in Keys.Values)
            {
                key.Clear();
            }
            Keys.Clear();
            return Keys.Values.Count == 0;
        }

        public CalKey TryGet(int index)
        {
            Keys.TryGetValue(index, out CalKey key);
            return key;
        }

        public Dictionary<int, CalKey> GetKeys() => Keys;


    }
}
