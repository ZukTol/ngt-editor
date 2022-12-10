using System;
using System.Threading;

namespace NgtEditor.Common.Extensions
{
    public static class EventArgExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, object sender,
            ref EventHandler<TEventArgs> eventDelegate)
        {
            var temp = Volatile.Read(ref eventDelegate);

            temp?.Invoke(sender, e);
        }
    }
}