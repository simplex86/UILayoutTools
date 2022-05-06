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
            var s = GetSize(indicator);
            var x = GetPosition(indicator).x;

            foreach (var t in selecteds)
            {
                if (t != indicator)
                {
                    x += s.x * 0.5f;
                    x += interval;

                    s = GetSize(t);
                    x += s.x * 0.5f;

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