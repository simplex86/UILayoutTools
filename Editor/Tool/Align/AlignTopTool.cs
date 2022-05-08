using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignTopTool : AlignBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_top");
            undoName = "align top";
        }

        protected override async void Apply()
        {
            var y = GetTopY(indicator);
            foreach (var t in selections)
            {
                var p = GetPosition(t);
                var s = GetSize(t);
                SetPositionY(t, y - s.y * 0.5f);
            }
        }

        private float GetTopY(RectTransform transform)
        {
            var y = GetPosition(transform).y + GetSize(transform).y * 0.5f;
            return y;
        }
    }
}