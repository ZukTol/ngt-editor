using System.Threading.Tasks;
using ngt_editor.ViewModels.Base;

namespace ngt_editor.Services
{
    public interface IDialogService
    {
        Task<TResult?> ShowDialogAsync<TResult>(string viewModelName)
            where TResult : DialogResultBase;
    }
}