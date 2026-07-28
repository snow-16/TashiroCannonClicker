using System;

/// <summary>
/// 投票サイトの種類
/// </summary>
[Flags]
public enum VoteType
{
    Animal = 1 << 0,
    Food = 1 << 1,
    Activity = 1 << 2,
}
