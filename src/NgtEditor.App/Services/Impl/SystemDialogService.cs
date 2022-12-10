using System.Threading.Tasks;
using Avalonia.Controls;
using JetBrains.Annotations;
using NgtEditor.Services;

namespace NgtEditor.Avalonia.Services.Impl
{
    [UsedImplicitly]
    internal class SystemDialogService : ISystemDialogService
    {
        private readonly IMainWindowProviderService _mainWindowProvider;

        public SystemDialogService(IMainWindowProviderService mainWindowProvider)
        {
            _mainWindowProvider = mainWindowProvider;
        }

        public async Task<string> GetDirectoryAsync(string initialDirectory = null)
        {
            var dialog = new OpenFolderDialog { Directory = initialDirectory };
            var window = _mainWindowProvider.Get();

            return await dialog.ShowAsync(window);
        }

        public async Task<string[]> GetOpenFileAsync(string initialFile = null)
        {
            var dialog = new OpenFileDialog { InitialFileName = initialFile };
            var window = _mainWindowProvider.Get();

            return await dialog.ShowAsync(window);
        }
    }
}