using UnityEngine;

/// <summary>
/// 投票先ごとの設定を保持するScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "VoteSettingData", menuName = "Scriptable Objects/VoteSettingData")]
public class VoteSettingData : ScriptableObject
{
    /// <summary> 開催期間 </summary>
    [SerializeField]
    private int _timeLimit;
    /// <summary> 開催期間 </summary>
    public int TimeLimit => _timeLimit;

    /// <summary> 初期順位 </summary>
    [SerializeField]
    private int _initialRanking;
    /// <summary> 初期順位 </summary>
    public int InitialRanking => _initialRanking;

    /// <summary> 投票人口 </summary>
    [SerializeField]
    private float _population;
    /// <summary> 投票人口 </summary>
    public float Population => _population;

    /// <summary> 人気の深さ </summary>
    [SerializeField]
    private float _depth;
    /// <summary> 人気の深さ </summary>
    public float Depth => _depth;

    /// <summary> サーバーの耐久力 </summary>
    [SerializeField]
    private float _serverDurability;
    /// <summary> サーバーの耐久力 </summary>
    public float ServerDurability => _serverDurability;
}
