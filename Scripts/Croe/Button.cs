using Godot;
using System;

namespace Calculator
{
    public class Button
    {
        public string Input = "0";
        public IToken.Type Type = IToken.Type.Value;

        public Action<string, IToken.Type> OnClicked;

        public readonly string Id;

        public Button(string id)
        {
            Id = id;
        }
    }
}
