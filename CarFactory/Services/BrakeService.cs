using System;

namespace CarFactory.Services
{
    public class BrakeService : IBrakeService
    {
        public BrakeService()
        {
            Name = $"Brake: {Guid.NewGuid().ToString()}";
        }

        public string Name { get; set; }

        public void Brake()
        {
            Console.WriteLine("We slowed down");
        }
    }
}
