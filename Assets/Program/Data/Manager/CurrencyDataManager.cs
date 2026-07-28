using UnityEngine;

/// <summary>
/// CurrencyDataの管理を行うマネージャーコンポーネント
/// </summary>
public class CurrencyDataManager : ServiceBase
{
    /// <summary> 開始時の参加人数 </summary>
    [SerializeField]
    private int _initialPeoples;

    /// <summary> CurrencyDataのインスタンス </summary>
    private readonly CurrencyData _data = new();

    void Start()
    {
        _data.People = _initialPeoples;
    }

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
