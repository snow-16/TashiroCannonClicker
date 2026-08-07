using UnityEngine;


/// <summary>
/// クリックによる投票結果を処理するデータ
/// </summary>
public struct ClickValueProcessor
{
    /// <summary> 1回で得られるクリック量 </summary>
    public int clickAmount;

    /// <summary> クリック量の加算数 </summary>
    public int addend;
    /// <summary> クリック量の減算数 </summary>
    public int subtrahend;
    /// <summary> クリック量の乗算数 </summary>
    public float multipilier;
    /// <summary> クリック量の割算数 </summary>
    public float divisor;
    /// <summary> クリック量の指数 </summary>
    public float exponent;

    /// <summary>
    /// 与えられた値を元にクリック量を算出する
    /// </summary>
    /// <returns>計算結果</returns>
    public ClickValueProcessor Processing()
    {
        //加算 → 減算 → 乗算 → 割算 → 累乗の順に適用
        clickAmount = (int)Mathf.Pow((clickAmount + addend - subtrahend) * (multipilier + 1) / (divisor + 1), exponent + 1);
        addend = subtrahend = (int)(multipilier = divisor = exponent = 0);
        return this;
    }
}
