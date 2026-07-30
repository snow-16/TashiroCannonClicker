using UnityEngine;

/// <summary>
/// CurrencyDataの管理を行うマネージャーコンポーネント
/// </summary>
[DefaultExecutionOrder(-99)]
public class CurrencyDataManager : ServiceBase
{
    /// <summary> CurrencyDataのインスタンス </summary>
    public readonly CurrencyData Data = new();

    public void ModifyPopularity(int value)
    {
        Data.Popularity += value;
        Debug.Log($"{Data.Popularity}Get");
    }

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
