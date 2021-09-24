using Ninject;
using Ninject.Modules;
using System;
using System.Linq;

namespace BookStoreCommon
{
    public static class IoC
    {
        private static IKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static T Get<T>(string name)
        {
            return _kernel.Get<T>(name);
        }

        public static object Get(Type type)
        {
            return _kernel.Get(type);
        }

        public static void Initialize(StandardKernel kernel, params INinjectModule[] modules)
        {
            if (_kernel != null)
            {
                throw new Exception("IoC Kernel already initialized");
            }
            _kernel = kernel;
            if (modules != null && modules.Any())
            {
                kernel.Load(modules);
            }
        }
    }
}