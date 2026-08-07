using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ClickingDataの管理を行うマネージャーコンポーネント
/// </summary>
[DefaultExecutionOrder(-99)]
public class ClickingDataManager : ServiceBase
{
    /// <summary> 各クリック履歴を保存しておく時間 </summary>
    [SerializeField]
    private float _clickLogSurviveTime;

    /// <summary> ClickingDataのインスタンス </summary>
    public readonly ClickingData Data = new();
    /// <summary> 直近1秒間のクリック内容の履歴 </summary>
    private List<(float progressTime, int clickAmount)> _clickLogs = new();

    /// <summary>
    /// クリック処理
    /// </summary>
    public void ClickEvent(int votePower)
    {
        Data.ClickCount++;
        _clickLogs.Add((0, votePower));
    }

    /// <summary>
    /// クリック履歴とVPSの更新
    /// </summary>
    /// <returns>更新されたか</returns>
    public bool UpdateLog()
    {
        if(_clickLogs.Count > 0)
        {
            var cacheVPS = Data.VotePerSecond;
            _clickLogs = _clickLogs.Select(log => (log.progressTime + Time.deltaTime, log.clickAmount)).Where(log => log.Item1 < _clickLogSurviveTime).ToList();
            Data.VotePerSecond = _clickLogs.Sum(log => log.clickAmount / _clickLogSurviveTime);

            return cacheVPS != Data.VotePerSecond;
        }

        return false;
    }

    protected override void CreateService()
    {
        ServiceLocater.AddService(this);
    }
}
