using System;

namespace NgtEditor.ViewModels.Base
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