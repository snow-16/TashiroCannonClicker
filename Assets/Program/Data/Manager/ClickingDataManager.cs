using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ClickingDataの管理を行うマネージャーコンポーネント
/// </summary>
public class ClickingDataManager : MonoBehaviour
{
    /// <summary> データの更新を受け取るメソッドリスト </summary>
    [SerializeField]
    private ClickingDataUpdataEvent _updateListeners;

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
    }

    void Update()
    {
        var cacheVPS = _data.VotePerSecond;
        _clickLogs = _clickLogs.Select(log => (log.progressTime + Time.deltaTime, log.clickAmount)).Where(log => log.Item1 < 1).ToList();
        _data.VotePerSecond = _clickLogs.Sum(log => log.clickAmount);

        if(cacheVPS != _data.VotePerSecond)
        {
            _updateListeners?.Invoke(_data);
        }
    }

    [Serializable]
    private class ClickingDataUpdataEvent : UnityEvent<ClickingData>{}
}
