using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class AlignMiddleTool : AlignBaseTool
    {
        public override void Init()
        {
            icon = Resources.Load<Texture>("alignment_middle");
            undoName = "align middle";
        }

        protected override async void Apply()
        {
            var y = GetPosition(indicator).y;
            foreach (var t in selections)
            {
                var s = GetSize(t);
                SetPositionY(t, y);
            }
        }
    }
}