using Godot;
using System;
using Calculator;

public partial class CalculatorButton : Godot.Button
{
    [Export] public string Input = "0";
    [Export] public IToken.Type Type = IToken.Type.Value;

    public Action<string, IToken.Type> OnClicked;

    public override void _Ready()
    {
        Init();
    }

    public void Init()
    {
        ButtonDown += () => OnClicked.Invoke(Input, Type);
    }
}


