using Avalonia.Controls;
using System.Threading.Tasks;

namespace NgtEditor.Services.Impl
{
    internal class SystemDialogService : ISystemDialogService
    {
        private readonly IMainWindowProviderService _mainWindowProvider;

        public SystemDialogService(IMainWindowProviderService mainWindowProvider)
        {
            _mainWindowProvider = mainWindowProvider;
        }

        public async Task<string> GetDirectoryAsync(string? initialDirectory = null)
        {
            var dialog = new OpenFolderDialog { Directory = initialDirectory };
            var window = _mainWindowProvider.Get();

            return await dialog.ShowAsync(window);
        }

        public async Task<string> GetFileAsync(string? initialFile = null)
        {
            var dialog = new SaveFileDialog { InitialFileName = initialFile };
            var window = _mainWindowProvider.Get();

            return await dialog.ShowAsync(window);
        }
    }
}