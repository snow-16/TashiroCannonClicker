using UnityEngine;

/// <summary>
/// 通貨関連のデータを保管する
/// </summary>
[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Objects/CurrencyData")]
public class CurrencyData : ScriptableObject
{
    /// <summary> スレ民数 </summary>
    [SerializeField]
    private int _people;
    /// <summary> スレ民数 </summary>
    public int People { get => _people; set => _people = value; }
}
