 

namespace Calculator.Tokens
{
    public enum DoubleOperatorType
    {
        Add, Sub, Mul, Div,
    }



    //操作符提供计算功能
    //这两个加一个基类

    public abstract class TokenOperator : Token {
        public int Priority;

    }


    /// <summary>
    /// 一元操作符
    /// </summary>
    public class TokenOperatorSingle : TokenOperator//细分类型+-*/。且不需要退格和输入，只有创建和删除,将计算公式定义在内部，外部传值直接调用方法即可获得结果
    {
        public TokenOperatorSingle()
        {
            Priority = 3;
        }
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
        public readonly DoubleOperatorType OperatorType;

        public TokenOperatorDouble(DoubleOperatorType type)
        {
            OperatorType = type;
            SetPriority();

        }

        private void SetPriority()
        {
            switch (OperatorType)
            {
                case DoubleOperatorType.Add:
                    Priority = 1;
                    break;
                case DoubleOperatorType.Sub:
                    Priority = 1;
                    break;
                case DoubleOperatorType.Mul:
                    Priority = 2;
                    break;
                case DoubleOperatorType.Div:
                    Priority = 2;
                    break;
            }
        }

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
