using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignCenterTool : AlignBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_center");
            undoName = "align center";
        }
        
        protected override void Apply()
        {
            var x = GetPosition(indicator).x;
            foreach (var t in selections)
            {
                var s = GetSize(t);
                SetPositionX(t, x);
            }
        }
    }
}