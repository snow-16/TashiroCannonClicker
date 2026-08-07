using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// アップグレードの購入分の通貨があるか判断するフィルター
/// </summary>
[Serializable]
public class CurrencyFilter : IUpgradeFilter
{
    /// <summary> 知名度の要求量 </summary>
    [SerializeField]
    private int _requirePopularity;
    /// <summary> 通貨使用時のイベント </summary>
    [SerializeField]
    private UseCurrencyEvent _useCurrencyEvent;

    public bool CanUpgrade()
    {
        ServiceLocater.LocateService(out CurrencyDataManager currencyManager);
        return currencyManager.Data.Popularity >= _requirePopularity;
    }

    public void AppliedUpgrade()
    {
        
        _useCurrencyEvent?.Invoke(new CurrencyStatement
        {
            popularity = _requirePopularity
        });
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class UseCurrencyEvent : UnityEvent<CurrencyStatement>{}
}
