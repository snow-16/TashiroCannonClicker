using UnityEditor;

[CustomEditor(typeof(UIUpgradeButton))]
public class UIUpgradeEditorEditor : InteractableButtonUIEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_target"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_upgrade"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_filters"));

        serializedObject.ApplyModifiedProperties();
    }
}
