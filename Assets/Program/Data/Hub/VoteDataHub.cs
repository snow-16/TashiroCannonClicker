using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ClickingDataへのアクセスを行う中継コンポーネント
/// </summary>
public class VoteDataHub : MonoBehaviour
{
    /// <summary> データの更新を受け取るメソッドリスト </summary>
    [SerializeField]
    private VoteDataUpdataEvent _updateListeners;

    /// <summary> データマネージャーのインスタンス </summary>
    private VoteDataManager _manager;

    void Start()
    {
        while(!ServiceLocater.LocateService(out _manager));
    }

    /// <summary>
    /// 投票イベントの受け取り
    /// </summary>
    /// <param name="data">VoterStatusDataのインスタンス</param>
    public void Vote(VoterStatusData data)
    {
        _manager.Vote(data.TargetVote, data.VotePower);
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class VoteDataUpdataEvent : UnityEvent<VoteData>{}
}
