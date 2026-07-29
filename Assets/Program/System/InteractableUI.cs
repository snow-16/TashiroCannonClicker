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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(CanInteract && (_acceptInteract & UIIntercatType.Click) > 0)
        {
            _interactEvent[(int)Mathf.Log((int)UIIntercatType.Click, 2)]?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(CanInteract && (_acceptInteract & UIIntercatType.Focus) > 0)
        {
            _interactEvent[(int)Mathf.Log((int)UIIntercatType.Focus, 2)]?.Invoke();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(CanInteract && (_acceptInteract & UIIntercatType.Focus) > 0)
        {
            _interactEvent[(int)Mathf.Log((int)UIIntercatType.Focus, 2)]?.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(CanInteract && (_acceptInteract & UIIntercatType.Press) > 0)
        {
            _interactEvent[(int)Mathf.Log((int)UIIntercatType.Press, 2)]?.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(CanInteract && (_acceptInteract & UIIntercatType.Press) > 0)
        {
            _interactEvent[(int)Mathf.Log((int)UIIntercatType.Press, 2)]?.Invoke();
        }
    }
}
