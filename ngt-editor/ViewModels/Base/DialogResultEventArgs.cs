using System;

namespace ngt_editor.ViewModels.Base
{
    public class DialogResultEventArgs<TResult> : EventArgs
    {
        public TResult Result { get; set; }

        public DialogResultEventArgs(TResult result)
        {
            Result = result;
        }
    }
}