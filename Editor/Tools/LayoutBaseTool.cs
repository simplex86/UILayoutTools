using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    abstract class LayoutBaseTool
    {
        public Texture icon { get; protected set; }

        protected List<RectTransform> selections { get { return LayoutToolData.Instance.selections; } }
        protected RectTransform indicator { get { return LayoutToolData.Instance.indicator; } }
        protected string undoName = string.Empty;

        protected const int BUTTON_WIDTH = 24;
        protected const int BUTTON_HEIGHT = 24;

        // 初始化，用于加载资源
        public abstract void Init();

        // 
        public virtual void OnGUI()
        {
            if (GUILayout.Button(icon, GUILayout.Width(BUTTON_WIDTH), GUILayout.Height(BUTTON_HEIGHT)))
            {
                OnClick();
            }
        }

        // 点击响应
        protected virtual void OnClick()
        {
                // FilterSelectedTransforms();
                if (Check())
                {
                    BeginUndo();
                    Apply();
                    EndUndo();
                }
                // ClearSelectedTransforms();
        }

        // 检测是否满足执行条件
        protected virtual bool Check()
        {
            return selections.Count > 1 && indicator != null;
        }

        protected virtual void BeginUndo()
        {
            var selections = LayoutToolData.Instance.selections;

            foreach (var o in selections)
            {
                Undo.RecordObject(o, undoName);
            }
        }

        protected virtual void EndUndo()
        {
            // Undo.IncrementCurrentGroup();
        }

        // 执行功能
        protected abstract void Apply();

        // 筛选被选中的RectTransform
        // protected void FilterSelectedTransforms()
        // {
        //     ClearSelectedTransforms();

        //     // var gameobjects = Selection.gameObjects;
        //     var gameobjects = Selection.GetFiltered(typeof(GameObject), SelectionMode.Editable | SelectionMode.TopLevel);
        //     foreach (GameObject go in gameobjects)
        //     {
        //         // 不在hierarchy窗口中
        //         if (EditorUtility.IsPersistent(go)) continue;
        //         // 在project窗口中（脚本文件等会漏过IsPersistent的判断）
        //         var assetpath = AssetDatabase.GetAssetPath(go);
        //         if (!string.IsNullOrEmpty(assetpath)) continue;

        //         var rt = go.transform as RectTransform;
        //         if (rt != null)
        //         {
        //             selecteds.Add(rt);
        //         }
        //     }
        //     indicator = (selecteds.Count == 0) ? null : FilterIndicatorTransform();
        // }

        // // 清除被选中的Transform数据
        // protected void ClearSelectedTransforms()
        // {
        //     indicator = null;
        //     selecteds.Clear();
        // }

        // 筛选参照物，默认是选中列表的第一个
        // protected virtual RectTransform FilterIndicatorTransform()
        // {
        //     return selecteds[0];
        // }

        // 获取坐标
        protected Vector3 GetPosition(RectTransform transform)
        {
            return transform.localPosition;
        }

        // 获取大小
        protected Vector2 GetSize(RectTransform transform)
        {
            return transform.rect.size;
        }
    }
}