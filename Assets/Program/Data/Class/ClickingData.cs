/// <summary>
/// クリック結果関連のデータを保持する
/// </summary>
public class ClickingData
{
    /// <summary> 投票先 </summary>
    private VoteType _voteTarget = VoteType.Animal;
    /// <summary> 投票先 </summary>
    public VoteType VoteTarget { get => _voteTarget; set => _voteTarget = value; }

    /// <summary> 総クリック回数 </summary>
    private int _clickCount = 0;
    /// <summary> 総クリック回数 </summary>
    public int ClickCount { get => _clickCount; set => _clickCount = value; }

    /// <summary> 投票回数/秒 </summary>
    private float _votePerSecond = 0;
    /// <summary> 投票回数/秒 </summary>
    public float VotePerSecond { get => _votePerSecond; set => _votePerSecond = value; }
}
