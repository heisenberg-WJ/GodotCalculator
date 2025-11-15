using Calculator;
using Godot;
using System.Collections.Generic;
using System.Linq;


public partial class UIManager : Control
{
    [Export] Label LableText;

    //在编辑器中将按钮UI排版好后，创建胶水代码将其与Godot连接起来
    Main _main => GetParent<Main>();

    private List<Button> _buttons = [];
    CalculatorKeyBoard _keyBoard => _main.KeyBoard;//这个获取方式要改
    public override void _Ready()
    {
        GD.Print(GetChildCount());

        _main.Table.OnTableUpdate += (string text) => LableText.Text = text;

        Init();
    }

    public void Init()
    {
        var _all_buttons = FindChildren("", "Button", true);
        List<CalculatorButton> _live_buttons = [];

        foreach (CalculatorButton button in _all_buttons.Cast<CalculatorButton>())
        {
            if (button.IsVisibleInTree())
            {
                _live_buttons.Add(button);
            }
        }

        foreach (CalculatorButton button in _live_buttons)
        {
            button.Init();
            bool _added = _keyBoard.TryAdd(button.Key);
            if (_added)
            {
                GD.Print($" Button :{button.ID} is added");
            }
        }

    }


}



