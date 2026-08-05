using UnityEngine;

/// <summary>
/// アップグレードを可能にするインターフェース
/// </summary>
public abstract class UpgradableObject : MonoBehaviour
{
    /// <summary>
    /// 適用されるアップグレードを受け取る
    /// </summary>
    /// <param name="upgrade">アップグレード内容</param>
    public abstract void ApplyUpgrade(IUpgrade upgrade);
}
