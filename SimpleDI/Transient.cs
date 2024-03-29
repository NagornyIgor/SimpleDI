﻿using System;

namespace SimpleDI
{
    internal sealed class TransientContainer<TService> : IInstance<TService> where TService : class
    {
        public TransientContainer(Type serviceType, Type interfaceType = null)
        {
            ServiceType = serviceType;
            InterfaceType = interfaceType;
        }

        private static Func<object> _instanceGenerationFunc;

        public Type InterfaceType { get; }
        public Type ServiceType { get; }

        public Func<object> InstanceGenerationFunc
        {
            get => _instanceGenerationFunc;
            set
            {
                if (_instanceGenerationFunc != null)
                    return;

                _instanceGenerationFunc = value;
            }
        }

        public object GetInstance()
        {
            if (_instanceGenerationFunc == null)
                throw new Exception($"Can't resolve instance for type {ServiceType.Name}.");

            return (TService)_instanceGenerationFunc.Invoke();
        }
    }
}

