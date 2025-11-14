using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// 计算器键盘
    /// </summary>
    public class CalculatorKeyBoard
    {
        //这里生成所有按键信息后，在Godot中创建按钮UI与其一一对应。
        //  public List<CalculatorKey> Keys = [];

        public Dictionary<int, CalculatorKey> Keys = [];

        public CalculatorKeyBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                string str = i.ToString();
                Keys.TryAdd(i, new CalculatorKey(i) { Input = str, Type = IToken.Type.Value });
            }
            Keys.TryAdd(10, new CalculatorKey(10) { Input = ".", Type = IToken.Type.Value });

            Keys.TryAdd(11, new CalculatorKey(11) { Input = "＋", Type = IToken.Type.Operator });
            Keys.TryAdd(12, new CalculatorKey(12) { Input = "－", Type = IToken.Type.Operator });
            Keys.TryAdd(13, new CalculatorKey(13) { Input = "×", Type = IToken.Type.Operator });
            Keys.TryAdd(14, new CalculatorKey(14) { Input = "÷", Type = IToken.Type.Operator });

            Keys.TryAdd(15, new CalculatorKey(15) { Input = "＝", Type = IToken.Type.Equals });
            Keys.TryAdd(16, new CalculatorKey(16) { Input = "BackSpace", Type = IToken.Type.BackSpace });
            Keys.TryAdd(17, new CalculatorKey(17) { Input = "Clear", Type = IToken.Type.Clear });

        }



        /// <summary>
        /// 绑定工作台，请在AddKey方法之后执行。
        /// </summary>
        /// <param name="table"></param>
        public void Init(CalculateTable table)
        {
            foreach (var key in Keys.Values)
            {
                key.OnButton += table.Input;
            }
        }
    }
}
