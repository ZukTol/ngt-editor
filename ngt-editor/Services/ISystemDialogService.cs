using System.Threading.Tasks;

namespace NgtEditor.Services
{
    public interface ISystemDialogService
    {
        Task<string> GetDirectoryAsync(string initialDirectory = null);

        Task<string> GetFileAsync(string initialFile = null);
    }
}