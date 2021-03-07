using NgtEditor.Services;
using NgtEditor.Services.Impl;
using Splat;

namespace NgtEditor.DependencyInjection
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