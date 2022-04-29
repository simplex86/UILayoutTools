using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    public class DistributePanel : PopupWindowContent
    {
        private float interval = 0;
        private System.Action<float> callback;

        public static readonly Vector2 size = new Vector2(150, 26);

        public DistributePanel(System.Action<float> callback)
        {
            this.callback = callback;
        }

        public override Vector2 GetWindowSize()
        {
            return size;
        }

        public override void OnGUI(Rect rect)
        {
            Vector2 size = GetWindowSize();
            using (var areaScope = new GUILayout.HorizontalScope(GUILayout.Width(size.x), GUILayout.Height(size.y - 20)))
            {
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.Space(2);

                    EditorGUILayout.LabelField("间距", GUILayout.Width(30));
                    interval = EditorGUILayout.FloatField(interval);
                    EditorGUILayout.Space(2);
                    if (GUILayout.Button("GO", GUILayout.Width(30)))
                    {
                        if(callback != null) callback(interval);
                    }
                    EditorGUILayout.Space(2);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}