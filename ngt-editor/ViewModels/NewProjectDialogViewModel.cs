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
        private readonly ISystemDialogService _systemDialogService;
        private readonly ILangFileSearchService _langFileSearchService;

        public ObservableCollection<LangFile> LanguageList { get; } = new();

        public ICommand AddLangDirectoryCommand { get; }

        public NewProjectDialogViewModel(ISystemDialogService systemDialogService, ILangFileSearchService langFileSearchService)
        {
            _langFileSearchService = langFileSearchService;
            _systemDialogService = systemDialogService;

            AddLangDirectoryCommand = ReactiveCommand.CreateFromTask(AddLangDirectory);
        }

        private async Task AddLangDirectory()
        {
            var directory = await _systemDialogService.GetDirectoryAsync();
            var langList = _langFileSearchService.GetLangListInDirectory(directory);

            LanguageList.Clear();
            foreach (var item in langList)
            {
                LanguageList.Add(item);
            }
        }
    }
}