using System;
using UniRx;
using UnityEngine;

/// <summary>
/// 田代砲の土台コンポーネント
/// </summary>
public class TashiroCannonCore : MonoBehaviour
{
    /// <summary> 発射タイマーをリセットする基準となる、キャッシュとの倍率差 </summary>
    [SerializeField]
    private float _timerLisetBorder;

    /// <summary> 投票回数/秒 </summary>
    private float _votePerSecond;
    /// <summary> タイマーに使用しているVPS </summary>
    private float _cacheVPS;
    /// <summary> 砲を発射させる周期タイマー </summary>
    private IDisposable _fireTimer;

    /// <summary>
    /// 砲発射タイマーを設定する
    /// </summary>
    private void GenerateFireTimer()
    {
        _fireTimer?.Dispose();
        _cacheVPS = _votePerSecond;
        _fireTimer = Observable.Timer(TimeSpan.FromSeconds(1 / _votePerSecond)).Repeat().Subscribe(_ => 
            {
                _cacheVPS = _votePerSecond;
                Debug.Log("発射！");
            }
        );
    }

    /// <summary>
    /// VotePerSecondの更新を受け取る
    /// </summary>
    /// <param name="data">ClickingDataのインスタンス</param>
    public void UpdateVPS(ClickingData data)
    {
        _votePerSecond = data.VotePerSecond;
        if(_votePerSecond > 0)
        {
            if(Mathf.Max(_votePerSecond, _cacheVPS) / Mathf.Min(_votePerSecond, _cacheVPS) > _timerLisetBorder)
            {
                GenerateFireTimer();
            }
        }
        else
        {
            _fireTimer?.Dispose();
        }
    }
}
