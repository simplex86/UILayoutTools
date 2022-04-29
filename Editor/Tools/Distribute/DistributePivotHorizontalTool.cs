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
            var x = indicator.localPosition.x;

            foreach (var t in selecteds)
            {
                if (t != indicator)
                {
                    x += interval;

                    var p = t.localPosition;
                    t.localPosition = new Vector3(x, p.y, p.z);
                }
            }
        }

        protected override RectTransform FilterIndicatorTransform()
        {
            var transform = selecteds[0];
            var x = transform.localPosition.x;

            for (int i=1; i<selecteds.Count; i++)
            {
                if (selecteds[i].localPosition.x < x)
                {
                    transform = selecteds[i];
                    x = transform.localPosition.x;
                }
            }

            return transform;
        }
    }
}