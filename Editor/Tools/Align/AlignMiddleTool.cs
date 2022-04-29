using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignMiddleTool : LayoutBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_middle");
            undoName = "align middle";
        }

        protected override void Apply()
        {
            var y = selecteds[0].localPosition.y;
            foreach (var t in selecteds)
            {
                var p = t.localPosition;
                var s = GetSize(t);

                t.localPosition = new Vector3(p.x, y, p.z);
            }
        }
    }
}