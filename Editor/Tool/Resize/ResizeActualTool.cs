using System.Collections.Generic;
using UnityEngine;

namespace SimpleX.Client.Editor.UGUI
{
    class ResizeActualTool : ResizeBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("resize_actual");
            undoName = "same size";
        }

        protected override void Apply()
        {
            var size = GetSize(indicator);
            foreach (var t in selections)
            {
                SetSize(t, size);
            }
        }
    }
}