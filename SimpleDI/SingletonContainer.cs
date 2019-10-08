using System;

namespace SimpleDI
{
    internal sealed class SingletonContainer<TService> : IInstance<TService> where TService : class
    {
        public SingletonContainer(Type serviceType, Type interfaceType = null)
        {
            ServiceType = serviceType;
            InterfaceType = interfaceType;
        }

        private static TService _instance;

        private static Func<TService> _instanceGenerationFunc;

        public Type InterfaceType { get; }
        public Type ServiceType { get; }

        public Func<object> InstanceGenerationFunc
        {
            get => _instanceGenerationFunc;
            set
            {
                if(_instanceGenerationFunc != null)
                    return;

                _instance = (TService)value.Invoke();
                _instanceGenerationFunc = () => _instance;
            }
        }

        public object GetInstance()
        {
            if(_instanceGenerationFunc == null)
                throw new Exception($"Can't resolve instance for type {ServiceType.Name}.");

            return _instance;
        }
    }
}
