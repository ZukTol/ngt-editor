using Avalonia;
using Avalonia.ReactiveUI;
using System;
using NgtEditor.DependencyInjection;
using Splat;

namespace NgtEditor
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            RegisterDependencies();
            //SubscribeToDomainUnhandledEvents();

            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();

        private static void RegisterDependencies() =>
            Bootstrapper.Register(Locator.CurrentMutable, Locator.Current);

        //private static void SubscribeToDomainUnhandledEvents() =>
        //    AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        //    {
        //        var logger = Locator.Current.GetRequiredService<ILogger>();
        //        var ex = (Exception)args.ExceptionObject;

        //        logger.LogCritical($"Unhandled application error: {ex}");
        //    };
    }
}