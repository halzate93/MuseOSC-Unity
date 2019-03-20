using UnityEngine;
using UnityEditor;

namespace MuseOSC
{
    [CustomPropertyDrawer(typeof(NamedArrayAttribute))]
    public class NamedArrayDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            try
            {
                int pos = int.Parse(property.propertyPath.Split('[', ']')[1]);
                property.boolValue = EditorGUI.ToggleLeft (rect, new GUIContent(((NamedArrayAttribute)attribute).names[pos]), property.boolValue);
            }
            catch
            {
                property.boolValue = EditorGUI.ToggleLeft (rect, label, property.boolValue);
            }
        }
    }
}