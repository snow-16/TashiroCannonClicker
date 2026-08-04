using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// アップグレードを付与するボタンコンポーネント
/// </summary>
public class UIUpgradeButton : InteractableButtonUI
{
    [SerializeField]
    private UpgradeEvent _upgradeEventListener;

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class UpgradeEvent : UnityEvent<(GameObject, MonoBehaviour)>{}
}
