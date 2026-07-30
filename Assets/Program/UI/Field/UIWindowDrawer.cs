using UnityEngine;
using UnityEngine.UI;

public class UIWindowDrawer : MonoBehaviour
{
    [SerializeField]
    private Image _shadowImage;

    /// <summary>
    /// タッチされた時
    /// </summary>
    public void Interact()
    {
        _shadowImage.gameObject.SetActive(false);
    }

    /// <summary>
    /// 投票が閉じた時
    /// </summary>
    public void Close()
    {
        _shadowImage.gameObject.SetActive(true);
    }
}
