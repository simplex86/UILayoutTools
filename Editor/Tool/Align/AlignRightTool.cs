using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignRightTool : AlignBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_right");
            undoName = "align right";
        }

        protected override async void Apply()
        {
            var x = GetRightX(indicator);
            foreach (var t in selections)
            {
                var p = GetPosition(t);
                var s = GetSize(t);
                SetPositionX(t, x - s.x * 0.5f);
            }
        }

        // protected override RectTransform FilterIndicatorTransform()
        // {
        //     var transform = selecteds[0];
        //     var maxx = GetRightX(transform);
            
        //     for (int i=1; i<selecteds.Count; i++)
        //     {
        //         var x = GetRightX(selecteds[i]);
        //         if (x > maxx)
        //         {
        //             maxx = x;
        //             transform = selecteds[i]; 
        //         }
        //     }

        //     return transform;
        // }

        private float GetRightX(RectTransform transform)
        {
            var x = GetPosition(transform).x + GetSize(transform).x * 0.5f;
            return x;
        }
    }
}