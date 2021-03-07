using System.Collections.ObjectModel;
using System.Windows.Input;
using NgtEditor.Models;
using NgtEditor.ViewModels.Base;
using ReactiveUI;

namespace NgtEditor.ViewModels
{
    public class NewProjectDialogViewModel : DialogViewModelBase<NewProjectDialogResult>
    {
        public ObservableCollection<LangFile> LanguageList { get; } = new();

        public ICommand AddLangDirectoryCommand { get; }

        public NewProjectDialogViewModel()
        {
            AddLangDirectoryCommand = ReactiveCommand.Create(() => AddLangDirectory());
        }

        private void AddLangDirectory()
        {
        }
    }
}