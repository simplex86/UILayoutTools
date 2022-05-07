using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class SeparatorHorizontalTool : MiscBaseTool
    {
        public override void OnGUI()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.Width(BUTTON_WIDTH), GUILayout.Height(10));
        }
    }
}