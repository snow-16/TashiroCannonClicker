using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// FieldDataへのアクセスを行う中継コンポーネント
/// </summary>
public class FieldDataHub : MonoBehaviour
{
    /// <summary> データの更新を受け取るメソッドリスト </summary>
    [SerializeField]
    private FieldDataUpdataEvent _updateListeners;

    /// <summary> データマネージャーのインスタンス </summary>
    private FieldDataManager _manager;

    void Start()
    {
        ServiceLocater.LocateService(out _manager);
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class FieldDataUpdataEvent : UnityEvent<FieldData>{}
}
