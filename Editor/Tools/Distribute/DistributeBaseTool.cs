using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    abstract class DistributeBaseTool : LayoutBaseTool
    {
        protected float interval { get; private set; } = 0;
        private float px = 0;

        protected DistributeBaseTool(float x)
        {
            px = x;
        }

        // 
        public override void OnGUI()
        {
            if (GUILayout.Button(icon, GUILayout.Width(BUTTON_WIDTH), GUILayout.Height(BUTTON_HEIGHT)))
            {
                FilterSelectedTransforms();
                if (Check())
                {
                    PopupWindow.Show(new Rect(px, 34, 1, 1), new DistributePanel((interval) => {
                        this.interval = interval;
                        
                        BeginUndo();
                        Apply();
                        EndUndo();
                    }));
                }
                ClearSelectedTransforms();
            }
        }
    }
}