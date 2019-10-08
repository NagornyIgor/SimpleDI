using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
