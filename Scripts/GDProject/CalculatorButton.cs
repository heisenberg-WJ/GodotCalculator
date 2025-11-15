using Calculator;
using Godot;

public partial class CalculatorButton : Button
{
    [Export] public int ID = -1;
    [Export] public string InputText = "";
    [Export] public IKey.Type Type = IKey.Type.Value;
    [Export] public KeyResource KeyResource;//不能自动就手动吧


    public CalculatorKey Key;

    public void Init()
    {
        if (Key != null) return;
         
        if (KeyResource != null)
        {
            Key = KeyResource.GetKey(Type);
            ButtonUp += Key.Clicked;
            return;
        }
        Key = new(ID, InputText, Type);
        ButtonUp += Key.Clicked;
    }


}


