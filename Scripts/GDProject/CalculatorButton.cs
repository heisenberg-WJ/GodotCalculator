using Calculator;
using Godot;

public partial class CalculatorButton : Button
{
    [Export] public KeyType Type = KeyType.Value;
    [Export] public KeyResource KeyResource;//不能自动就手动吧


    public CalKey Key;

    public void Init()
    {
        if (Key != null) return;

        if (KeyResource != null)
        {
            Key = KeyResource.GetKey();
            ButtonUp += Key.Clicked;
            return;
        }
        Key = new(KeyResource.ID, KeyResource.InputText);
        ButtonUp += Key.Clicked;
    }


}


