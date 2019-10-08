namespace CarFactory.Services
{
    public interface IBrakeService
    {
        string Name { get; set; }

        void Brake();
    }
}
