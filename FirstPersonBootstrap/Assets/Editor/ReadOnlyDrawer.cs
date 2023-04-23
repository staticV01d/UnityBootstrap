using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
class ReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property);
        GUI.enabled = true;
        EditorGUI.LabelField(position, label);
    }
}
