using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VoteDataManager))]
public class VoteDataManagerEditor : Editor
{
    private VoteDataManager _voteDataManager;
    private SerializedProperty _voteSettings;

    void OnEnable()
    {
        _voteDataManager = target as VoteDataManager;
        _voteSettings = serializedObject.FindProperty("_voteSettings");
        var listLengthDiference = Enum.GetValues(typeof(VoteType)).Length - _voteDataManager.VoteSettings.Count;

        if(listLengthDiference > 0)
        {
            _voteDataManager.VoteSettings.AddRange(new VoteSettingData[listLengthDiference]);
        }
        else if(listLengthDiference < 0)
        {
            _voteDataManager.VoteSettings.RemoveRange(Enum.GetValues(typeof(VoteType)).Length - 1, -listLengthDiference);
        }
    }

    public override void OnInspectorGUI()
    {
        for(int i = 0; i < _voteSettings.arraySize; i++)
        {
            EditorGUILayout.PropertyField(_voteSettings.GetArrayElementAtIndex(i), new GUIContent(((VoteType)(1 << i)).ToString()));
        }
    }
}
