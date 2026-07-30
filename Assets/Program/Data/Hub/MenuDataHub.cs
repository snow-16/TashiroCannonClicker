using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// MenuDataへのアクセスを行う中継コンポーネント
/// </summary>
public class MenuDataHub : MonoBehaviour
{
    /// <summary> データの更新を受け取るメソッドリスト </summary>
    [SerializeField]
    private MenuDataUpdataEvent _updateListeners;

    /// <summary> データマネージャーのインスタンス </summary>
    private MenuDataManager _manager;

    void Start()
    {
        ServiceLocater.LocateService(out _manager);
    }

    /// <summary>
    /// メニュー画面の更新を受け取る
    /// </summary>
    /// <param name="newMenu">開いたメニュー</param>
    public void ChangeMenu(MenuType newMenu)
    {
        _manager.Data.OpenMenu = newMenu;
        _updateListeners?.Invoke(_manager.Data);
    }

    /// <summary> データの更新を通知するイベント </summary>
    [Serializable]
    private class MenuDataUpdataEvent : UnityEvent<MenuData>{}
}
