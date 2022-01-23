using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NgtEditor.Models;
using NgtEditor.Services;
using NgtEditor.ViewModels.Base;
using ReactiveUI;

namespace NgtEditor.ViewModels
{
    public class NewProjectDialogViewModel : DialogViewModelBase<NewProjectDialogResult>
    {
        public ISystemDialogService SystemDialogService { get; set; }
        public ILangFileSearchService LangFileSearchService { get; set; }

        public ObservableCollection<LangFile> LanguageList { get; } = new();

        public ICommand AddLangDirectoryCommand { get; }
        
        
        public NewProjectDialogViewModel()
        {
            AddLangDirectoryCommand = ReactiveCommand.CreateFromTask(AddLangDirectory);
        }

        private async Task AddLangDirectory()
        {
            var directory = await SystemDialogService.GetDirectoryAsync();
            if (string.IsNullOrEmpty(directory))
            {
                return;
            }

            var langList = LangFileSearchService.GetLangListInDirectory(directory);

            LanguageList.Clear();
            foreach (var item in langList)
            {
                LanguageList.Add(item);
            }
        }
    }
}