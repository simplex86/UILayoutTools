using UnityEngine;
using UnityEditor;

namespace SimpleX.Client.Editor.UGUI
{
    abstract class MiscBaseTool : LayoutBaseTool
    {
        public override void Init()
        {
            
        }
        
        protected override bool Check()
        {
            return false;
        }

        protected virtual void BeginUndo()
        {
            
        }

        protected virtual void EndUndo()
        {
            
        }

        protected override void Apply()
        {
            
        }
    }
}