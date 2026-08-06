using System;
using UnityEngine;

/// <summary>
/// クリック量を単純増加させるアップグレード
/// </summary>
[Serializable]
public class ClickSum : UpgradeBase<ClickValueProcessor>
{
    /// <summary> 増加量 </summary>
    [SerializeField]
    private int _sumValue;

    public override ClickValueProcessor Processing(ClickValueProcessor input)
    {
        input.clickAmount += _sumValue;
        return input;
    }
}
