using UnityEngine;

/// <summary>
/// メニューの大枠を管理するUIコンポーネント
/// </summary>
public class UIMenuFrame : MonoBehaviour
{
    /// <summary> メニュー開閉ボタン </summary>
    [SerializeField]
    private InteractableButtonUI _menuButton;

    /// <summary> 現在開いているメニュー </summary>
    private MenuType _nowMenu = MenuType.Close;

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
        var isClosed = _nowMenu == MenuType.Close;
        _animator.Play(isClosed ? "MenuOpen" : "MenuClose");
        _nowMenu = isClosed ? MenuType.Upgrade : MenuType.Close;
        _menuButton.SwitchLockInteract();
    }

    /// <summary>
    /// メニュー遷移の完了を受け取る
    /// </summary>
    public void EndTransition()
    {
        _menuButton.SwitchLockInteract();
    }
}
