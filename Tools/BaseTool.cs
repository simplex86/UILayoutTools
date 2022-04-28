using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    public abstract class BaseTool
    {
        public Texture icon { get; protected set; }

        protected List<RectTransform> selecteds { get; } = new List<RectTransform>();
        protected RectTransform indicator { get; private set; }

        protected const int BUTTON_WIDTH = 24;
        protected const int BUTTON_HEIGHT = 24;

        // 初始化，用于加载资源
        public abstract void Init();

        // 
        public virtual void OnGUI()
        {
            if (GUILayout.Button(icon, GUILayout.Width(BUTTON_WIDTH), GUILayout.Height(BUTTON_HEIGHT)))
            {
                FilterSelectedTransforms();
                if (Check()) Apply();
                ClearSelectedTransforms();
            }
        }

        // 检测是否满足执行条件
        protected virtual bool Check()
        {
            return selecteds.Count > 1 && indicator != null;
        }

        // 执行功能
        protected abstract void Apply();

        // 筛选被选中的RectTransform
        private void FilterSelectedTransforms()
        {
            ClearSelectedTransforms();

            foreach (var go in Selection.gameObjects)
            {
                var rt = go.transform as RectTransform;
                if (rt != null)
                {
                    selecteds.Add(rt);
                }
            }
            indicator = (selecteds.Count == 0) ? null : FilterIndicatorTransform();
        }

        // 清除被选中的Transform数据
        private void ClearSelectedTransforms()
        {
            indicator = null;
            selecteds.Clear();
        }

        // 筛选参照物，默认是选中列表的第一个
        protected virtual RectTransform FilterIndicatorTransform()
        {
            return selecteds[0];
        }

        // 获取大小
        protected Vector2 GetSize(RectTransform transform)
        {
            return transform.rect.size;
        }

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