using Calculator;
using Godot;

[GlobalClass]
public partial class KeyOperatorResource : KeyResource
{
    [Export] public DoubleOperatorType OperatorType;
    public override CalKey GetKey()
    {
        OperatorDoubleKey key = new OperatorDoubleKey(ID, InputText, OperatorType);
       // key.OperatorType = OperatorType;
        return key;
    }
}
