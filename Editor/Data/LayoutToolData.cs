using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class LayoutToolData
    {
        public RectTransform indicator { get; private set; }

        private List<RectTransform> mSelections = new List<RectTransform>();
        public List<RectTransform> selections
        {
            get
            {
                if (mSelections.Count == 0)
                {
                    List<RectTransform> list = FilterSelectedTransforms();
                    foreach (var rt in list)
                    {
                        if (rt != indicator)
                        {
                            mSelections.Add(rt);
                        }
                    }
                }
                return mSelections;
            }
        }

        public static LayoutToolData Instance { get; } = new LayoutToolData();

        private LayoutToolData()
        {
            
        }

        public void Init()
        {
            Selection.selectionChanged -= OnSelectionChangedHandler;
            Selection.selectionChanged += OnSelectionChangedHandler;           
        }

        public void Dispose()
        {
            ClearSelectedTransforms();
            Selection.selectionChanged -= OnSelectionChangedHandler;
        }

        private void OnSelectionChangedHandler()
        {
            List<RectTransform> list = FilterSelectedTransforms();
            if (list.Count > 1) return;

            ClearSelectedTransforms();
            if (list.Count == 1) indicator = list[0];
        }

        private List<RectTransform> FilterSelectedTransforms()
        {
            List<RectTransform> list = new List<RectTransform>();

            var gameobjects = Selection.GetFiltered(typeof(GameObject), SelectionMode.Editable | SelectionMode.TopLevel);
            foreach (GameObject go in gameobjects)
            {
                // 不在hierarchy窗口中
                if (EditorUtility.IsPersistent(go)) continue;
                // 在project窗口中（脚本文件等会漏过IsPersistent的判断）
                var assetpath = AssetDatabase.GetAssetPath(go);
                if (!string.IsNullOrEmpty(assetpath)) continue;

                var rt = go.transform as RectTransform;
                if (rt != null) list.Add(rt);
            }

            return list;
        }

        // 清除被选中的Transform数据
        private void ClearSelectedTransforms()
        {
            indicator = null;
            mSelections.Clear();
        }
    }
}