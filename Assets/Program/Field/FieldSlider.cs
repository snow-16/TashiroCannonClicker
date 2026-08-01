using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 各投票を切り替えるコンポーネント
/// </summary>
public class FieldSlider : MonoBehaviour
{
    /// <summary> 画面位置調整の速度 </summary>
    [SerializeField]
    private float _adjustmentSpeed;

    /// <summary> フォーカスする投票所 </summary>
    private Vector3 _viewPoint;
    /// <summary> 画面位置調整の進行度 </summary>
    private float _adjustmentProgress = 1;

    void FixedUpdate()
    {
        if(_adjustmentProgress != 1)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _viewPoint, _adjustmentProgress);
            _adjustmentProgress = Mathf.Min(_adjustmentProgress + _adjustmentSpeed, 1);
        }
    }

    /// <summary>
    /// スワイプに合わせて画面を滑らせる
    /// </summary>
    /// <param name="moveAmount">スワイプ距離</param>
    public void Swipe(float moveAmount)
    {
        Camera.main.transform.Translate(Vector2.down * moveAmount);
    }

    /// <summary>
    /// スワイプ後に画面位置を調整する
    /// </summary>
    public void AdjustmentPosition()
    {
        List<Transform> votes = new();
        foreach(Transform vote in transform)
        {
            votes.Add(vote);
        }

        var nearVotes = votes.OrderBy(vote => Mathf.Abs(Camera.main.transform.position.y - vote.position.y)).First();
        _viewPoint = nearVotes.position + Vector3.back * 10;
        _adjustmentProgress = 0;
    }
}
