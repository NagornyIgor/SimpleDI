using System;

namespace CarFactory.Services
{
    public class EngineService : IEngineService
    {
        public EngineService()
        {
            Name = $"Engine: {Guid.NewGuid().ToString()}";
        }

        public string Name { get; set; }

        public void StartEngine()
        {
            Console.WriteLine("Engine started!");
        }
    }
}
