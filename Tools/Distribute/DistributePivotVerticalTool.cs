using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class DistributePivotVerticalTool : BaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("distribute_vertical_center");
        }

        protected override void Apply()
        {
            PopupWindow.Show(new Rect(358, 34, 1, 1), new DistributePanel((interval) => {
                Distribute(interval);
            }));
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

        private void Distribute(float interval)
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
    }
}