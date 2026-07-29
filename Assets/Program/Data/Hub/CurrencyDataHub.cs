using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// CurrencyDataへのアクセスを行う中継コンポーネント
/// </summary>
public class CurrencyDataHub : MonoBehaviour
{
    /// <summary> データの更新を受け取るメソッドリスト </summary>
    [SerializeField]
    private CurrencyDataUpdataEvent _updateListeners;

    /// <summary> データマネージャーのインスタンス </summary>
    private CurrencyDataManager _manager;

    void Start()
    {
        while(!ServiceLocater.LocateService(out _manager));
    }

    /// <summary>
    /// 最終順位から知名度を獲得する
    /// </summary>
    /// <param name="target">対象の投票</param>
    public void CollectPopularity(VoteType target)
    {
        ServiceLocater.LocateService(out VoteDataManager _voteDataManager);
        var vote = _voteDataManager.Data.AllVotes[(int)Mathf.Log((int)target, 2)];
        _manager.ModifyPopularity(vote.setting.InitialRanking - (int)vote.ranking);
        _updateListeners?.Invoke(_manager.Data);
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class CurrencyDataUpdataEvent : UnityEvent<CurrencyData>{}
}
