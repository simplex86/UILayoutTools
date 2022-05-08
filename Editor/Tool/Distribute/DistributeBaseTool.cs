using System;
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

        protected void SortX(List<RectTransform> transforms)
        {
            transforms.Sort((a, b) => {
                var ax = GetPosition(a).x;
                var bx = GetPosition(b).x;

                if (Math.Abs(ax - bx) < float.Epsilon) return 0;
                return (ax > bx) ? 1 : -1;
            });
        }

        protected void SortY(List<RectTransform> transforms)
        {
            transforms.Sort((a, b) => {
                var ay = GetPosition(a).y;
                var by = GetPosition(b).y;

                if (Math.Abs(ay - by) < float.Epsilon) return 0;
                return (ay > by) ? 1 : -1;
            });
        }

        protected int GetIndex(RectTransform transform)
        {
            for (int i=0; i<selections.Count; i++)
            {
                if (selections[i] == transform) return i;
            }
            return -1;
        }
    }
}