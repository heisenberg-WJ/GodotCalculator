using Calculator;
using Godot;

[GlobalClass]
public partial class KeyCommandResource : KeyResource
{

    [Export] public Command CommandType;
    public override CalKey GetKey()
    {
        CommandKey key = new CommandKey(ID, InputText, CommandType);
        
        return key;
    }
}

