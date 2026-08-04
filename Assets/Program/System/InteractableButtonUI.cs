using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ボタンのUIコンポーネント
/// </summary>
public class InteractableButtonUI : InteractableUI
{
    /// <summary> マウスオーバーされたとき何色が乗算されるか </summary>
    [SerializeField]
    private Color _pushedColor;
    /// <summary> マウスオーバーされたとき何色が乗算されるか </summary>
    public Color PushedColor { get => _pushedColor; set => _pushedColor = value; }
    /// <summary> 押されたときどれくらい位置が動くか </summary>
    [SerializeField]
    private Vector2 _pushedPositionOffset;
    /// <summary> 押されたときどれくらい位置が動くか </summary>
    public Vector2 PushedPositionOffset { get => _pushedPositionOffset; set => _pushedPositionOffset = value; }
    /// <summary> 押されたときどれくらい大きさが変わるか </summary>
    [SerializeField]
    private Vector2 _pushedScaleOffset;
    /// <summary> 押されたときどれくらい大きさが変わるか </summary>
    public Vector2 PushedScaleOffset { get => _pushedScaleOffset; set => _pushedScaleOffset = value; }

    /// <summary> ボタンの基礎色 </summary>
    private Color _baseColor;
    /// <summary> ボタンの基礎位置 </summary>
    private Vector3 _basePosition;
    /// <summary> ボタンの基礎大きさ </summary>
    private Vector3 _baseScale;

    /// <summary> Imageコンポーネントのインスタンス </summary>
    private Image _buttonImage;


    void Start()
    {
        _buttonImage = GetComponent<Image>();
        _baseColor = _buttonImage.color;
        _baseScale = transform.localScale;

        InteractEvent[(int)Mathf.Log((int)UIIntercatType.Focus, 2)].AddListener(OnFocus);
        InteractEvent[(int)Mathf.Log((int)UIIntercatType.Press, 2)].AddListener(OnPress);
    }

    public override void OnFocus()
    {
        _buttonImage.color = _isFocused ? _baseColor - (Color.white - _pushedColor) : _baseColor;
        
        if(!_isFocused)
        {
            transform.localPosition = _basePosition;
            transform.localScale = _baseScale;
        }
    }

    public override void OnPress()
    {
        if(_isPressed)
        {
            _basePosition = transform.localPosition;
        }
        
        transform.localPosition = _isPressed ? _basePosition + (Vector3)_pushedPositionOffset : _basePosition;
        transform.localScale = _isPressed ? _baseScale + (Vector3)_pushedScaleOffset : _baseScale;
    }
}
