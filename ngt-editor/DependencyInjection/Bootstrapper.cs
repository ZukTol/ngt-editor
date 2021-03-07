using Splat;

namespace NgtEditor.DependencyInjection
{
    public class Bootstrapper
    {
        public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            ServicesBootstrapper.RegisterServices(services, resolver);
            ViewModelsBootstrapper.RegisterViewModels(services, resolver);
        }
    }
}