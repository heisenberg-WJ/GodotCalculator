using Calculator.Tokens;
using Godot;
using System.Collections.Generic;
namespace Calculator
{
    /// <summary>
    /// 计算算法核心
    /// </summary>
    public class CalculateCore
    {
        List<Token> result;

        Stack<TokenOperator> stack;



        public static void Calculate(List<Token> tokens)
        {
            List<Token> result;

            Stack<TokenOperator> stack;
            result = [];
            stack = [];

            foreach (Token token in tokens)
            {
                if (token is TokenValue)
                {
                    result.Add(token);
                }
                if (token is TokenOperator tokenOperator)
                {
                    while (stack.Count > 0)//stack只存一个
                    {
                        TokenOperator topOp = stack.Peek();
                        // 左结合运算符：当前优先级 <= 栈顶优先级时弹出
                        if (tokenOperator.Priority <= topOp.Priority)
                        {
                            result.Add(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }
                    stack.Push(tokenOperator);
                    GD.Print(tokenOperator.Text);
                }

            }
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            string str = "波兰 : ";
            foreach (Token token in result)
            {
                str += token.Text;
                str += " ";
            }

            GD.Print(str);

            Calculate2(result);
        }

        private static void Calculate2(List<Token> result)
        {
            Stack<double> value = [];

            foreach (Token token in result)
            {
                if (token is TokenValue tokenValue)
                {
                    value.Push(tokenValue.Value);
                }
                if (token is TokenOperator tokenOperator)
                {

                    if (tokenOperator is TokenOperatorDouble doubleOP)
                    {
                        double rigth = value.Pop();
                        double left = value.Pop();

                        doubleOP.Calculate(left, rigth, out double re);
                        value.Push(re);
                    }

                }
            }
            GD.Print(value.Pop());
        }

      

        //波兰表达式；构建时从右到左构建
        //结果列表，运算符列表
        //优先级越大，越优先计算
        //规则；
        //扫描时遇见数字直接加入结果列表。
        //遇到运算符先比较运算符列表中的优先级别(如果列表中的大,就将列表中所有的运算符加入结果表)，如果否，直接加入。
        //

        //2*2+1
        // 1 + 2 * 2
        //-------------------

        // 1 2 2
        // + *

        // 1 2 2 * +

        //逆波兰表达式；构建时从左到右构建
        //结果列表，运算符列表
        //优先级越大，越优先计算
        //规则；
        //扫描时遇见数字直接加入结果列表。
        //遇到运算符先比较运算符列表中的优先级别(如果列表中的大,就将列表中所有的运算符加入结果表)，如果否，直接加入。

        // 2 * 2 + 1 
        //-------------------

        // 2 2 * 1 +




        //public static double Calculate(List<IToken> values, List<IToken> operators)
        //{
        //    //将Token列表转换成数字列表和字符列表。
        //    double result = 0;

        //    foreach (var item in operators)
        //    {
        //        if (item.Text == "=")
        //        {
        //            break;
        //        }
        //        if (item.Text == "+")
        //        {
        //            double rigth = ((TokenValue)values[values.Count - 1]).Value;
        //            values.RemoveAt(values.Count - 1);
        //            double left = ((TokenValue)values[values.Count - 1]).Value;
        //            result = left + rigth;
        //            //GD.Print($" {left} + {rigth} = {result}");
        //        }
        //        if (item.Text == "-")
        //        {
        //            double rigth = ((TokenValue)values[values.Count - 1]).Value;
        //            values.RemoveAt(values.Count - 1);
        //            double left = ((TokenValue)values[values.Count - 1]).Value;
        //            result = left - rigth;
        //            //GD.Print($" {left} - {rigth} = {result}");
        //        }
        //        if (item.Text == "*")
        //        {
        //            double rigth = ((TokenValue)values[values.Count - 1]).Value;
        //            values.RemoveAt(values.Count - 1);
        //            double left = ((TokenValue)values[values.Count - 1]).Value;
        //            result = left * rigth;
        //           // GD.Print($" {left} * {rigth} = {result}");
        //        }
        //        if (item.Text == "/")
        //        {
        //            double rigth = ((TokenValue)values[values.Count - 1]).Value;
        //            values.RemoveAt(values.Count - 1);
        //            double left = ((TokenValue)values[values.Count - 1]).Value;
        //            result = left / rigth;
        //           // GD.Print($" {left} / {rigth} = {result}");
        //        }
        //    }
        //    return result;
        //}

        public class A
        {

        }

        public class B : A
        {
        }

        public void Check(A a)
        {
            if (a is B)
            {

            }
        }


    }
}
