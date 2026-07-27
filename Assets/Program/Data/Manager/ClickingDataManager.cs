using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ClickingDataの管理を行うマネージャーコンポーネント
/// </summary>
public class ClickingDataManager : MonoBehaviour
{
    /// <summary> ClickingDataのインスタンス </summary>
    private readonly ClickingData _data = new();
    /// <summary> 直近1秒間のクリック内容の履歴 </summary>
    private List<(float progressTime, int clickAmount)> _clickLogs = new();

    /// <summary>
    /// 画面がクリックされた時
    /// </summary>
    public void OnClick()
    {
        _data.ClickCount++;
        _clickLogs.Add((0, 1));
        Debug.Log(_data.VotePerSecond);
    }

    void Update()
    {
        _clickLogs = _clickLogs.Select(log => (log.progressTime + Time.deltaTime, log.clickAmount)).Where(log => log.Item1 < 1).ToList();
        _data.VotePerSecond = _clickLogs.Sum(log => log.clickAmount);
    }
}
