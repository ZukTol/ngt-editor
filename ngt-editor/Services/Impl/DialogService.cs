using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using ngt_editor.DependencyInjection;
using ngt_editor.ViewModels.Base;
using ngt_editor.Views;
using ngt_editor.Views.Base;
using Splat;

namespace ngt_editor.Services.Impl
{
    internal class DialogService : IDialogService
    {
        private IMainWindowProviderService _mainWindowProviderService;

        public DialogService(IMainWindowProviderService mainWindowProviderService)
        {
            _mainWindowProviderService = mainWindowProviderService;
        }

        public async Task<TResult> ShowDialogAsync<TResult>(string viewModelName) where TResult : DialogResultBase
        {
            var window = CreateView<TResult>(viewModelName);
            var viewModel = CreateViewModel<TResult>(viewModelName);
            Bind(window, viewModel);

            return await ShowDialogAsync(window);
        }

        private static void Bind(IDataContextProvider window, object viewModel) => window.DataContext = viewModel;

        private static DialogWindowBase<TResult> CreateView<TResult>(string viewModelName)
            where TResult : DialogResultBase
        {
            var viewType = GetViewType(viewModelName);
            if (viewType is null)
            {
                throw new InvalidOperationException($"View for {viewModelName} was not found!");
            }

            return (DialogWindowBase<TResult>)GetView(viewType);
        }

        private static DialogViewModelBase<TResult> CreateViewModel<TResult>(string viewModelName)
            where TResult : DialogResultBase
        {
            var viewModelType = GetViewModelType(viewModelName);
            if (viewModelType is null)
            {
                throw new InvalidOperationException($"View model '{viewModelName}' was not found!");
            }

            return (DialogViewModelBase<TResult>)GetViewModel(viewModelType);
        }

        private static Type? GetViewModelType(string viewModelName)
        {
            var viewModelsAssembly = Assembly.GetAssembly(typeof(ViewModelBase));
            if (viewModelsAssembly is null)
            {
                throw new InvalidOperationException("Broken installation!");
            }

            var viewModelTypes = viewModelsAssembly.GetTypes();

            return viewModelTypes.SingleOrDefault(t => t.Name == viewModelName);
        }

        private static object GetView(Type type)
        {
            var view = Activator.CreateInstance(type);
            if (view == null)
            {
                throw new InvalidOperationException($"View '{type.FullName}' was not found!");
            }

            return view;
        }

        private static Type? GetViewType(string viewModelName)
        {
            var viewsAssembly = Assembly.GetExecutingAssembly();
            var viewTypes = viewsAssembly.GetTypes();
            var viewName = viewModelName.Replace("ViewModel", string.Empty);

            return viewTypes.SingleOrDefault(t => t.Name == viewName);
        }

        private static object GetViewModel(Type type) => Locator.Current.GetRequiredService(type);

        private async Task<TResult> ShowDialogAsync<TResult>(DialogWindowBase<TResult> window)
            where TResult : DialogResultBase
        {
            var mainWindow = (MainWindow)_mainWindowProviderService.Get();

            var result = await window.ShowDialog<TResult>(mainWindow);
            if (window is IDisposable disposable)
            {
                disposable.Dispose();
            }

            return result;
        }
    }
}