using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class DistributePivotVerticalTool : DistributeBaseTool
    {
        public DistributePivotVerticalTool()
            : base(358)
        {

        }

        public override void Init()
        {
            icon = Resources.Load<Texture>("distribute_vertical_center");
            undoName = "vertical evenly center";
        }

        protected override void Apply()
        {
            SortY(selections);

            var k = GetIndex(indicator);
            var p = GetPosition(indicator);

            // 上
            var y = p.y;
            for (int i=k+1; i<selections.Count; i++)
            {
                var t = selections[i];
                y += interval;
                SetPositionY(t, y);
            }
            // 下
            y = p.y;
            for (int i=k-1; i>=0; i--)
            {
                var t = selections[i];
                y -= interval;
                SetPositionY(t, y);
            }
        }
    }
}