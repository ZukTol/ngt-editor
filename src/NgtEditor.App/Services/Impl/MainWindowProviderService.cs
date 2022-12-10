using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace NgtEditor.Services.Impl
{
    internal class MainWindowProviderService : IMainWindowProviderService
    {
        public Window Get()
        {
            var lifetime = (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;

            return lifetime.MainWindow;
        }
    }
}