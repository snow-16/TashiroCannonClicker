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

    void Start()
    {
        _click.Enable();

        Observable.EveryUpdate().Where(_ => _click.WasPressedThisFrame()).Subscribe(_ => _clickEvent?.Invoke());
    }
}
