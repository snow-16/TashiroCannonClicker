using UnityEditor;

[CustomEditor(typeof(UIWindowInteract))]
public class UIWindowInteractEditor : InteractableUIEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_updateListener"));

        serializedObject.ApplyModifiedProperties();
    }
}
