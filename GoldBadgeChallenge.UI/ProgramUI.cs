using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramUI
    {
        private DeliveryRepository _deliveryRepo;

        private DeliveryManager _deliveryManager;
        private Queue<Delivery> _deliveryQueue;

        public ProgramUI()
        {
            _deliveryRepo = new DeliveryRepository();
            _deliveryManager = new DeliveryManager(_deliveryRepo);
            _deliveryQueue = new Queue<Delivery>();
        }

        public void Run()
        {
            RunApplication();
        }
        
        private void RunApplication()
        {
            bool isRunning = true;

        while (isRunning) //main loop
        {
            Console.Clear();
            System.Console.WriteLine("\n1. Add delivery\n"+
                                    "2. View all deliveries\n"+
                                    "3. Update delivery status\n"+
                                    "4. Cancel Delivery\n"+
                                    "5. Process next order\n"+
                                    "6. Exit");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddDelivery();
                    break;
                case "2":
                    ViewAllDeliveries();
                    break;
                case "3":
                    UpdateDelivery();
                    break;
                case "4":
                    CancelDelivery();
                    break;
                case "5":
                    GetNextOrder();
                    break;
                case "6":
                return; //exits program
                default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
            }
        }
    }

    private void CancelDelivery()
    {
        Console.Clear();
        


        System.Console.WriteLine("Delete delivery\n");
        System.Console.WriteLine("Enter delivery ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        bool success = _deliveryRepo.DeleteDelivery(id);
        if (success)
        {
            System.Console.WriteLine("Order deleted successfully");
        }
        else
        {
            System.Console.WriteLine($"Could not find delivery with id {id}");
        }




        PressAnyKey();
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void GetNextOrder()
    {
        if (_deliveryQueue.Count > 0)
        {
            Delivery nextDelivery = _deliveryQueue.Dequeue();
            Console.WriteLine($"Processing next delivery with Id: {nextDelivery.ID}");
        }
        else
        {
            System.Console.WriteLine("No deliveries in queue.");
        }
        PressAnyKey();
    }

    private void UpdateDelivery()
    {
        Console.Clear();
        System.Console.WriteLine("Enter the ID of the delivery you wish to update:");
        int id = int.Parse(Console.ReadLine());

        Delivery delivery = _deliveryRepo.GetDelivery(id)!;
        if (delivery == null)
        {
            System.Console.WriteLine("Delivery not found.");
            PressAnyKey();
            return;
        }
        /*
         Ordered,
            InProgress,
            InTransit,
            Delivered
        */
        System.Console.WriteLine("Please make a selection.\n"+ 
        "0. Ordered \n" +
        "1. In Progress \n" +
        "2. In Transit \n" +
        "3. Delivered\n");

        var userInput =(Delivery.TaskStatus)int.Parse(Console.ReadLine()!);
        delivery.OrderStatus = userInput;
        if (_deliveryRepo.UpdateStatus(delivery))
        {
            System.Console.WriteLine("Success!");
        } else {
            System.Console.WriteLine("Failed to update delivery status.");
        }
    }

    private void ViewAllDeliveries()
    {
        Console.Clear();
        var pastDeliveries =_deliveryRepo.GetAllDeliveries();
                System.Console.WriteLine("Past deliveries:");
                foreach (var delivery in pastDeliveries)
                {
                    System.Console.WriteLine($"Delivery ID: {delivery.ID}, Deliver Date: {delivery.DeliveryDate}, Order Date: {delivery.OrderDate}, Status: {delivery.OrderStatus}, Customer ID: {delivery.CustomerId}");
                }
                PressAnyKey();
    }

    private void AddDelivery()
    {
        Console.Clear();
        Delivery deliveryForm = new Delivery();
        System.Console.WriteLine("Enter an item amount: ");
                    var itemAmount = int.Parse((Console.ReadLine()));
                    deliveryForm.Quantity = itemAmount;

                    System.Console.WriteLine("Enter customer ID: ");
                    var customerId = int.Parse((Console.ReadLine()));

                    if (customerId != null)
                    {
                        deliveryForm.CustomerId = customerId;
                    }

                    if (_deliveryRepo.AddDelivery(deliveryForm))
                    {
                        _deliveryQueue.Enqueue(deliveryForm);
                        System.Console.WriteLine("Success!");
                    }
                    else
                    {
                        System.Console.WriteLine("Failed to add delivery.");
                    }
                    PressAnyKey();
    }
}