using UnityEngine;
using TMPro;

/// <summary>
/// 通貨を表示するUI
/// </summary>
public class UICurrencyView : MonoBehaviour
{
    /// <summary> 知名度表示テキスト </summary>
    private TextMeshProUGUI _popularityView;
    
    void Start()
    {
        _popularityView = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    
    /// <summary>
    /// 通貨の更新を受け取る
    /// </summary>
    /// <param name="data">更新データ</param>
    public void UpdateCurrency(CurrencyData data)
    {
        _popularityView.text = $"{data.Popularity}pp";
    }
}
