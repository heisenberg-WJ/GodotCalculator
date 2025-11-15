using System.Collections.Generic;

namespace Calculator
{ 
    /// <summary>
    /// 计算算法核心
    /// </summary>
    public class CalculateCore
    {
        private List<double> Values;
        private List<string> Operators;

        public static double Calculate(List<IToken> values, List<IToken> operators)
        {
            //将Token列表转换成数字列表和字符列表。
            double result = 0;

            foreach (var item in operators)
            {
                if (item.Text == "=")
                {
                    break;
                }
                if (item.Text == "+")
                {
                    double rigth = ((TokenValue)values[values.Count - 1]).Value;
                    values.RemoveAt(values.Count - 1);
                    double left = ((TokenValue)values[values.Count - 1]).Value;
                    result = left + rigth;
                    //GD.Print($" {left} + {rigth} = {result}");
                }
                if (item.Text == "-")
                {
                    double rigth = ((TokenValue)values[values.Count - 1]).Value;
                    values.RemoveAt(values.Count - 1);
                    double left = ((TokenValue)values[values.Count - 1]).Value;
                    result = left - rigth;
                    //GD.Print($" {left} - {rigth} = {result}");
                }
                if (item.Text == "*")
                {
                    double rigth = ((TokenValue)values[values.Count - 1]).Value;
                    values.RemoveAt(values.Count - 1);
                    double left = ((TokenValue)values[values.Count - 1]).Value;
                    result = left * rigth;
                   // GD.Print($" {left} * {rigth} = {result}");
                }
                if (item.Text == "/")
                {
                    double rigth = ((TokenValue)values[values.Count - 1]).Value;
                    values.RemoveAt(values.Count - 1);
                    double left = ((TokenValue)values[values.Count - 1]).Value;
                    result = left / rigth;
                   // GD.Print($" {left} / {rigth} = {result}");
                }
            }
            return result;
        }

        public static double Calculate(List<TokenValue> values, List<TokenOperator> operators)
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
                    result = left + rigth;
                   // GD.Print($" {left} + {rigth} = {result}");
                }
            }
            return result;
        }

        public static double Calculate()
        {
            return 0;
        }

    }
}
