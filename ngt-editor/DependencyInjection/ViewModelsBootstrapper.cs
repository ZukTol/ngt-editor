using NgtEditor.Services;
using NgtEditor.ViewModels;
using Splat;

namespace NgtEditor.DependencyInjection
{
    internal class ViewModelsBootstrapper
    {
        public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton(() => new MainWindowViewModel(resolver.GetRequiredService<IDialogService>()));
            services.Register(() => new NewProjectDialogViewModel());
        }
    }
}