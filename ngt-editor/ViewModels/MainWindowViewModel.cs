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
        private Project _currentProject;

        public IDialogService DialogService { get; set; }

        public ICommand NewProjectCommand { get; }

        public MainWindowViewModel()
        {
            NewProjectCommand = ReactiveCommand.CreateFromTask(CreateNewProject);
        }

        private async Task CreateNewProject()
        {
            var dialogResult = await DialogService.ShowDialogAsync<NewProjectDialogResult>(nameof(NewProjectDialogViewModel));
            if (dialogResult?.Project != null)
            {
                _currentProject = dialogResult.Project;
            }
        }
    }
}