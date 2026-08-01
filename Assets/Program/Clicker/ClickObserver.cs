using System;
using System.Linq;
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
    /// <summary> 離した時の処理 </summary>
    [SerializeField]
    private UnityEvent _releaceEvent;
    /// <summary> クリックできる範囲を示すコライダー </summary>
    [SerializeField]
    private Collider2D _canClickArea;
    /// <summary> スワイプ時の処理 </summary>
    [SerializeField]
    private SwipeEvent _swipeEvent;

    /// <summary> 現在クリックを受け付けているか </summary>
    private bool _canClicking = true;
    private bool _isSwiping = false;

    void Start()
    {
        _click.Enable();

        var click = Observable.EveryUpdate()
        .Where(_ => _click.WasPressedThisFrame() && _canClicking && Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint((Vector3)Pointer.current.position.value + Vector3.back * 10), 0).Contains(_canClickArea));
        var releace = Observable.EveryUpdate()
        .Where(_ => !_click.IsPressed());

        var swipe = click.Select(_ => Observable.EveryUpdate().DoOnCancel(() => _isSwiping = false).TakeUntil(releace).Select(_ => Pointer.current.position.value).Pairwise()).Switch()
        .Where(positions => positions.Current.y != positions.Previous.y);
        
        swipe.Select(positions => Camera.main.ScreenToWorldPoint(positions.Current).y - Camera.main.ScreenToWorldPoint(positions.Previous).y)
        .Subscribe(moveAmount => 
            {
                _swipeEvent?.Invoke(moveAmount);
                _isSwiping = true;
            }
        ).AddTo(this);

        click.SelectMany(_ => releace.TakeUntil(Observable.EveryUpdate().Where(_ => _isSwiping)).SkipUntil(releace).First())
        .Subscribe(_ => _clickEvent?.Invoke()).AddTo(this);

        click.SelectMany(releace.First()).Subscribe(_ => _releaceEvent?.Invoke());
    }

    /// <summary>
    /// メニュー画面の更新を受け取る
    /// </summary>
    /// <param name="data">データ内容</param>
    public void UpdateMenu(MenuData data)
    {
        _canClicking = data.OpenMenu == MenuType.Close;
    }

    /// <summary> 画面のスワイプを通知するイベント </summary>
    [Serializable]
    private class SwipeEvent : UnityEvent<float>{}
}
