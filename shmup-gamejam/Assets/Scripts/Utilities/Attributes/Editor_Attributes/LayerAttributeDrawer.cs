using UnityEditor;
using UnityEngine;

namespace Utilities
{
    [CustomPropertyDrawer(typeof(LayerAttribute))]
    public class LayerAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //set the int value based on whatever the dropdown menu is
            property.intValue = EditorGUI.LayerField(position, label, property.intValue);
        }
    }
}