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
    private readonly VoteData _data = new();

    void Start()
    {
        for(int i = 0; i < _data.AllVotes.Count; i++)
        {
            var vote = _data.AllVotes[i];
            vote.setting = _voteSettings[i];
            _data.AllVotes[i] = vote;
        }
    }

    /// <summary>
    /// 投票時の処理
    /// </summary>
    /// <param name="data"></param>
    public void Vote(VoterStatusData data)
    {
        for(int i = 0; i < _data.AllVotes.Count; i++)
        {
            if((data.TargetVote & (VoteType)(1 << i)) != 0)
            {
                var target = _data.AllVotes[i];
                target.voteCount += data.VotePower;
                _data.AllVotes[i] = target;

                Debug.Log(_data.AllVotes[i].voteCount);
            }
        }
    }

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
