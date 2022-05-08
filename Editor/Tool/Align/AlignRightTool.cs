using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignRightTool : AlignBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_right");
            undoName = "align right";
        }

        protected override async void Apply()
        {
            var x = GetRightX(indicator);
            foreach (var t in selections)
            {
                var p = GetPosition(t);
                var s = GetSize(t);
                SetPositionX(t, x - s.x * 0.5f);
            }
        }

        private float GetRightX(RectTransform transform)
        {
            var x = GetPosition(transform).x + GetSize(transform).x * 0.5f;
            return x;
        }
    }
}