using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class SeparatorHorizontalTool : LayoutBaseTool
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

        protected virtual void BeginUndo()
        {
            
        }

        protected virtual void EndUndo()
        {
            
        }

        protected override void Apply()
        {
            
        }
    }
}