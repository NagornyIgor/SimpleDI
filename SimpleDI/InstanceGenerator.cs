using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDI
{
    public static class InstanceGenerator
    {
        private static readonly List<IInstance> Instances = new List<IInstance>();

        public static void RegisterSingleton<TInterface, TService>() where TService : class, TInterface
        {
            Register<TInterface, TService>(InstanceType.Singleton);
        }

        public static void RegisterSingleton<TService>() where TService : class
        {
            Register<TService>(InstanceType.Singleton);
        }

        public static void RegisterRenew<TInterface, TService>() where TService : class, TInterface
        {
            Register<TInterface, TService>(InstanceType.Renew);
        }

        public static void RegisterRenew<TService>() where TService : class
        {
            Register<TService>(InstanceType.Renew);
        }

        public static T GetInstance<T>()
        {
            var searchedType = typeof(T);
            var instances = Instances.Where(i => FindInstance(i, searchedType)).ToArray();

            if(instances.Length > 1)
                throw new Exception($"There are several instances of the same interface {typeof(T)}");

            var instance = instances.First();

            if (instance.InstanceGenerationFunc == null)
                instance.GenerateInstanceCreationFunction();

            return (T)instance.GetInstance();
        }

        private static void GenerateInstanceCreationFunction(this IInstance service)
        {
            if (service.InstanceGenerationFunc != null)
                return;

            var constructors = service.ServiceType.GetConstructors();

            if (constructors.Length != 1)
            {
                throw new Exception("Class instance can't have more then one constructor");
            }

            var constructor = constructors.First();

            var constructorParams = constructor.GetParameters();

            Func<object> generatedFunc;

            if (!constructorParams.Any())
            {
                generatedFunc = () => Activator.CreateInstance(service.ServiceType);
            }
            else
            {
                var paramsFunctions = new List<Func<object>>();

                foreach (var param in constructorParams)
                {
                    var paramType = param.ParameterType;

                    var instance = Instances.FirstOrDefault(i => FindInstance(i, paramType));

                    if (instance == null)
                        throw new Exception($"Can't find registered instance for type {paramType}");

                    instance.GenerateInstanceCreationFunction();

                    paramsFunctions.Add(instance.InstanceGenerationFunc);
                }

                generatedFunc = () =>
                {
                    var args = paramsFunctions.Select(f => f.Invoke()).ToArray();
                    return Activator.CreateInstance(service.ServiceType, args);
                };
            }

            service.InstanceGenerationFunc = generatedFunc;
        }

        private static void Register<TService>(InstanceType instanceType) where TService : class
        {
            var serviceType = typeof(TService);

            if (Instances.Any(i => i.InterfaceType == null && i.ServiceType == serviceType))
                throw new Exception($"{serviceType.Name} already registered.");

            switch (instanceType)
            {
                case InstanceType.Singleton:
                    Instances.Add(new SingletonContainer<TService>(serviceType));
                    break;
                case InstanceType.Renew:
                    Instances.Add(new RenewContainer<TService>(serviceType));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(instanceType), instanceType, null);
            }
        }

        private static void Register<TInterface, TService>(InstanceType instanceType) where TService : class, TInterface
        {
            var interfaceType = typeof(TInterface);
            var serviceType = typeof(TService);

            if (serviceType.IsAssignableFrom(interfaceType))
                throw new Exception($"You can't assign {interfaceType.Name} from {serviceType.Name}");

            if (Instances.Any(i => i.InterfaceType == interfaceType))
                throw new Exception($"{interfaceType.Name} already registered.");

            switch (instanceType)
            {
                case InstanceType.Singleton:
                    Instances.Add(new SingletonContainer<TService>(serviceType, interfaceType));
                    break;
                case InstanceType.Renew:
                    Instances.Add(new RenewContainer<TService>(serviceType, interfaceType));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(instanceType), instanceType, null);
            }
        }

        private static bool FindInstance(IInstance instance, Type searchedType)
        {
            if (searchedType.IsInterface)
                return instance.InterfaceType == searchedType;

            return instance.InterfaceType == null && instance.ServiceType == searchedType;
        }
    }
}