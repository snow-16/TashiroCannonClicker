using UnityEngine;

/// <summary>
/// 投票所の状態を管理するコンポーネント
/// </summary>
public class VotingStationManager : MonoBehaviour
{
    /// <summary> 開催している投票 </summary>
    public VoteType HeldVote { get; private set; }

    /// <summary>
    /// 投票所の生成
    /// </summary>
    /// <param name="vote">開催する投票</param>
    public void CreateStation(VoteType vote)
    {
        HeldVote = vote;
    }
}
