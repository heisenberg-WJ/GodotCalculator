using System.Collections.Generic;

namespace Calculator 
{
    /// <summary>
    /// 计算器键盘
    /// </summary>
    public class CalculatorKeyBoard
    {
        //这里生成所有按键信息后，在Godot中创建按钮UI与其一一对应。

        public Dictionary<int, CalculatorKey> Keys = [];
        private CalculateTable _table;
        public CalculatorKeyBoard(CalculateTable table)
        {
            _table = table;
        }



        /// <summary>
        /// 本质是TryAdd()
        /// </summary>
        /// <param name="index"></param>
        /// <param name="key"></param>
        public bool TryAdd(int index, CalculatorKey key)
        {
            bool _added = Keys.TryAdd(index, key);
            if (_added)
            {
                key.OnButton += _table.Input;
            }
            return _added;
        }

        public bool Remove(int index)
        {
            bool _geted = Keys.TryGetValue(index, out CalculatorKey key);
            if (_geted)
            {
                key.OnButton -= _table.Input;
            }
            return Keys.Remove(index);
        }

        public bool Clear()
        {
            foreach (CalculatorKey item in Keys.Values)
            {
                item.OnButton -= _table.Input;
            }
            Keys.Clear();
            return Keys.Values.Count == 0;
        }


    }
}
