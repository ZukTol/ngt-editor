using System.Threading.Tasks;
using NgtEditor.ViewModels.Base;

namespace NgtEditor.Services
{
    public interface IDialogService
    {
        Task<TResult> ShowDialogAsync<TResult>(string viewModelName)
            where TResult : DialogResultBase;
    }
}