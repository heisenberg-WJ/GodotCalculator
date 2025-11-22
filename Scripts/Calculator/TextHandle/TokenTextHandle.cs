using Calculator;
using Godot;
using System;
using System.Collections.Generic;

/// <summary>
/// 用于处理Token列表
/// </summary>
public abstract class TokenTextHandle : IDisposable//后续需要获得Table的状态，并进一步完善
{
    protected CalculateTable _table;

    public string Text { get; set; }

    public void Dispose()
    {
        if (_table != null)
            _table.OnTableUpdate -= OnTokensChanged;
    }

   
    public virtual void InitToTable(CalculateTable table)
    {
        _table = table;
        _table.OnTableUpdate += OnTokensChanged;
    }
    public virtual void ReleaseToTable()
    {
        if (_table != null)
            _table.OnTableUpdate -= OnTokensChanged;
    }
    private void OnTokensChanged()
    {
        Text = GetText(_table.Tokens);
        GD.Print(Text);
    }
    public abstract string GetText(List<Token> tokens);
}