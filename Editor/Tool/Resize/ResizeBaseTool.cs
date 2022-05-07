using UnityEngine;

namespace SimpleX.Client.Editor.UGUI
{
    abstract class ResizeBaseTool : LayoutBaseTool
    {
        // 设置宽度
        protected void SetWidth(RectTransform transform, float width)
        {
            transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }

        // 设置高度
        protected void SetHeight(RectTransform transform, float height)
        {
            transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        // 设置大小
        protected void SetSize(RectTransform transform, Vector2 size)
        {
            SetSize(transform, size.x, size.y);
        }

        // 设置大小
        protected void SetSize(RectTransform transform, float width, float height)
        {
            SetWidth(transform, width);
            SetHeight(transform, height);
        }
    }
}