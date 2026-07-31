using UnityEngine;
using UnityEngine.UI;

public class UIWindowDrawer : MonoBehaviour
{
    [SerializeField]
    private Image _shadowImage;

    /// <summary>
    /// ウィンドウの状態の変更を受け取る
    /// </summary>
    /// <param name="state">ウィンドウの状態</param>
    public void UpdateState(VoteState state)
    {
        _shadowImage.gameObject.SetActive(state != VoteState.Opened);
    }
}
