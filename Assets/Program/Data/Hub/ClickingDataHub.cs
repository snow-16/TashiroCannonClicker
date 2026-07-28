using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ClickingDataへのアクセスを行う中継コンポーネント
/// </summary>
public class ClickingDataHub : MonoBehaviour
{
    /// <summary> データの更新を受け取るメソッドリスト </summary>
    [SerializeField]
    private ClickingDataUpdataEvent _updateListeners;

    /// <summary> データマネージャーのインスタンス </summary>
    private ClickingDataManager _manager;

    void Start()
    {
        while(!ServiceLocater.LocateService(out _manager));
    }

    void Update()
    {
        if(_manager.UpdateLog())
        {
            _updateListeners?.Invoke(_manager.Data);
        }
    }
    
    /// <summary>
    /// 画面がクリックされた時
    /// </summary>
    public void OnClick()
    {
        _manager.ClickEvent();
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class ClickingDataUpdataEvent : UnityEvent<ClickingData>{}
}
