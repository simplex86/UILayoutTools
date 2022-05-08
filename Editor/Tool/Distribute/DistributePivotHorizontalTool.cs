using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class DistributePivotHorizontalTool : DistributeBaseTool
    {
        public DistributePivotHorizontalTool()
            : base(304)
        {

        }

        public override void Init()
        {
            icon = Resources.Load<Texture>("distribute_horizontal_center");
            undoName = "horizontal evenly center";
        }
        
        protected override void Apply()
        {
            SortX(selections);

            var k = GetIndex(indicator);
            var p = GetPosition(indicator);

            // 左
            var x = p.x;
            for (int i=k+1; i<selections.Count; i++)
            {
                var t = selections[i];
                x += interval;
                SetPositionX(t, x);
            }
            // 右
            x = p.x;
            for (int i=k-1; i>=0; i--)
            {
                var t = selections[i];
                x -= interval;
                SetPositionX(t, x);
            }
        }
    }
}