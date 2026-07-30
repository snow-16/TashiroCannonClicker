using System;
using System.Collections.Generic;
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
    private VoteScheduleEvent _closeVoteEvent;
    /// <summary> 投票準備完了時の処理 </summary>
    [SerializeField]
    private VoteScheduleEvent _progressedVoteEvent;

    void Start()
    {
        ServiceLocater.LocateService(out VoteDataManager manager);

        for(int i = 0; i < Enum.GetValues(typeof(VoteType)).Length; i++)
        {
            var votes = manager.Data.AllVotes;
            var index = i;
            this.ObserveEveryValueChanged(_ => votes[index].state).Where(state => state == VoteState.Opened).Subscribe(_ =>
                {
                    SetSchedule((VoteType)(1 << index), votes, index);
                }
            ).AddTo(this);
        }
    }

    /// <summary>
    /// 投票のタイマーを開始する
    /// </summary>
    /// <param name="target">対象の投票</param>
    /// <param name="votes">投票サイトデータのリスト</param>
    /// <param name="votesIndex">リストのインデックス</param>
    private void SetSchedule(VoteType target, List<VoteData.VoteContainer> votes, int votesIndex)
    {
        Observable.Timer(TimeSpan.FromSeconds(votes[votesIndex].setting.TimeLimit)).First().Subscribe(_ =>
            {
                _closeVoteEvent?.Invoke(target);

                Observable.Timer(TimeSpan.FromSeconds(votes[votesIndex].setting.OpenInterval)).First().Subscribe(_ =>
                    {
                        _progressedVoteEvent?.Invoke(target);
                    }
                ).AddTo(this);
            }
        ).AddTo(this);
    }

    /// <summary> 投票毎に終了処理を走らせるイベント </summary>
    [Serializable]
    private class VoteScheduleEvent : UnityEvent<VoteType>{}
}
