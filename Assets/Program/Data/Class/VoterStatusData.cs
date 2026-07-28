/// <summary>
/// 投票者の能力関連のデータを保管する
/// </summary>
public class VoterStatusData
{
    /// <summary> 投票先 </summary>
    private VoteType _targetVote = VoteType.Animal;
    /// <summary> 投票先 </summary>
    public VoteType TargetVote { get => _targetVote; set => _targetVote = value; }

    /// <summary> 一回毎の投票数 </summary>
    private int _votePower = 1;
    /// <summary> 一回毎の投票数 </summary>
    public int VotePower { get => _votePower; set => _votePower = value; }

    /// <summary> 一回毎のサーバー負荷 </summary>
    private float _votingLoad = 0;
    /// <summary> 一回毎のサーバー負荷 </summary>
    public float VotingLoad { get => _votingLoad; set => _votingLoad = value; }
}
