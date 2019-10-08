using System;
using SimpleDI;
using CarFactory.Services;

namespace CarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceGenerator.RegisterSingleton<BrakeService>();
            InstanceGenerator.RegisterRenew<IBrakeService, BrakeService>();
            InstanceGenerator.RegisterRenew<IEngineService, EngineService>();
            InstanceGenerator.RegisterRenew<ICarService, CarService>();
            InstanceGenerator.RegisterRenew<IControls, Controls>();
            InstanceGenerator.RegisterRenew<ISteeringWheel, SteeringWheel>();
            InstanceGenerator.RegisterRenew<Pedals>();

            var car = InstanceGenerator.GetInstance<ICarService>();
            var brakes = InstanceGenerator.GetInstance<IBrakeService>();
            var engine = InstanceGenerator.GetInstance<IEngineService>();
            var steeringWheel = InstanceGenerator.GetInstance<ISteeringWheel>();
            var controls = InstanceGenerator.GetInstance<IControls>();
            var pedals = InstanceGenerator.GetInstance<Pedals>();

            var car1 = InstanceGenerator.GetInstance<ICarService>();
            var brakes1 = InstanceGenerator.GetInstance<IBrakeService>();
            var engine1 = InstanceGenerator.GetInstance<IEngineService>();
            var steeringWheel1 = InstanceGenerator.GetInstance<ISteeringWheel>();
            var controls1 = InstanceGenerator.GetInstance<IControls>();
            var pedals1 = InstanceGenerator.GetInstance<Pedals>();

            var car2 = InstanceGenerator.GetInstance<ICarService>();
            var brakes2 = InstanceGenerator.GetInstance<IBrakeService>();
            var engine2 = InstanceGenerator.GetInstance<IEngineService>();
            var steeringWheel2 = InstanceGenerator.GetInstance<ISteeringWheel>();
            var controls2 = InstanceGenerator.GetInstance<IControls>();
            var pedals2 = InstanceGenerator.GetInstance<Pedals>();
            
            var brakeService = InstanceGenerator.GetInstance<BrakeService>();
            var brakeService1 = InstanceGenerator.GetInstance<BrakeService>();
            var brakeService2 = InstanceGenerator.GetInstance<BrakeService>();

            Console.WriteLine("Cars");
            Console.WriteLine($"{car.Name}, {car1.Name}, {car2.Name}");
            Console.WriteLine(CompareStrings(car.Name, car1.Name, car2.Name));
            Console.WriteLine();

            Console.WriteLine("Car parts:");
            Console.WriteLine(car.PartsDiagnostics());
            Console.WriteLine(car1.PartsDiagnostics());
            Console.WriteLine(car2.PartsDiagnostics());
            Console.WriteLine();

            Console.WriteLine("Brakes");
            Console.WriteLine($"{brakes.Name}, {brakes1.Name}, {brakes2.Name}");
            Console.WriteLine(CompareStrings(brakes.Name, brakes1.Name, brakes2.Name));
            Console.WriteLine();

            Console.WriteLine("Engines");
            Console.WriteLine($"{engine.Name}, {engine1.Name}, {engine2.Name}");
            Console.WriteLine(CompareStrings(engine.Name, engine1.Name, engine2.Name));
            Console.WriteLine();

            Console.WriteLine("Controls");
            Console.WriteLine($"{controls.Name}, {controls1.Name}, {controls2.Name}");
            Console.WriteLine(CompareStrings(controls.Name, controls1.Name, controls2.Name));
            Console.WriteLine();

            Console.WriteLine("SteeringWheels");
            Console.WriteLine($"{steeringWheel.Name}, {steeringWheel1.Name}, {steeringWheel2.Name}");
            Console.WriteLine(CompareStrings(steeringWheel.Name, steeringWheel1.Name, steeringWheel2.Name));
            Console.WriteLine();

            Console.WriteLine("Pedals");
            Console.WriteLine($"{pedals.Name}, {pedals1.Name}, {pedals2.Name}");
            Console.WriteLine(CompareStrings(pedals.Name, pedals1.Name, pedals2.Name));
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("BrakeServices");
            Console.WriteLine($"{brakeService.Name}, {brakeService1.Name}, {brakeService2.Name}");
            Console.WriteLine(CompareStrings(brakeService.Name, brakeService1.Name, brakeService2.Name));

            Console.ReadLine();
        }

        static bool CompareStrings(params string[] args)
        {
            var elementsCount = args.Length;
            var result = true;

            for (var i = 0; i < elementsCount; i++)
            {
                for (var y = 0; y < elementsCount; y++)
                {
                    result = args[i] == args[y];

                    if (!result)
                        return result;
                }
            }

            return result;
        }
    }
}
