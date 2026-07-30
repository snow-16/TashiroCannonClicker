using UnityEditor;

[CustomEditor(typeof(InteractableButtonUI))]
public class InteractableButtonUIEditor : InteractableUIEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        var _buttonUI = (InteractableButtonUI)_interactableUI;
        _buttonUI.PushedColor = EditorGUILayout.ColorField("選択色", _buttonUI.PushedColor);
        _buttonUI.PushedPositionOffset = EditorGUILayout.Vector2Field("位置変化", _buttonUI.PushedPositionOffset);
        _buttonUI.PushedScaleOffset = EditorGUILayout.Vector2Field("大きさ変化", _buttonUI.PushedScaleOffset);

        serializedObject.ApplyModifiedProperties();
    }
}
