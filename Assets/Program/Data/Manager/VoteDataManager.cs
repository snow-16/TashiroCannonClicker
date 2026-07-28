using UnityEngine;

/// <summary>
/// VoteDataの管理を行うマネージャーコンポーネント
/// </summary>
public class VoteDataManager : MonoBehaviour
{
    /// <summary> VoteDataのインスタンス </summary>
    private readonly VoteData _data = new();
    
    /// <summary>
    /// 投票時の処理
    /// </summary>
    /// <param name="data"></param>
    public void Vote(VoterStatusData data)
    {
        var target = _data.AllVotes[data.TargetVote];
        target.voteCount += data.VotePower;
        _data.AllVotes[data.TargetVote] = target;

        Debug.Log(_data.AllVotes[data.TargetVote].voteCount);
    }
}
