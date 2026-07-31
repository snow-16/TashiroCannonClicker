using System;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// ウィンドウへの接触判定用コンポーネント
/// </summary>
public class UIWindowInteract : InteractableUI
{
    /// <summary> ウィンドウの状態の変更を受け取るリスナー </summary>
    [SerializeField]
    private WindowStateUpdataEvent _updateListener;

    /// <summary> 表示中の投票 </summary>
    private VoteType _showingVote = VoteType.Animal;

    /// <summary> VoteDataManagerのインスタンス </summary>
    private VoteDataManager _voteDataManager;

    void Start()
    {
        ServiceLocater.LocateService(out _voteDataManager);
    }

    /// <summary>
    /// タッチされた時
    /// </summary>
    public void Interact()
    {
        CanInteract = false;
        _updateListener?.Invoke(VoteState.Opened);
    }

    /// <summary>
    /// 投票の選択が変更されたことを受け取る
    /// </summary>
    /// <param name="data">データ内容</param>
    public void UpdateSelect(FieldData data)
    {
        _showingVote = data.ViewVote;
        SetWindow();
    }

    /// <summary>
    /// 投票の状態が変更されたことを受け取る
    /// </summary>
    /// <param name="data">データ内容</param>
    public void UpdateVote(VoteData data)
    {
        SetWindow();
    }

    /// <summary>
    /// ウィンドウの設定を更新する
    /// </summary>
    private void SetWindow()
    {
        var voteState = _voteDataManager.Data.AllVotes[(int)Mathf.Log((int)_showingVote, 2)].state;
        CanInteract = voteState == VoteState.Closed;
        _updateListener?.Invoke(voteState);
    }

    /// <summary> 表示中の投票の状態の変更を通知するイベント </summary>
    [Serializable]
    private class WindowStateUpdataEvent : UnityEvent<VoteState>{}
}
