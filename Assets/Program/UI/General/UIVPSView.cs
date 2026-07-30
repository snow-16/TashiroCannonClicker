using UnityEngine;
using TMPro;

/// <summary>
/// VPSを表示するUI
/// </summary>
public class UIVPSView : MonoBehaviour
{
    /// <summary> VPS表示テキスト </summary>
    private TextMeshProUGUI _vpsView;
    
    void Start()
    {
        _vpsView = GetComponent<TextMeshProUGUI>();
    }
    
    /// <summary>
    /// VPSの更新を受け取る
    /// </summary>
    /// <param name="data">更新データ</param>
    public void UpdateVPS(ClickingData data)
    {
        _vpsView.text = $"{(int)data.VotePerSecond}/VPS";
    }
}
