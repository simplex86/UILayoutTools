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
            var y = indicator.localPosition.y;

            foreach (var t in selecteds)
            {
                if (t != indicator)
                {
                    y -= interval;

                    var p = t.localPosition;
                    t.localPosition = new Vector3(p.x, y, p.z);
                }
            }
        }

        protected override RectTransform FilterIndicatorTransform()
        {
            var transform = selecteds[0];
            var y = transform.localPosition.y;

            for (int i=1; i<selecteds.Count; i++)
            {
                if (selecteds[i].localPosition.y > y)
                {
                    transform = selecteds[i];
                    y = transform.localPosition.y;
                }
            }

            return transform;
        }
    }
}