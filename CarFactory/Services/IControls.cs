namespace CarFactory.Services
{
    public interface IControls
    {
        string Name { get; set; }

        string PartsDiagnostics();
    }
}
