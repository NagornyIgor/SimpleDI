using System;

namespace CarFactory.Services
{
    public class Controls : IControls
    {
        private readonly ISteeringWheel _steeringWheel;
        private readonly Pedals _pedals;

        public Controls(ISteeringWheel steeringWheel, Pedals pedals)
        {
            _steeringWheel = steeringWheel;
            _pedals = pedals;

            Name = $"Controls: {Guid.NewGuid().ToString()}";
        }

        public string Name { get; set; }

        public string PartsDiagnostics()
        {
            return $"{_steeringWheel.Name}, {_pedals.Name}";
        }
    }
}
