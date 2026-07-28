using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 投票の開催期間を管理するコンポーネント
/// </summary>
public class VoteScheduler : MonoBehaviour
{
    /// <summary> 投票終了時の処理 </summary>
    [SerializeField]
    private CloseVoteEvent _closeVoteEvent;

    /// <summary>
    /// 各投票の期間管理を開始する
    /// </summary>
    public void StartSchedule()
    {
        ServiceLocater.LocateService(out VoteDataManager manager);

        for(int i = 0; i < Enum.GetValues(typeof(VoteType)).Length; i++)
        {
            var votes = manager.Data.AllVotes;
            var index = i;
            this.ObserveEveryValueChanged(_ => votes[index].isHeld).Where(isHeld => isHeld).Subscribe(_ =>
                {
                    Observable.Timer(TimeSpan.FromSeconds(votes[index].setting.TimeLimit)).First().Subscribe(_ =>
                        {
                            _closeVoteEvent?.Invoke((VoteType)(1 << index));
                        }
                    ).AddTo(this);
                }
            ).AddTo(this);
        }
    }

    /// <summary> 投票毎に終了処理を走らせるイベント </summary>
    [Serializable]
    private class CloseVoteEvent : UnityEvent<VoteType>{}
}
