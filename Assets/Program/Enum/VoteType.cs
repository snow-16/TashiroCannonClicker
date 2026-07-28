using System;

/// <summary>
/// 投票サイトの種類
/// </summary>
[Flags]
public enum VoteType
{
    Animal = 1 << 0,
}
