using NgtEditor.Services;
using NgtEditor.Services.Impl;
using Splat;

namespace NgtEditor.DependencyInjection
{
    public class ServicesBootstrapper
    {
        public static void RegisterServices(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton<ILangFileSearchService>(() => new LangFileSearchService());
        }
    }
}