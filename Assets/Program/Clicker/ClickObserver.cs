using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// クリック状態を監視するコンポーネント
/// </summary>
public class ClickObserver : MonoBehaviour
{
    /// <summary> クリック入力 </summary>
    [SerializeField]
    private InputAction _click;
    /// <summary> クリック時の処理 </summary>
    [SerializeField]
    private UnityEvent _clickEvent;

    /// <summary> 現在クリックを受け付けているか </summary>
    private bool _canClicking = true;

    void Start()
    {
        _click.Enable();
        Observable.EveryUpdate().Where(_ => _click.WasPressedThisFrame() && _canClicking).Subscribe(_ => _clickEvent?.Invoke()).AddTo(this);
    }

    /// <summary>
    /// メニュー画面の更新を受け取る
    /// </summary>
    /// <param name="data">データ内容</param>
    public void UpdateMenu(MenuData data)
    {
        _canClicking = data.OpenMenu == MenuType.Close;
    }
}
