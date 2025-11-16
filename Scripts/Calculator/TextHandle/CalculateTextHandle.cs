using Calculator;
using System.Collections.Generic;

//可以单独使用，也可以绑定到Table使用。
//使用方法:创建文本处理对象

/// <summary>
/// 专门处理计算器模式下的Token显示
/// </summary>
public class CalculateTextHandle : TokenTextHandle
{
    public override string GetText(List<IToken> tokens)
    {
        string _all_text = "";
        foreach (IToken token in tokens)
        {
            _all_text += token.Text;
        }
        return _all_text;
    }

}
