using UnityEngine;

/// <summary>
/// 投票先ごとの設定を保持するScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "VoteSettingData", menuName = "Scriptable Objects/VoteSettingData")]
public class VoteSettingData : ScriptableObject
{
    /// <summary> 投票内容 </summary>
    [SerializeField]
    private VoteType _type;
    /// <summary> 投票内容 </summary>
    public VoteType Type => _type;
}
