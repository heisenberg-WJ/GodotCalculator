using Calculator;
using Godot;

public partial class CalculatorButton : Button
{
    [Export] public int ID = -1;
    [Export] public string InputText = "";
    [Export] public IToken.Type Type = IToken.Type.Value; 

    public Calculator.Key Key;

    public void Init()
    {
        Key = new(ID, InputText, Type);
        ButtonUp += Key.Clicked;
    }

    public void Init(Calculator.Key key)
    {
        Key = key;
        ButtonUp += Key.Clicked;
    }


}


