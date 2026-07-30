using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// メニューの大枠を管理するUIコンポーネント
/// </summary>
public class UIMenuFrame : MonoBehaviour
{
    [SerializeField]
    /// <summary> メニュー画面の更新を通知する </summary>
    private MenuDataUpdataEvent _menuUpdateEvent;
    /// <summary> メニュー開閉ボタン </summary>
    [SerializeField]
    private InteractableButtonUI _menuButton;

    /// <summary> Animatorコンポーネントのインスタンス </summary>
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// メニューを開閉する
    /// </summary>
    public void MenuTransition()
    {
        ServiceLocater.LocateService(out MenuDataManager menuDataManager);
        var isClosed = menuDataManager.Data.OpenMenu == MenuType.Close;
        _animator.Play(isClosed ? "MenuOpen" : "MenuClose");
        _menuButton.SwitchLockInteract();
        _menuUpdateEvent?.Invoke(isClosed ? MenuType.Upgrade : MenuType.Close);
    }

    /// <summary>
    /// メニュー遷移の完了を受け取る
    /// </summary>
    public void EndTransition()
    {
        _menuButton.SwitchLockInteract();
    }

    /// <summary> メニュー画面の更新を通知するイベント </summary>
    [Serializable]
    private class MenuDataUpdataEvent : UnityEvent<MenuType>{}
}
