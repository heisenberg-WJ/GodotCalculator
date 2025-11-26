using Calculator.Tokens;
using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// 为Gui界面提供绑定锚点
    /// </summary>
    public class CalculatorKeyBoard
    {
        private CalculateTable _table;
        private readonly Dictionary<int, CalculatorKey> Keys = [];
        public CalculatorKeyBoard(CalculateTable table)
        {
            _table = table;
        }


        public void KeyInput(Token token)
        {
            if (token is TokenCommand command)
            {
                _table.Command(command.Command); 
            }
            else
            {
                _table.Input(token);
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
                key.KeyClicked += KeyInput;
            }
            return _added;
        }

        public bool Remove(int index)
        {
            bool _geted = Keys.TryGetValue(index, out CalculatorKey key);
            if (_geted)
            {
                key.KeyClear();
            }
            return Keys.Remove(index);
        }

        public bool Remove(CalculatorKey key)
        {
            bool _geted = Keys.TryGetValue(key.ID, out CalculatorKey _outkey);
            if (_geted)
            {
                _outkey.KeyClear();
            }
            return Keys.Remove(_outkey.ID);
        }

        public bool Clear()
        {
            foreach (CalculatorKey key in Keys.Values)
            {
                key.KeyClear();
            }
            Keys.Clear();
            return Keys.Values.Count == 0;
        }

        public CalculatorKey TryGet(int index)
        {
            Keys.TryGetValue(index, out CalculatorKey key);
            return key;
        }

      //  public Dictionary<int, CalculatorKey> GetKeys() => Keys;


    }
}
