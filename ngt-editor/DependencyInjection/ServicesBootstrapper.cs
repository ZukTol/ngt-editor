using NgtEditor.Services;
using NgtEditor.Services.Impl;
using NgtEditor.Splat.Extension;
using Splat;

namespace NgtEditor.Avalonia.DependencyInjection
{
    internal class ServicesBootstrapper
    {
        public static void RegisterServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton<IMainWindowProviderService>(() => new MainWindowProviderService());
            services.RegisterLazySingleton<IDialogService>(() => new DialogService(resolver.GetRequiredService<IMainWindowProviderService>()));
            services.RegisterLazySingleton<ISystemDialogService>(() => new SystemDialogService(resolver.GetRequiredService<IMainWindowProviderService>()));
        }
    }
}