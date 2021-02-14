using ngt_editor.Services;
using ngt_editor.ViewModels;
using Splat;

namespace ngt_editor.DependencyInjection
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