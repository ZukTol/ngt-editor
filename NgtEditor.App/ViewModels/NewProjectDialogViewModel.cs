using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NgtEditor.Avalonia.Services;
using NgtEditor.Common.Utils;
using NgtEditor.Models;
using NgtEditor.Services;
using NgtEditor.ViewModels;
using NgtEditor.ViewModels.Base;
using ReactiveUI;

namespace NgtEditor.Avalonia.ViewModels
{
    public class NewProjectDialogViewModel : DialogViewModelBase<NewProjectDialogResult>
    {
        public ISystemDialogService SystemDialogService { get; set; }
        public ILangFileSearchService LangFileSearchService { get; set; }

        public ObservableCollection<LangFile> LanguageList { get; } = new();

        public ICommand AddLangDirectoryCommand { get; }
        public ICommand AddLangFileCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }


        public NewProjectDialogViewModel()
        {
            AddLangDirectoryCommand = ReactiveCommand.CreateFromTask(AddLangDirectory);
            AddLangFileCommand = ReactiveCommand.CreateFromTask(AddLangFile);
            CreateCommand = ReactiveCommand.Create(Create, 
                this.WhenAnyValue(x => x.LanguageList.Count, x => x > 0));
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        private void Create()
        {
            Close(new NewProjectDialogResult { Project = new Project { LangList = LanguageList.ToArray() } });
        }

        private void Cancel()
        {
            LanguageList.Clear();
            Close(null);
        }

        private async Task AddLangDirectory()
        {
            var directory = await SystemDialogService.GetDirectoryAsync();
            if (directory.IsNullOrEmpty())
                return;

            var langList = LangFileSearchService.GetLangListInDirectory(directory);

            LanguageList.Clear();
            foreach (var item in langList)
            {
                LanguageList.Add(item);
            }
        }

        private async Task AddLangFile()
        {
            var filePathList = await SystemDialogService.GetOpenFileAsync();
            if (filePathList.Length == 0)
                return;

            foreach (var filePath in filePathList.Where(x => !LanguageList.Any(y => y.Path.OrdinalEquals(x))))
            {
                var lang = LangFileSearchService.GetLangFromPath(filePath);
                LanguageList.Add(lang);
            }
        }
    }
}