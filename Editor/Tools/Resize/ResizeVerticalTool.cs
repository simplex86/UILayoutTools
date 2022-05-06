using System.Collections.Generic;
using UnityEngine;

namespace SimpleX.Client.Editor.UGUI
{
    class ResizeVerticalTool : ResizeBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("resize_vertical");
            undoName = "same height";
        }

        protected override void Apply()
        {
            var size = GetSize(indicator);
            foreach (var t in selecteds)
            {
                SetHeight(t, size.y);
            }
        }
    }
}