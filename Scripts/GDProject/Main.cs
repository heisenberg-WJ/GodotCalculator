using Godot;
using Calculator; 

public partial class Main : Node
{

    [Export] Label LableText;
 
    public CalculateTable Table;
    public CalculatorKeyBoard KeyBoard;
    public override void _EnterTree()
    {
        Table = new();
        KeyBoard = new(Table);

        LableText.Text = Table.GetTexts();
        Table.OnTableUpdate += (string text) => LableText.Text = text;
    }

    public void Input(string str, IToken.Type type)
    {
        Table.Input(str, type);
        LableText.Text = Table.GetTexts();
        // GD.Print($"Text:{current.Text}");
        string _values_text = "";
        //foreach (var token in Table.Values)
        //{
        //    _values_text += $"[{token.Text}],";
        //}
        string _operators_text = "";
        //foreach(var token in Table.Operators)
        //{
        
        //    _operators_text += $"[{token.Text}],";
        //}

        GD.Print($"Values:{_values_text}");
        GD.Print($"Operators:{_operators_text}");

    }
 
 
}



