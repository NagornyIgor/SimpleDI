using System;

namespace CarFactory.Services
{
    public class Pedals
    {
        public Pedals()
        {
            Name = $"Pedals: {Guid.NewGuid().ToString()}";
        }

        public string Name { get; set; }
    }
}
