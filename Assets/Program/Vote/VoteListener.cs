using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 投票の発火を受け取って処理を行うコンポーネント
/// </summary>
public class VoteListener : MonoBehaviour
{
    /// <summary> 投票先 </summary>
    [SerializeField]
    private VoteType _voteTarget;
    /// <summary> 投票時の処理 </summary>
    [SerializeField]
    private VoteEvent _onVoted;

    /// <summary> VoterStatusDataのインスタンス </summary>
    private readonly VoterStatusData _voterStatusData = new();

    /// <summary>
    /// 投票の発火を受け取るメソッド
    /// </summary>
    public void Vote(int voteAmount)
    {
        _voterStatusData.TargetVote = _voteTarget;
        _voterStatusData.VotePower = voteAmount;
        _onVoted?.Invoke(_voterStatusData);
    }

    /// <summary>
    /// 投票先の更新
    /// </summary>
    /// <param name="data">ClickingDataのインスタンス</param>
    public void UpdateTarget(ClickingData data)
    {
        _voteTarget = data.VoteTarget;
    }

    /// <summary>
    /// 投票処理を発火させるためのイベントクラス
    /// </summary>
    [Serializable]
    private class VoteEvent : UnityEvent<VoterStatusData>{}
}
