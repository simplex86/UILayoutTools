using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class DistributeVerticalTool : DistributeBaseTool
    {
        public DistributeVerticalTool()
            : base(331)
        {

        }

        public override void Init()
        {
            icon = Resources.Load<Texture>("distribute_vertical");
            undoName = "vertical evenly edge";
        }

        protected override void Apply()
        {
            SortY(selections);

            var k = GetIndex(indicator);
            var s = GetSize(indicator);
            var p = GetPosition(indicator);

            // 上
            var y = p.y;
            var h = s.y;
            for (int i=k+1; i<selections.Count; i++)
            {
                y += h * 0.5f;
                y += interval;

                var t = selections[i];
                h = GetSize(t).y;
                y += h * 0.5f;

                SetPositionY(t, y);
            }
            // 下
            y = p.y;
            h = s.y;
            for (int i=k-1; i>=0; i--)
            {
                y -= h * 0.5f;
                y -= interval;

                var t = selections[i];
                h = GetSize(t).y;
                y -= h * 0.5f;

                SetPositionY(t, y);
            }
        }
    }
}