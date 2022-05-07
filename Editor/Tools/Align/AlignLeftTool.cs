using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignLeftTool : AlignBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_left");
            undoName = "align left";
        }

        protected override void Apply()
        {
            var x = GetLeftX(indicator);
            foreach (var t in selections)
            {
                var p = GetPosition(t);
                var s = GetSize(t);
                SetPositionX(t, x + s.x * 0.5f);
            }
        }

        // protected override RectTransform FilterIndicatorTransform()
        // {
        //     var transform = selecteds[0];
        //     var minx = GetLeftX(transform);
            
        //     for (int i=1; i<selecteds.Count; i++)
        //     {
        //         var x = GetLeftX(selecteds[i]);
        //         if (x < minx)
        //         {
        //             minx = x;
        //             transform = selecteds[i]; 
        //         }
        //     }

        //     return transform;
        // }

        private float GetLeftX(RectTransform transform)
        {
            var x = GetPosition(transform).x - GetSize(transform).x * 0.5f;
            return x;
        }
    }
}