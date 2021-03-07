using System.Threading.Tasks;
using System.Windows.Input;
using NgtEditor.Models;
using NgtEditor.Services;
using NgtEditor.ViewModels.Base;
using ReactiveUI;

namespace NgtEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Project? _currentProject;

        private readonly IDialogService _dialogService;

        public ICommand NewProjectCommand { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            NewProjectCommand = ReactiveCommand.CreateFromTask(CreateNewProject);
        }

        private async Task CreateNewProject()
        {
            var dialogResult = await _dialogService.ShowDialogAsync<NewProjectDialogResult>(nameof(NewProjectDialogViewModel));
            if (dialogResult?.Project != null)
            {
                _currentProject = dialogResult.Project;
            }
        }
    }
}