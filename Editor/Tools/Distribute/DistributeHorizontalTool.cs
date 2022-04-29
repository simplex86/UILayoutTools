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
        
        protected override void Apply()
        {
            var s = GetSize(indicator);
            var x = indicator.localPosition.x;

            foreach (var t in selecteds)
            {
                if (t != indicator)
                {
                    x += s.x * 0.5f;
                    x += interval;

                    s = GetSize(t);
                    x += s.x * 0.5f;

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