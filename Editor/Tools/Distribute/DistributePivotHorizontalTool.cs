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
            var x = GetPosition(indicator).x;

            foreach (var t in selecteds)
            {
                if (t != indicator)
                {
                    x += interval;
                    SetPositionX(t, x);
                }
            }
        }

        protected override RectTransform FilterIndicatorTransform()
        {
            var transform = selecteds[0];
            var x = GetPosition(transform).x;

            for (int i=1; i<selecteds.Count; i++)
            {
                if (GetPosition(selecteds[i]).x < x)
                {
                    transform = selecteds[i];
                    x = GetPosition(transform).x;
                }
            }

            return transform;
        }
    }
}