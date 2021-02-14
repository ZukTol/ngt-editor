using System.Threading.Tasks;
using System.Windows.Input;
using ngt_editor.Models;
using ngt_editor.Services;
using ngt_editor.ViewModels.Base;
using ReactiveUI;

namespace ngt_editor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Project? _currentProject;

        private readonly IDialogService _dialogService;

        public string Greeting => "Welcome to Avalonia!";

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