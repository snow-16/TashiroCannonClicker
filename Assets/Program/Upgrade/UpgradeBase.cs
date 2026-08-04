/// <summary>
/// アップグレードの内容を設定するための抽象クラス
/// </summary>
/// <typeparam name="T">アップグレード対象の型</typeparam>
public abstract class UpgradeBase<T> : IUpgrade
{
    /// <summary>
    /// 値を受け取り、アップグレード内容に応じて処理した値を返すメソッド
    /// </summary>
    /// <param name="input">処理前の値</param>
    /// <returns>処理後の値</returns>
    protected abstract T Processing(T input);
}