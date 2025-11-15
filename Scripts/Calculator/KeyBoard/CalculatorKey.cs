using Godot;
using System;

namespace Calculator
{
    public interface IKey
    {
        public enum Type
        {
            None, Value, Operator, Command
        }

    }

    /// <summary>
    /// 计算器按键
    /// </summary>
    public class CalculatorKey : IKey
    {
        public readonly int ID;
        public readonly string InputText;
        public readonly IKey.Type Type = IKey.Type.Value;

        public event Action<string, IKey.Type> OnClicked;
         
        public CalculatorKey(int id, string input, IKey.Type type)
        {
            ID = id;
            InputText = input;
            Type = type;
        }

        public void Clicked()
        {
            OnClicked?.Invoke(InputText, Type);
        }
        public void Clear()
        {
            OnClicked = null;
        }



    }
}
