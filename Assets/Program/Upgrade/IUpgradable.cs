/// <summary>
/// アップグレードを可能にするインターフェース
/// </summary>
public interface IUpgradable
{
    /// <summary>
    /// 適用されるアップグレードを受け取る
    /// </summary>
    /// <param name="upgrade">アップグレード内容</param>
    void ApplyUpgrade(IUpgrade upgrade);
}
