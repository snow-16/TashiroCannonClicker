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
        ServiceLocater.LocateService(out _manager);
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

    /// <summary>
    /// 投票所移動時に投票先を変更する
    /// </summary>
    /// <param name="data"></param>
    public void ChangeViewWindow(FieldData data)
    {
        _manager.Data.VoteTarget = data.ViewVote;
        _updateListeners?.Invoke(_manager.Data);
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class ClickingDataUpdataEvent : UnityEvent<ClickingData>{}
}
