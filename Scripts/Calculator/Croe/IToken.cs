using Godot;
using System;
using System.Collections.Generic;

namespace Calculator
{
    //需要完善，目前功能太死板，运算符和数值Token需要优化，考虑如何加入括号
    public enum TokenType
    {
        Value, Operator1, Operator2
    }

    public class Token//输入Token是执行Input方法，输入它的子类就是替换Token或新增Token
    {
        public TokenType Type;

        /// <summary>
        /// 显示的文本
        /// </summary>
        public string Text { get; set; }

        public virtual void Input(string input)
        {
            Text = input;
        }

        public bool IsEmpty() => string.IsNullOrEmpty(Text);



    }//一个最Token最基本的功能是存储一个字符串

    public class TokenValue : Token//后续修改，只有符合规定的值才能输入.创建时可以选择一个初始值
    {

        public double Value => Parse(Text);
        public int Length => Text.Length;

        private int _maxLength = 15;

        #region  C T O R 
        public TokenValue()
        {

        }
        public TokenValue(string str)
        {
            Text = str;
        }
        public TokenValue(double value)
        {
            Text = value.ToString();
        }
        #endregion

        public override void Input(string input)
        {
            //后续会完成输入检测
            if (!IsEmpty())
            {
                bool outLength = Text.Length >= _maxLength;
                if (outLength) return;
            }

            if (input == ".")
            {
                InputPint();
                return;
            }

            if (Text == "0")
                Text = input;
            else
                Text += input;

        }

        public void Input(int value)
        {
            Input(value.ToString());
        }

        public bool InputPint()
        {
            if (CheckPoint()) return false;
            Text += '.';
            return true;
        }

        public bool CheckPoint() => Text.Contains(".");


        public bool Backspace()
        {
            Text = Text.Substring(0, Length - 1);
            if (Length <= 0) return false;
            return true;
        }



        private double Parse(string number)
        {
            if (Length == 0) return 0;
            var b = number[number.Length - 1] == '.';
            if (b)
            {
                number = number.Substring(0, number.Length - 1);
            }
            return double.Parse(number);
        }

    }//增加了表示数字的方法功能

    public enum DoubleOperatorType
    {
        Add, Sub, Mul, Div,
    }



    //操作符提供计算功能
    //这两个加一个基类

    public abstract class TokenOperator : Token { }


    /// <summary>
    /// 一元操作符
    /// </summary>
    public class TokenOperatorSingle : TokenOperator//细分类型+-*/。且不需要退格和输入，只有创建和删除,将计算公式定义在内部，外部传值直接调用方法即可获得结果
    {

        public bool Calculate(double value, out double re)
        {
            re = 0;

            return true;
        }


    }

    /// <summary>
    /// 二元操作符
    /// </summary>
    public class TokenOperatorDouble : TokenOperator
    {
        public DoubleOperatorType OperatorType = DoubleOperatorType.Add;


        public bool Calculate(double left, double rigth, out double reults)
        {
            reults = 0;
            switch (OperatorType)
            {
                case DoubleOperatorType.Add:
                    reults = left + rigth;
                    break;
                case DoubleOperatorType.Sub:
                    reults = left + rigth;
                    break;
                case DoubleOperatorType.Mul:
                    reults = left * rigth;
                    break;
                case DoubleOperatorType.Div:
                    if (rigth == 0)
                        return false;
                    reults = left / rigth;
                    break;
            }

            return true;
        }
    }




}




