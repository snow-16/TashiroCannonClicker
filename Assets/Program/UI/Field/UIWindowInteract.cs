using UnityEngine;


/// <summary>
/// ウィンドウへの接触判定用コンポーネント
/// </summary>
public class UIWindowInteract : InteractableUI
{
    /// <summary>
    /// タッチされた時
    /// </summary>
    public void Interact()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        CanInteract = false;
    }

    /// <summary>
    /// 投票が閉じた時
    /// </summary>
    public void Close()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    /// <summary>
    /// 投票準備が完了したとき
    /// </summary>
    public void Progressed()
    {
        CanInteract = true;
    }
}
