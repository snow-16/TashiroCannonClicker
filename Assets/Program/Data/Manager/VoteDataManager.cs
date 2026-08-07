using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// VoteDataの管理を行うマネージャーコンポーネント
/// </summary>
[DefaultExecutionOrder(-99)]
public class VoteDataManager : ServiceBase
{
    /// <summary> 各投票サイトの設定 </summary>
    [SerializeField]
    private List<VoteSettingData> _voteSettings;
    /// <summary> 各投票サイトの設定 </summary>
    public List<VoteSettingData> VoteSettings { get => _voteSettings; set => _voteSettings = value; }

    /// <summary> VoteDataのインスタンス </summary>
    public readonly VoteData Data = new();

    void Start()
    {
        for(int i = 0; i < Data.AllVotes.Count; i++)
        {
            ResetVote((VoteType)(1 << i));
        }

        var first = Data.AllVotes[0];
        first.state = VoteState.Waiting;
        Data.AllVotes[0] = first;
    }

    void FixedUpdate()
    {
        for(int i = 0; i < Data.AllVotes.Count; i++)
        {
            var target = Data.AllVotes[i];

            if(target.ranking < target.setting.InitialRanking)
            {
                target.ranking += Mathf.Min(Mathf.Pow(target.setting.InitialRanking - target.ranking, target.setting.Depth) * target.setting.Population / 50, target.setting.InitialRanking);
                Data.AllVotes[i] = target;
            }
        }
    }

    /// <summary>
    /// 投票時の処理
    /// </summary>
    public void Vote(VoteType targets, int votePower)
    {
        for(int i = 0; i < Data.AllVotes.Count; i++)
        {
            var target = Data.AllVotes[i];

            if(target.state == VoteState.Opened && (targets & (VoteType)(1 << i)) != 0)
            {
                target.voteCount += votePower;
                target.ranking -= votePower;
                Data.AllVotes[i] = target;
            }
        }
    }

    /// <summary>
    /// 投票の開催状況を操作する
    /// </summary>
    /// <param name="target">対象の投票</param>
    /// <param name="state">開催状況</param>
    public void ManageVote(VoteType target, VoteState state)
    {
        var vote = Data.AllVotes[(int)Mathf.Log((int)target, 2)];
        vote.state = state;
        Data.AllVotes[(int)Mathf.Log((int)target, 2)] = vote;

        if(state == VoteState.Waiting)
        {
            ResetVote(target);
        }
    }

    /// <summary>
    /// 投票の状態を初期化する
    /// </summary>
    /// <param name="target">対象の投票</param>
    public void ResetVote(VoteType target)
    {
        var index = (int)Mathf.Log((int)target, 2);
        var vote = Data.AllVotes[index];
        vote.setting = _voteSettings[index];
        vote.ranking = vote.setting.InitialRanking;
        Data.AllVotes[index] = vote;
    }

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
