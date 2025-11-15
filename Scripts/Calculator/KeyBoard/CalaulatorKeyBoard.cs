using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// 计算器的键盘
    /// </summary>
    public class CalculatorKeyBoard
    { 
        private CalculateTable _table;
        private readonly Dictionary<int, CalculatorKey> Keys = [];
        public CalculatorKeyBoard(CalculateTable table)
        {
            _table = table;
        }

        public void KeyInput(string input, IKey.Type keytype)
        {
            switch (keytype)
            {
                case IKey.Type.None:

                    break;
                case IKey.Type.Value:
                    _table.Input(input, IToken.Type.Value);
                    break;
                case IKey.Type.Operator:
                    _table.Input(input, IToken.Type.Operator);
                    break;
                case IKey.Type.Command:

                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 自动使用key中定义的ID
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool TryAdd(CalculatorKey key)
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
            bool _geted = Keys.TryGetValue(index, out CalculatorKey key);
            if (_geted)
            {
                key.Clear();
            }
            return Keys.Remove(index);
        }

        public bool Remove(CalculatorKey key)
        {
            bool _geted = Keys.TryGetValue(key.ID, out CalculatorKey _outkey);
            if (_geted)
            {
                _outkey.Clear();
            }
            return Keys.Remove(_outkey.ID);
        }

        public bool Clear()
        {
            foreach (CalculatorKey key in Keys.Values)
            {
                key.Clear();
            }
            Keys.Clear();
            return Keys.Values.Count == 0;
        }

        public CalculatorKey TryGet(int index)
        {
            Keys.TryGetValue(index, out CalculatorKey key);
            return key;
        }

        public Dictionary<int, CalculatorKey> GetKeys() => Keys;


    }
}
