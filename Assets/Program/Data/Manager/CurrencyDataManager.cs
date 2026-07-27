using UnityEngine;

/// <summary>
/// CurrencyDataの管理を行うマネージャーコンポーネント
/// </summary>
public class CurrencyDataManager : MonoBehaviour
{
    [SerializeField]
    private int _initialPeoples;

    /// <summary> CurrencyDataのインスタンス </summary>
    private readonly CurrencyData _data = new();

    void Start()
    {
        _data.People = _initialPeoples;
    }
}
