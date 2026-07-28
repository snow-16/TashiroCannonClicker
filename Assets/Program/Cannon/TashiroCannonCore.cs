using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 田代砲の土台コンポーネント
/// </summary>
public class TashiroCannonCore : MonoBehaviour
{
    /// <summary> 発射時の処理 </summary>
    [SerializeField]
    private UnityEvent _fireEvent;

    /// <summary> 投票回数/秒 </summary>
    private float _votePerSecond;
    /// <summary> 前回の発射からの経過時間 </summary>
    private float _progressTime;

    void Update()
    {
        _progressTime += Time.deltaTime;
        
        if(_votePerSecond > 0 && _progressTime >= 1 / _votePerSecond)
        {
            _progressTime = 0;
            _fireEvent?.Invoke();
        }
    }

    /// <summary>
    /// VotePerSecondの更新を受け取る
    /// </summary>
    /// <param name="data">ClickingDataのインスタンス</param>
    public void UpdateVPS(ClickingData data)
    {
        _votePerSecond = data.VotePerSecond;
    }
}
