using ngt_editor.Services;
using ngt_editor.Services.Impl;
using Splat;

namespace ngt_editor.DependencyInjection
{
    internal class ServicesBootstrapper
    {
        public static void RegisterServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton<IMainWindowProviderService>(() => new MainWindowProviderService());
            services.RegisterLazySingleton<IDialogService>(() => new DialogService(resolver.GetRequiredService<IMainWindowProviderService>()));
        }
    }
}