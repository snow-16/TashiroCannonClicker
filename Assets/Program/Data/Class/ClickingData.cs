/// <summary>
/// クリック結果関連のデータを保持する
/// </summary>
public class ClickingData
{
    /// <summary> 投票先 </summary>
    public VoteType VoteTarget { get; set; } = VoteType.Animal;

    /// <summary> 総クリック回数 </summary>
    public int ClickCount { get; set; } = 0;

    /// <summary> 投票回数/秒 </summary>
    public float VotePerSecond { get; set; } = 0;
}
