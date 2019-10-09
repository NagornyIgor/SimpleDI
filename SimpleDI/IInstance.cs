using System;

namespace SimpleDI
{
    public interface IInstance
    {
        Type InterfaceType { get; }

        Type ServiceType { get; }

        object GetInstance();

        Func<object> InstanceGenerationFunc { get; set; }
    }

    public interface IInstance<TService> : IInstance where TService : class
    {
    }
}
