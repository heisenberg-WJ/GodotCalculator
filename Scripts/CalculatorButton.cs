using Calculator;
using Godot;

public partial class CalculatorButton : Button
{
    [Export] public int ID = -1;
    [Export] public string Input = "0";
    [Export] public IToken.Type Type = IToken.Type.Value;
 
    public CalculatorKey Key;

    public void Init()
    { 
        if (Key != null)
        {
            Key.Init(Input, Type);
            ButtonDown += Key.Clicked;
        }
    }


}


