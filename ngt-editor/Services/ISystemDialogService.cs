using System.Threading.Tasks;

namespace NgtEditor.Avalonia.Services
{
    public interface ISystemDialogService
    {
        Task<string> GetDirectoryAsync(string initialDirectory = null);

        Task<string[]> GetOpenFileAsync(string initialFile = null);
    }
}