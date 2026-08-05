using UnityEngine;

/// <summary>
/// アップグレードを付与するコンポーネント
/// </summary>
public class UpgradeGranter : MonoBehaviour
{
    [SerializeReference, SubclassSelector]
    private IUpgrade _upgrade;

    /// <summary>
    /// 特定のオブジェクトにアップグレードを付与する
    /// </summary>
    /// <typeparam name="T">アップグレードの種類</typeparam>
    /// <param name="upgrade">アップグレード内容</param>
    public void GrantUpgrade(UpgradableObject taget)
    {
        taget.ApplyUpgrade(_upgrade);
    }
}
