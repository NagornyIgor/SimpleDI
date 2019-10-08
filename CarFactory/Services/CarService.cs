using System;

namespace CarFactory.Services
{
    public class CarService : ICarService
    {

        private readonly IEngineService _engineService;
        private readonly IBrakeService _brakeService;
        private readonly IControls _controls;

        public CarService(IEngineService engineService, IBrakeService brakeService, IControls controls)
        {
            _engineService = engineService;
            _brakeService = brakeService;
            _controls = controls;

            Name = $"Car: {Guid.NewGuid().ToString()}";
        }

        public string Name { get; set; }

        public int Speed { get; set; }

        public void StartEngine()
        {
            _engineService.StartEngine();
        }

        public void Brake()
        {
            Speed = 0;
            _brakeService.Brake();
        }

        public void Accelerate()
        {
            Speed += 5;
            Console.WriteLine("Car accelerated");
        }

        public string PartsDiagnostics()
        {
            return $"{ _engineService.Name }, { _brakeService.Name }, { _controls.Name } Controls parts: { _controls.PartsDiagnostics() }";
        }
    }
}
