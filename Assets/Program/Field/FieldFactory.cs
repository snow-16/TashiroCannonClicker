using System;
using UnityEngine;

public class FieldFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _votePrefab;
    [SerializeField]
    private float _votesPadding;

    void Start()
    {
        for(int i = 0; i < Enum.GetValues(typeof(VoteType)).Length; i++)
        {
            var vote = Instantiate(_votePrefab, transform.position + new Vector3(0, i * _votesPadding), Quaternion.identity);
            vote.transform.parent = transform;
            vote.GetComponent<VotingStationManager>().CreateStation((VoteType)(1 << i));
        }
    }
}
