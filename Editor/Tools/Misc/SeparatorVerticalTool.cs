using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class SeparatorVerticalTool : LayoutBaseTool
    {
        public override void Init()
        {
            
        }

        public override void OnGUI()
        {
            EditorGUILayout.LabelField("", GUI.skin.verticalSlider, GUILayout.Width(10), GUILayout.Height(BUTTON_HEIGHT));
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