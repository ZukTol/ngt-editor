using NgtEditor.Services;
using NgtEditor.Splat.Extension;
using NgtEditor.ViewModels;
using Splat;

namespace NgtEditor.Avalonia.DependencyInjection
{
    internal class ViewModelsBootstrapper
    {
        public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton(() => new MainWindowViewModel(resolver.GetRequiredService<IDialogService>()));
            services.Register(() => new NewProjectDialogViewModel(resolver.GetRequiredService<ISystemDialogService>()));
        }
    }
}