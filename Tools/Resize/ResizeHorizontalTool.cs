using System.Collections.Generic;
using UnityEngine;

namespace SimpleX.Client.Editor.UGUI
{
    class ResizeHorizontalTool : BaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("resize_horizontal");
        }

        protected override void Apply()
        {
            var size = GetSize(indicator);
            foreach (var t in selecteds)
            {
                SetWidth(t, size.x);
            }
        }
    }
}