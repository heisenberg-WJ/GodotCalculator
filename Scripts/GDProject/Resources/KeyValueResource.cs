using Calculator;
using Godot;

[GlobalClass]
public partial class KeyValueResource : KeyResource
{
    public override CalKey GetKey()
    {
        var key = new ValueKey(ID, InputText);
         
        return key;
    }
}


