

using Godot;

namespace Calculator.Tokens
{
    /// <summary>
    /// 操作符优先级
    /// </summary>
    public static class PriorityLevels
    {
        public const int Low = 1;    // 例如：+，-
        public const int Medium = 2; // 例如：*，/
        public const int High = 3;   // 例如：一元操作符
        public const int Default = -1;// 默认值
    }



    /// <summary>
    /// 操作符Token (提供计算功能)
    /// </summary>
    public abstract class TokenOperator : Token //将计算公式定义在内部，外部传值直接调用方法即可获得结果
    {
        /// <summary>
        /// 优先级 (越大越优先)
        /// </summary>
        public abstract int Priority { get; }

    }


    /// <summary>
    /// 一元操作符
    /// </summary>
    public class TokenOperatorSingle : TokenOperator
    {
        public override int Priority => PriorityLevels.High;


        public bool Calculate(double value, out double reults)//未完成
        {
            reults = 0;

            return true;
        }

    }


    /// <summary>
    /// 二元操作符类型
    /// </summary>
    public enum DoubleOperatorType
    {
        Add, Sub, Mul, Div,
    }

    /// <summary>
    /// 二元操作符
    /// </summary>
    public class TokenOperatorDouble : TokenOperator
    {
        private readonly int _priority;
        public override int Priority => _priority;

        public readonly DoubleOperatorType OperatorType;
        public TokenOperatorDouble(DoubleOperatorType type)
        {
            OperatorType = type;
            _priority = GetPriority();
        }

        /// <summary>
        /// 计算优先级
        /// </summary>
        /// <returns></returns>
        private int GetPriority()
        {
            switch (OperatorType)
            {
                case DoubleOperatorType.Add or DoubleOperatorType.Sub:
                    return PriorityLevels.Low;

                case DoubleOperatorType.Mul or DoubleOperatorType.Div:
                    return PriorityLevels.Medium;
                default:
                    return PriorityLevels.Default;
            }
        }

        /// <summary>
        /// 计算，返回true时tip为空，返回false时tip中的信息就是错误提示
        /// </summary>
        /// <param name="left">左数</param>
        /// <param name="right">右数</param>
        /// <param name="reults">结果</param>
        /// <param name="tip">提示信息</param>
        /// <returns></returns>
        public bool Calculate(double left, double right, out double reults, out string tip)
        {
            bool _is_valid = true;
            tip = "";
            reults = 0;

            switch (OperatorType)
            {
                case DoubleOperatorType.Add:
                    reults = left + right;
                    break;

                case DoubleOperatorType.Sub:
                    reults = left - right;
                    break;

                case DoubleOperatorType.Mul:
                    reults = left * right;
                    break;

                case DoubleOperatorType.Div:
                    if (right == 0)
                    {
                        tip = "除数不能为0";
                        _is_valid = false;
                    }
                    else
                    {
                        reults = left / right;
                    }
                    break;

            }
            if (!_is_valid) reults = 0;

            return _is_valid;
        }

    }


}
