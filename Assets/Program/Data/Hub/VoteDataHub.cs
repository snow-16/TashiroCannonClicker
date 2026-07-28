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

    /// <summary>
    /// 投票を開催させる
    /// </summary>
    /// <param name="target">対象の投票</param>
    public void OpenVote(VoteType target)
    {
        Debug.Log($"{target}を開催しました。");
        _manager.ManageVote(target, VoteState.Opened);
    }

    /// <summary>
    /// 投票を終了させる
    /// </summary>
    /// <param name="target">対象の投票</param>
    public void CloseVote(VoteType target)
    {
        Debug.Log($"{target}を終了しました。");
        _manager.ManageVote(target, VoteState.Waiting);
    }

    /// <summary>
    /// 投票準備を終える
    /// </summary>
    /// <param name="target">対象の投票</param>
    public void ProgressedVote(VoteType target)
    {
        Debug.Log($"{target}は開催可能です。");
        _manager.ManageVote(target, VoteState.Closed);
    }

    public void VoteTest(int target)
    {
        OpenVote((VoteType)(1 << target));
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class VoteDataUpdataEvent : UnityEvent<VoteData>{}
}
