namespace CarFactory.Services
{
    public interface ICarService
    {
        string Name { get; set; }

        int Speed { get; set; }

        void StartEngine();

        void Brake();

        void Accelerate();

        string PartsDiagnostics();
    }
}
