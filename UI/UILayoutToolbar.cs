using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class UILayoutToolbar
    {
        private List<BaseTool> tools = new List<BaseTool>() {};
        public Rect rect = new Rect(0, 24, 428, 34);

        public void Open()
        {
            tools.Clear();
            
            tools.Add(new AlignTopTool());
            tools.Add(new AlignLeftTool());
            tools.Add(new AlignBottomTool());
            tools.Add(new AlignRightTool());
            tools.Add(new AlignMiddleTool());
            tools.Add(new AlignCenterTool());
            tools.Add(new SeparatorVerticalTool());
            tools.Add(new ResizeHorizontalTool());
            tools.Add(new ResizeVerticalTool());
            tools.Add(new ResizeActualTool());
            tools.Add(new SeparatorVerticalTool());
            tools.Add(new DistributeHorizontalTool());
            tools.Add(new DistributePivotHorizontalTool());
            tools.Add(new DistributeVerticalTool());
            tools.Add(new DistributePivotVerticalTool());
            tools.Add(new SeparatorVerticalTool());
            tools.Add(new CloseTool(this));

            foreach (var tool in tools)
            {
                tool.Init();
            }

            SceneView.duringSceneGui -= DuringSceneGui;
            SceneView.duringSceneGui += DuringSceneGui;
        }

        public void Close()
        {
            SceneView.duringSceneGui -= DuringSceneGui;
        }

        void DuringSceneGui(SceneView sceneView)
        {
            Handles.BeginGUI();
            {
                var viewRect = sceneView.position;
                rect.x = 0;

                GUILayout.BeginArea(viewRect);
                rect = GUILayout.Window(0, rect, OnGUI, "");
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }

        private void OnGUI(int id)
        {
            EditorGUILayout.Space(-20);

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.Space(1);
                foreach (var tool in tools)
                {
                    tool.OnGUI();
                }
                GUILayout.FlexibleSpace();
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    [InitializeOnLoad]
    class UILayoutToolbarLauncher
    {
        private static UILayoutToolbar toolbar = null;

        static UILayoutToolbarLauncher()
        {
            OpenLayoutToolbar();
        }

        [MenuItem("SimpleX/UGUI/Layout")]
        static void OpenLayoutToolbar()
        {
            toolbar = new UILayoutToolbar();
            toolbar.Open();
        }
    }
}