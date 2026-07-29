using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CustomEditor(typeof(InteractableUI))]
public class InteractableUIEditor : Editor
{
    private InteractableUI _interactableUI;
    private SerializedProperty _interactEvent;

    void OnEnable()
    {
        _interactableUI = target as InteractableUI;
        _interactEvent = serializedObject.FindProperty("_interactEvent");
        var listLengthDiference = Enum.GetValues(typeof(UIIntercatType)).Length - _interactableUI.InteractEvent.Count;

        if(listLengthDiference > 0)
        {
            _interactableUI.InteractEvent.AddRange(new UnityEvent[listLengthDiference]);
        }
        else if(listLengthDiference < 0)
        {
            _interactableUI.InteractEvent.RemoveRange(Enum.GetValues(typeof(UIIntercatType)).Length - 1, -listLengthDiference);
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        _interactableUI.AcceptInteract = (UIIntercatType)EditorGUILayout.EnumFlagsField("受け付ける入力", _interactableUI.AcceptInteract);

        for(int i = 0; i < _interactEvent.arraySize; i++)
        {
            var type = (UIIntercatType)(1 << i);

            if((_interactableUI.AcceptInteract & type) > 0)
            {
                EditorGUILayout.PropertyField(_interactEvent.GetArrayElementAtIndex(i), new GUIContent(type.ToString()));
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
