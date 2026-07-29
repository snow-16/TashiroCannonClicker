/// <summary>
/// ゲームフィールド関連のデータを保持する
/// </summary>
public class FieldData
{
    /// <summary> 表示中の投票 </summary>
    private VoteType _viewVote = VoteType.Animal;
    /// <summary> 表示中の投票 </summary>
    public VoteType ViewVote { get => _viewVote; set => _viewVote = value; }
}
