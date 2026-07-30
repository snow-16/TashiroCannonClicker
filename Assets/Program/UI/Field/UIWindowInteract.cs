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
        CanInteract = false;
    }

    /// <summary>
    /// 投票準備が完了したとき
    /// </summary>
    public void Progressed()
    {
        CanInteract = true;
    }
}
