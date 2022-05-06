using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignBottomTool : AlignBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_bottom");
            undoName = "align bottom";
        }
        
        protected override void Apply()
        {
            var y = GetBottomY(indicator);
            foreach (var t in selecteds)
            {
                var p = GetPosition(t);
                var s = GetSize(t);
                SetPositionY(t, y + s.y * 0.5f);
            }
        }

        protected override RectTransform FilterIndicatorTransform()
        {
            var transform = selecteds[0];
            var miny = GetBottomY(transform);
            
            for (int i=1; i<selecteds.Count; i++)
            {
                var y = GetBottomY(selecteds[i]);
                if (y < miny)
                {
                    miny = y;
                    transform = selecteds[i]; 
                }
            }

            return transform;
        }

        private float GetBottomY(RectTransform transform)
        {
            var y = GetPosition(transform).y - GetSize(transform).y * 0.5f;
            return y;
        }
    }
}