using System;
using NgtEditor.Common.Extensions;

namespace NgtEditor.ViewModels.Base
{
    public class DialogViewModelBase<TResult> : ViewModelBase where TResult : DialogResultBase
    {
        public event EventHandler<DialogResultEventArgs<TResult?>> CloseRequested;

        protected void Close()
        {
            Close(default);
        }

        protected void Close(TResult? result)
        {
            var args = new DialogResultEventArgs<TResult?>(result);

            args.Raise(this, ref CloseRequested);
        }
    }

    public class DialogViewModelBase : DialogViewModelBase<DialogResultBase>
    {
    }
}