public class Program
{
    public static void Main(string[] args)
    {
        IDeliveryRepository repository = new DeliveryRepository();
        ProgramUI ui = new ProgramUI(repository);
        ui.Run();
    }
}