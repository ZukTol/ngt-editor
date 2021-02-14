using System.Collections.ObjectModel;
using System.Windows.Input;
using ngt_editor.Models;
using ngt_editor.ViewModels.Base;
using ReactiveUI;

namespace ngt_editor.ViewModels
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