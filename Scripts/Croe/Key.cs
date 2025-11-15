using Godot;
using System;

namespace Calculator
{
    public interface IKey
    {
        public enum Type
        {
            None, Value, Operator, Com
        }
    }

    /// <summary>
    /// 计算器按键
    /// </summary>
    public class Key : IKey
    { 
        /// <summary>
        /// 外部通过ID绑定按键
        /// </summary>
        public readonly int Id;

        public string InputText;
        public IToken.Type Type = IToken.Type.Value;

        public Action<string, IToken.Type> OnButton;

        public Key(int id, string input, IToken.Type type)
        {
            Id = id;
            InputText = input;
            Type = type;
        }

        public void Clicked()
        {
            OnButton?.Invoke(InputText, Type);
        }
    }
}
