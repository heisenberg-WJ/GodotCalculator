using Godot;
using Calculator;

public partial class Main : Node
{

    [Export] Label LableText;

    public CalculateTable Table;
    public CalculatorKeyBoard KeyBoard;
    public TokenTextHandle TextHandle;
    public override void _EnterTree()
    {
        Table = new();
        KeyBoard = new(Table);
        TextHandle = new CalculateTextHandle();
        TextHandle.InitToTable(Table);

    }

    public override void _Ready()
    {
        base._Ready();
        Table.Init();

    }


}



