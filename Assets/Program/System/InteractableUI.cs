using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 接触できるUIの抽象クラス
/// </summary>
public abstract class InteractableUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    /// <summary> 受け付ける判定の種類 </summary>
    [SerializeField]
    private UIIntercatType _acceptInteract;
    /// <summary> 受け付ける判定の種類 </summary>
    public UIIntercatType AcceptInteract { get => _acceptInteract; set => _acceptInteract = value; }

    /// <summary> 接触判定処理 </summary>
    [SerializeField]
    private List<UnityEvent> _interactEvent = new();
    /// <summary> 接触判定処理 </summary>
    public List<UnityEvent> InteractEvent { get => _interactEvent; set => _interactEvent = value; }

    /// <summary> 現在触れるか </summary>
    public bool CanInteract { get; set; } = true;
    /// <summary> 現在ボタンがロックされているか </summary>
    public bool IsLocked { get; set; } = false;

    /// <summary> 今マウスオーバーされているか </summary>
    protected bool _isFocused = false;
    /// <summary> 今押し込まれているか </summary>
    protected bool _isPressed = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(CanInteract && !IsLocked && (_acceptInteract & UIIntercatType.Click) > 0)
        {
            _interactEvent[(int)Mathf.Log((int)UIIntercatType.Click, 2)]?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isFocused = true;

        if(CanInteract && !IsLocked)
        {
            if((_acceptInteract & UIIntercatType.Focus) > 0)
            {
                _interactEvent[(int)Mathf.Log((int)UIIntercatType.Focus, 2)]?.Invoke();
            }

            OnFocus();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isFocused = false;

        if(!IsLocked)
        {
            if(CanInteract)
            {
                if((_acceptInteract & UIIntercatType.Focus) > 0)
                {
                    _interactEvent[(int)Mathf.Log((int)UIIntercatType.Focus, 2)]?.Invoke();
                }
            }

            OnFocus();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;

        if(CanInteract && !IsLocked)
        {
            if((_acceptInteract & UIIntercatType.Press) > 0)
            {
                _interactEvent[(int)Mathf.Log((int)UIIntercatType.Press, 2)]?.Invoke();
            }

            OnPress();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;

        if(!IsLocked)
        {
            if(CanInteract)
            {
                if((_acceptInteract & UIIntercatType.Press) > 0)
                {
                    _interactEvent[(int)Mathf.Log((int)UIIntercatType.Press, 2)]?.Invoke();
                }
            }

            OnPress();
        }
    }

    /// <summary>
    /// ボタンがマウスオーバーされたとき・外れたとき
    /// </summary>
    public virtual void OnFocus()
    {
        
    }

    /// <summary>
    /// ボタンが押されたとき・離されたとき
    /// </summary>
    public virtual void OnPress()
    {
        
    }

    /// <summary>
    /// 接触可否状態を反転させる
    /// </summary>
    public void SwitchLockInteract()
    {
        CanInteract = !CanInteract;
    }
}
