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
            foreach (var t in selections)
            {
                var p = GetPosition(t);
                var s = GetSize(t);
                SetPositionY(t, y + s.y * 0.5f);
            }
        }

        private float GetBottomY(RectTransform transform)
        {
            var y = GetPosition(transform).y - GetSize(transform).y * 0.5f;
            return y;
        }
    }
}