using UnityEngine;

namespace SimpleX.Client.Editor.UGUI
{
    abstract class AlignBaseTool : LayoutBaseTool
    {
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