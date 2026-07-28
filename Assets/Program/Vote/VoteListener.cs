using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 投票の発火を受け取って処理を行うコンポーネント
/// </summary>
public class VoteListener : MonoBehaviour
{
    /// <summary> 投票力の初期値 </summary>
    [SerializeField]
    private int _initialVotePower;
    /// <summary> 投票時の処理 </summary>
    [SerializeField]
    private VoteEvent _onVoted;

    /// <summary> VoterStatusDataのインスタンス </summary>
    private readonly VoterStatusData _voterStatusData = new();

    void Start()
    {
        _voterStatusData.VotePower = _initialVotePower;
    }

    /// <summary>
    /// 投票の発火を受け取るメソッド
    /// </summary>
    public void Vote()
    {
        _onVoted?.Invoke(_voterStatusData);
    }

    /// <summary>
    /// 投票処理を発火させるためのイベントクラス
    /// </summary>
    [Serializable]
    private class VoteEvent : UnityEvent<VoterStatusData>{}
}
