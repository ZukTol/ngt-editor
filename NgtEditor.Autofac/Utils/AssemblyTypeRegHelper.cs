using Autofac;
using Autofac.Core;
using NgtEditor.Autofac.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace NgtEditor.Autofac.Utils
{
    public class AssemblyTypeRegHelper
    {
        public static void Init(ContainerBuilder builder, string assemblyName)
        {
            var assembly = LoadAssembly(assemblyName);
            Init(builder, assembly);
        }

        public static void Init(ContainerBuilder builder, Assembly assembly)
        {
            InitServiceList(builder, assembly);
        }

        public static void InitAvalonia(ContainerBuilder builder, string assemblyName)
        {
            var assembly = LoadAssembly(assemblyName);
            InitAvalonia(builder, assembly);
        }

        public static void InitAvalonia(ContainerBuilder builder, Assembly assembly)
        {
            InitServiceList(builder, assembly);
            InitCommandList(builder, assembly);
            InitViewModelList(builder, assembly);
        }

        private static void InitServiceList(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith(Constants.Suffix.Service, StringComparison.OrdinalIgnoreCase) && t.GetInterfaces().Contains(typeof(ISingletonService)))
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivated(ProcessServiceActivated);

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith(Constants.Suffix.Service, StringComparison.OrdinalIgnoreCase) && !t.GetInterfaces().Contains(typeof(ISingletonService)))
                .AsImplementedInterfaces()
                .OnActivated(ProcessServiceActivated);
        }

        private static void ProcessServiceActivated(IActivatedEventArgs<object> e)
        {
            if (e.Instance.GetType().GetInterfaces().Contains(typeof(IInitializable)))
            {
                ((IInitializable)e.Instance).AfterInitialized();
            }
        }

        private static void InitCommandList(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith(Constants.Suffix.Command, StringComparison.OrdinalIgnoreCase))
                .AsSelf();
        }

        private static void InitViewModelList(ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith(Constants.Suffix.ViewModel, StringComparison.OrdinalIgnoreCase))
                .AsSelf()
                .PropertiesAutowired();
        }

        private static Assembly LoadAssembly(string assemblyName)
        {
            return Assembly.Load(assemblyName);
        }
    }
}