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
}
