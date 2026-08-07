/// <summary>
/// アップグレードの可否をフィルタリングするインターフェース
/// </summary>
public interface IUpgradeFilter
{
    /// <summary>
    /// アップグレード可能かを判断するメソッド
    /// </summary>
    /// <returns>アップグレード可否</returns>
    bool CanUpgrade();

    /// <summary>
    /// アップグレードが適用されたとき
    /// </summary>
    void AppliedUpgrade();
}
