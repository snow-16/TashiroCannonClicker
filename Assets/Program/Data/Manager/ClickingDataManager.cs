using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ClickingDataの管理を行うマネージャーコンポーネント
/// </summary>
public class ClickingDataManager : ServiceBase
{
    /// <summary> 各クリック履歴を保存しておく時間 </summary>
    [SerializeField]
    private float _clickLogSurviveTime;
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
        _clickLogs = _clickLogs.Select(log => (log.progressTime + Time.deltaTime, log.clickAmount)).Where(log => log.Item1 < _clickLogSurviveTime).ToList();
        _data.VotePerSecond = _clickLogs.Sum(log => log.clickAmount / _clickLogSurviveTime);

        if(cacheVPS != _data.VotePerSecond)
        {
            _updateListeners?.Invoke(_data);
        }
    }

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }

    [Serializable]
    private class ClickingDataUpdataEvent : UnityEvent<ClickingData>{}
}
