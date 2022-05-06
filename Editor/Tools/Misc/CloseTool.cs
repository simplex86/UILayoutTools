using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    class CloseTool : MiscBaseTool
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

        protected override void Apply()
        {
            toolbar.Close();
        }
    }
}