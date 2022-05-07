using System.Collections.Generic;
using UnityEngine;

namespace SimpleX.Client.Editor.UGUI
{
    class ResizeHorizontalTool : ResizeBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("resize_horizontal");
            undoName = "same width";
        }

        protected override void Apply()
        {
            var size = GetSize(indicator);
            foreach (var t in selections)
            {
                SetWidth(t, size.x);
            }
        }
    }
}