using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ウィンドウ内部の構築を行うコンポーネント
/// </summary>
public class UIWindowBuilder : MonoBehaviour
{
    /// <summary> ウィンドウの影のImage </summary>
    [SerializeField]
    private Image _shadowImage;
    /// <summary> 投票準備中のテキスト </summary>
    [SerializeField]
    private TextMeshProUGUI _voteCloseText;
    /// <summary> 投票開催待機中のテキスト </summary>
    [SerializeField]
    private TextMeshProUGUI _voteWaitingText;
    /// <summary> 投票の順位のテキスト </summary>
    [SerializeField]
    private TextMeshProUGUI _rankingText;

    /// <summary> 現在のウィンドウの状態 </summary>
    private VoteState _windowState;

    /// <summary> VoteDataManagerのインスタンス </summary>
    private VoteDataManager _voteDataManager;
    /// <summary> FieldDataManagerのインスタンス </summary>
    private FieldDataManager _fieldDataManager;

    void Start()
    {
        ServiceLocater.LocateService(out _voteDataManager);
        ServiceLocater.LocateService(out _fieldDataManager);
    }

    void FixedUpdate()
    {
        if(_windowState == VoteState.Opened)
        {
            _rankingText.text = $"Rank:{_voteDataManager.Data.AllVotes[(int)Mathf.Log((int)_fieldDataManager.Data.ViewVote, 2)].ranking:0}";
        }
    }

    /// <summary>
    /// ウィンドウの状態の変更を受け取る
    /// </summary>
    /// <param name="state">ウィンドウの状態</param>
    public void UpdateState(VoteState state)
    {
        _windowState = state;
        _shadowImage.gameObject.SetActive(state != VoteState.Opened);

        _rankingText.gameObject.SetActive(state == VoteState.Opened);
        _voteCloseText.gameObject.SetActive(state == VoteState.Closed);
        _voteWaitingText.gameObject.SetActive(state == VoteState.Waiting);
    }
}
