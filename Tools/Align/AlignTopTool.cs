using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    public class AlignTopTool : BaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_top");
        }

        protected override void Apply()
        {
            var y = GetTopY(indicator);
            foreach (var t in selecteds)
            {
                var p = t.localPosition;
                var s = GetSize(t);

                t.localPosition = new Vector3(p.x, y - s.y * 0.5f, p.z);
            }
        }

        protected override RectTransform FilterIndicatorTransform()
        {
            var transform = selecteds[0];
            var maxy = GetTopY(transform);
            
            for (int i=1; i<selecteds.Count; i++)
            {
                var y = GetTopY(selecteds[i]);
                if (y > maxy)
                {
                    maxy = y;
                    transform = selecteds[i]; 
                }
            }

            return transform;
        }


        private float GetTopY(RectTransform transform)
        {
            var y = transform.localPosition.y + GetSize(transform).y * 0.5f;
            return y;
        }
    }
}