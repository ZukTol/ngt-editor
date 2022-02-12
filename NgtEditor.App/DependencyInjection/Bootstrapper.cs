using Autofac;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using NgtEditor.Autofac.Utils;
using ReactiveUI;
using Splat;
using Splat.Autofac;
using System.Reflection;

namespace NgtEditor.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void RegisterWithAutofac()
        {
            // Build a new Autofac container.
            var builder = new ContainerBuilder();
            RegisterAssemblies(builder);

            // Use Autofac for ReactiveUI dependency resolution.
            // After we call the method below, Locator.Current and
            // Locator.CurrentMutable start using Autofac locator.
            var autofacResolver = builder.UseAutofacDependencyResolver();

            // Register the resolver in Autofac so it can be later resolved
            builder.RegisterInstance(autofacResolver);

            // Initialize ReactiveUI components
            autofacResolver.InitializeReactiveUI();
            autofacResolver.InitializeSplat();
            autofacResolver.InitializeAvalonia();

            //Locator.CurrentMutable.InitializeSplat();
            //Locator.CurrentMutable.InitializeReactiveUI();

            var container = builder.Build();

            // If you need to override any service (such as the ViewLocator), register it after InitializeReactiveUI
            // https://autofaccn.readthedocs.io/en/latest/register/registration.html#default-registrations
            // builder.RegisterType<MyCustomViewLocator>().As<IViewLocator>().SingleInstance();

            autofacResolver = container.Resolve<AutofacDependencyResolver>();

            // Set a lifetime scope (either the root or any of the child ones) to Autofac resolver
            // This is needed, because the previous steps did not Update the ContainerBuilder since they became immutable in Autofac 5+
            // https://github.com/autofac/Autofac/issues/811
            autofacResolver.SetLifetimeScope(container);
        }

        private static void RegisterAssemblies(ContainerBuilder builder)
        {
            AssemblyTypeRegHelper.InitAvalonia(builder, Avalonia.Constants.Assembly.NgtEditor);
            AssemblyTypeRegHelper.InitAvalonia(builder, Assembly.GetExecutingAssembly());
        }

        private static void InitializeAvalonia(this IMutableDependencyResolver resolver)
        {
            resolver.RegisterConstant(new AvaloniaActivationForViewFetcher(), typeof(IActivationForViewFetcher));
            resolver.RegisterConstant(new AutoDataTemplateBindingHook(), typeof(IPropertyBindingHook));
            RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;
        }
    }
}