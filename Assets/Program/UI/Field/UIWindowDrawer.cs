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

    /// <summary> Animatorのコンポーネント </summary>
    private Animator _windowAnimator;

    void Start()
    {
        _windowAnimator = GetComponent<Animator>();
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
    }
}
