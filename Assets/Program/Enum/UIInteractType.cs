using System;

/// <summary>
/// UIへの接触判定の種類
/// </summary>
[Flags]
public enum UIIntercatType
{
    Click = 1 << 0,
    Focus = 1 << 1,
    Press = 1 << 2,
}
