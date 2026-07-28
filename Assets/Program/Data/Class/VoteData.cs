using System;
using System.Collections.Generic;

/// <summary>
/// 投票関連のデータを保管する
/// </summary>
public class VoteData
{
    /// <summary> 各投票サイトの状況 </summary>
    private List<VoteContainer> _allVotes = new(new VoteContainer[Enum.GetValues(typeof(VoteType)).Length]);
    /// <summary> 各投票サイトの状況 </summary>
    public List<VoteContainer> AllVotes { get => _allVotes; set => _allVotes = value; }

    /// <summary>
    /// 投票サイト毎のデータ
    /// </summary>
    public struct VoteContainer
    {
        /// <summary> 投票サイトの状態 </summary>
        public VoteState state;
        /// <summary> 投票数 </summary>
        public int voteCount;
        /// <summary> 順位 </summary>
        public float ranking;
        /// <summary> サーバー負荷n% </summary>
        public float serverLoad;
        /// <summary> 投票の設定情報 </summary>
        public VoteSettingData setting;
    }
}
