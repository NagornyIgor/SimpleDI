using System;

namespace CarFactory.Services
{
    public class SteeringWheel : ISteeringWheel
    {
        public SteeringWheel()
        {
            Name = $"SteeringWheel: {Guid.NewGuid().ToString()}";
        }

        public string Name { get; set; }
    }
}
