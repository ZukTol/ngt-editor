using ngt_editor.ViewModels;
using Splat;

namespace ngt_editor.DependencyInjection
{
    public class ViewModelsBootstrapper
    {
        public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton(() => new MainWindowViewModel());
        }
    }
}