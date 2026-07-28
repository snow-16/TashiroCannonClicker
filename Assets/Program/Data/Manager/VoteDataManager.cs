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
            ResetVote((VoteType)(1 << i));
        }
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

            if(target.isHeld && (targets & (VoteType)(1 << i)) != 0)
            {
                target.voteCount += votePower;
                target.ranking -= votePower;
                Data.AllVotes[i] = target;

                Debug.Log($"{(int)Data.AllVotes[i].ranking}位");
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

        if(!held)
        {
            ResetVote(target);
        }
    }

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
