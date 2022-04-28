using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class SeparatorHorizontalTool : BaseTool
    {
        public override void Init()
        {
            
        }

        public override void OnGUI()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider, GUILayout.Width(BUTTON_WIDTH), GUILayout.Height(10));
        }

        protected override bool Check()
        {
            return false;
        }

        protected override void Apply()
        {
            
        }
    }
}