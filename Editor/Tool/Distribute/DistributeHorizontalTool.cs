using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class DistributeHorizontalTool : DistributeBaseTool
    {
        public DistributeHorizontalTool()
            : base(277)
        {

        }

        public override void Init()
        {
            icon = Resources.Load<Texture>("distribute_horizontal");
            undoName = "horizontal evenly edge";
        }
        
        protected override async void Apply()
        {
            SortX(selections);

            var k = GetIndex(indicator);
            var s = GetSize(indicator);
            var p = GetPosition(indicator);
            // 左
            var x = p.x;
            var w = s.x;
            for (int i=k+1; i<selections.Count; i++)
            {
                x += w * 0.5f;
                x += interval;

                var t = selections[i];
                w = GetSize(t).x;
                x += w * 0.5f;

                SetPositionX(t, x);
            }
            // 右
            x = p.x;
            w = s.x;
            for (int i=k-1; i>=0; i--)
            {
                x -= w * 0.5f;
                x -= interval;

                var t = selections[i];
                w = GetSize(t).x;
                x -= w * 0.5f;

                SetPositionX(t, x);
            }
        }
    }
}