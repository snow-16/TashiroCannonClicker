using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ウィンドウの描画を制御するコンポーネント
/// </summary>
public class UIWindowDrawer : MonoBehaviour
{
    /// <summary> ウィンドウの影のImage </summary>
    [SerializeField]
    private Image _shadowImage;
    /// <summary> スワイプ時のウィンドウ移動量 </summary>
    [SerializeField]
    private float _slideAmount;

    /// <summary> ウィンドウの基本位置 </summary>
    private Vector2 _windowPosition;

    /// <summary> Animatorのインスタンス </summary>
    private Animator _windowAnimator;
    /// <summary> RectTransformのインスタンス </summary>
    private RectTransform rect;

    void Start()
    {
        _windowAnimator = GetComponent<Animator>();
        rect = (RectTransform)transform;

        _windowPosition = rect.anchoredPosition;
    }

    /// <summary>
    /// ウィンドウの状態の変更を受け取る
    /// </summary>
    /// <param name="state">ウィンドウの状態</param>
    public void UpdateState(VoteState state)
    {
        _shadowImage.gameObject.SetActive(state != VoteState.Opened);
    }

    /// <summary>
    /// ウィンドウを閉じる
    /// </summary>
    public void CloseWindow()
    {
        _windowAnimator.Play("WindowClose");
    }

    /// <summary>
    /// ウィンドウを開く
    /// </summary>
    public void OpenWindow()
    {
        _windowAnimator.Play("WindowOpen");
        rect.anchoredPosition = _windowPosition;
    }

    /// <summary>
    /// スワイプに合わせてウィンドウを滑らせる
    /// </summary>
    /// <param name="moveAmount">スワイプ距離</param>
    public void Swipe(float moveAmount)
    {
        rect.anchoredPosition += _slideAmount * moveAmount * Vector2.up;
    }
}
