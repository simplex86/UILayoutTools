using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class SeparatorVerticalTool : BaseTool
    {
        public override void Init()
        {
            
        }

        public override void OnGUI()
        {
            EditorGUILayout.LabelField("", GUI.skin.verticalSlider, GUILayout.Width(10), GUILayout.Height(BUTTON_HEIGHT));
        }

        protected override void Apply()
        {
            
        }
    }
}