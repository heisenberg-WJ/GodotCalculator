using Calculator;
using Godot;

[GlobalClass]
public partial class KeyResource : Resource
{
    [Export] public int ID = -1;
    [Export] public string InputText;

    public virtual CalculatorKey GetKey(IKey.Type type)
    {
        var key = new CalculatorKey(ID, InputText, type);
        return key;
    }
}
