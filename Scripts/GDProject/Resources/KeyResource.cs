using Calculator;
using Godot;


public interface IKeyCreate
{
    CalKey GetKey();
}

[GlobalClass]
public partial class KeyResource : Resource, IKeyCreate
{
    [Export] public int ID = -1;
    [Export] public string InputText;

    public virtual CalKey GetKey()
    {
        return new CalKey(ID, InputText);
    }
}
