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
            var y = GetPosition(indicator).y;

            foreach (var t in selections)
            {
                if (t != indicator)
                {
                    y -= interval;
                    SetPositionY(t, y);
                }
            }
        }

        // protected override RectTransform FilterIndicatorTransform()
        // {
        //     var transform = selecteds[0];
        //     var y = GetPosition(transform).y;

        //     for (int i=1; i<selecteds.Count; i++)
        //     {
        //         if (GetPosition(selecteds[i]).y > y)
        //         {
        //             transform = selecteds[i];
        //             y = GetPosition(transform).y;
        //         }
        //     }

        //     return transform;
        // }
    }
}