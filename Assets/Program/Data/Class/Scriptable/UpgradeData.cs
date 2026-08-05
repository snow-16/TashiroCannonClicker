using UnityEngine;

/// <summary>
/// アップグレードの内容を保持するScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    /// <summary> アップグレード内容 </summary>
    [SerializeReference, SubclassSelector]
    private IUpgrade _upgrade;
    /// <summary> アップグレード内容 </summary>
    public IUpgrade Upgrade => _upgrade;
}
