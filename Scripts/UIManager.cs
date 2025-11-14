using Godot;
using Calculator;
using System.Collections.Generic;
using System.Linq;


public partial class UIManager : Control
{
    //在编辑器中将按钮UI排版好后，创建胶水代码将其与Godot连接起来
    Main _main => GetParent<Main>();
    [Export] Label TableText;
 


    private List<Button> _buttons = [];
    CalculatorKeyBoard _keyBoard => _main.Table.KeyBoard;
    public override void _Ready()
    {

        GD.Print(GetChildCount());
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
            bool _is_get = _keyBoard.Keys.TryGetValue(button.ID, out button.Key);
            if (_is_get)
                button.Init();
            GD.Print($" Button :{button.ID},is get key : {_is_get}");
        }

    }


}



