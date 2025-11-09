using Godot;
using System.Collections.Generic;


public partial class UIManager : Control
{
    //在编辑器中将按钮UI排版好后，创建胶水代码将其与Godot连接起来
    Main _main => GetParent<Main>();
    [Export] Label TableText;
    [Export] CalculatorButton button1;
    [Export] CalculatorButton button2;
    [Export] CalculatorButton buttonPonit;
    [Export] CalculatorButton buttonBackSpace;
    [Export] CalculatorButton buttonSum;
    [Export] CalculatorButton buttonClear;
    [Export] CalculatorButton buttonEquals;


     private List<Button> _buttons = [];

    public override void _Ready()
    {
        button1.OnClicked += _main.Input;
        button2.OnClicked += _main.Input;
        buttonPonit.OnClicked += _main.Input;
        buttonBackSpace.OnClicked += _main.Input;
        buttonSum.OnClicked += _main.Input;
        buttonClear.OnClicked += _main.Input;
        buttonEquals.OnClicked += _main.Input;

    }

    public void Init(Node node)
    {
        //node.AddChild(new CalculatorButton() { Input = "1", Type = Token.Type.Value });

    }


}

public class CalculatorKeyBoard
{
    //这里生成所有按钮信息后，在Godot中创建按钮UI，并用遍历的方式来将按钮UI与按钮信息对应起来
    private List<Calculator.Button> _buttons = [];


    public CalculatorKeyBoard()
    {
        for (int i = 0; i < 10; i++)
        {
            _buttons.Add(new Calculator.Button(i.ToString()) { Input = i.ToString()} );
        }
    }
}

