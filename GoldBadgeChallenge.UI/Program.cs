using System;

class Program
{
    static void Main()
    {
        var DeliveryRepository = new DeliveryRepository();
        var deliveryManager = new DeliveryManager(DeliveryRepository);

        while (true) //main loop
        {
            System.Console.WriteLine("\n1. Add delivery");
            System.Console.WriteLine("2. View all deliveries");
            System.Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    System.Console.WriteLine("Enter delivery date (yyyy-mm-dd): ");
                    var dateInput = Console.ReadLine();
                    if(DateTime.TryParse(dateInput, out DateTime deliveryDate))
                    {
                        deliveryManager.AddDelivery(deliveryDate);
                        System.Console.WriteLine("Delivery added successfully!");
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid date format. Please try again.");
                    }
                    break;
                case "2":
                var allDeliveries = deliveryManager.GetAllDeliveries();
                System.Console.WriteLine("All deliveries:");
                foreach (var delivery in allDeliveries)
                {
                    System.Console.WriteLine($"Delivery ID: {delivery.ID}, Date: {delivery.DeliveryDate}");
                }
                break;
                case "3":
                    return; //exits program
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
