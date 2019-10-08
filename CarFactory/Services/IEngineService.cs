namespace CarFactory.Services
{
    public interface IEngineService
    {
        string Name { get; set; }

        void StartEngine();
    }
}
