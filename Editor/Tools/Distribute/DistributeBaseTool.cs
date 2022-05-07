using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    abstract class DistributeBaseTool : LayoutBaseTool
    {
        protected float interval { get; private set; } = 0;
        private float px = 0;

        protected DistributeBaseTool(float x)
        {
            px = x;
        }

        // 
        protected override void OnClick()
        {
            // FilterSelectedTransforms();
            if (Check())
            {
                PopupWindow.Show(new Rect(px, 34, 1, 1), new DistributePanel((interval) => {
                    this.interval = interval;
                    
                    BeginUndo();
                    Apply();
                    EndUndo();
                }));
            }
            // ClearSelectedTransforms();
        }

        protected void SetPosition(RectTransform transform, Vector3 pos)
        {
            transform.localPosition = pos;
        }

        protected void SetPositionX(RectTransform transform, float x)
        {
            var pos = transform.localPosition;
            pos.x = x;
            transform.localPosition = pos;
        }

        protected void SetPositionY(RectTransform transform, float y)
        {
            var pos = transform.localPosition;
            pos.y = y;
            transform.localPosition = pos;
        }
    }
}