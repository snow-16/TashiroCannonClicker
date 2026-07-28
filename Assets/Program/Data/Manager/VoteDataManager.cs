using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// VoteDataの管理を行うマネージャーコンポーネント
/// </summary>
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
            var vote = Data.AllVotes[i];
            vote.setting = _voteSettings[i];
            vote.ranking = vote.setting.InitialRanking;
            Data.AllVotes[i] = vote;
        }
    }

    void FixedUpdate()
    {
        for(int i = 0; i < Data.AllVotes.Count; i++)
        {
            var target = Data.AllVotes[i];

            if(target.ranking < target.setting.InitialRanking)
            {
                target.ranking += Mathf.Min(Mathf.Pow(Mathf.Sqrt(target.setting.InitialRanking - target.ranking) * target.setting.Popularity, target.setting.Depth), target.setting.InitialRanking);
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

            if(target.isHeld && (targets & (VoteType)(1 << i)) != 0)
            {
                target.voteCount += votePower;
                target.ranking -= votePower;
                Data.AllVotes[i] = target;

                Debug.Log(Data.AllVotes[i].ranking);
            }
        }
    }

    /// <summary>
    /// 投票の開催状況を操作する
    /// </summary>
    /// <param name="target">対象の投票</param>
    /// <param name="held">開催中かどうか</param>
    public void ManageVote(VoteType target, bool held)
    {
        var vote = Data.AllVotes[(int)Mathf.Log((int)target, 2)];
        vote.isHeld = held;
        Data.AllVotes[(int)Mathf.Log((int)target, 2)] = vote;
    }

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
