using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignLeftTool : LayoutBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_left");
            undoName = "align left";
        }

        protected override void Apply()
        {
            var x = GetLeftX(indicator);
            foreach (var t in selecteds)
            {
                var p = t.localPosition;
                var s = GetSize(t);

                t.localPosition = new Vector3(x + s.x * 0.5f, p.y, p.z);
            }
        }

        protected override RectTransform FilterIndicatorTransform()
        {
            var transform = selecteds[0];
            var minx = GetLeftX(transform);
            
            for (int i=1; i<selecteds.Count; i++)
            {
                var x = GetLeftX(selecteds[i]);
                if (x < minx)
                {
                    minx = x;
                    transform = selecteds[i]; 
                }
            }

            return transform;
        }

        private float GetLeftX(RectTransform transform)
        {
            var x = transform.localPosition.x - GetSize(transform).x * 0.5f;
            return x;
        }
    }
}