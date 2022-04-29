using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignCenterTool : LayoutBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_center");
            undoName = "align center";
        }
        
        protected override void Apply()
        {
            var x = indicator.localPosition.x;
            foreach (var t in selecteds)
            {
                var p = t.localPosition;
                var s = GetSize(t);

                t.localPosition = new Vector3(x, p.y, p.z);
            }
        }
    }
}