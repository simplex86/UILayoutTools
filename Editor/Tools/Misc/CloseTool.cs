using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class CloseTool : LayoutBaseTool
    {
        private UILayoutToolbar toolbar = null;

        public CloseTool(UILayoutToolbar toolbar)
        {
            this.toolbar = toolbar;
        }

        public override void Init()
        {
            icon = Resources.Load<Texture>("quit");
        }

        protected override bool Check()
        {
            return true;
        }

        protected virtual void BeginUndo()
        {
            
        }

        protected virtual void EndUndo()
        {
            
        }

        protected override void Apply()
        {
            toolbar.Close();
        }
    }
}