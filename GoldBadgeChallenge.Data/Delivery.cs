    public class Delivery
    {
        public Delivery(Guid iD, DateTime orderDate, int quantity) 
        {
            this.ID = iD;
            this.OrderDate = orderDate;
            this.Quantity = quantity;
            this.CustomerId = CustomerId;

            this.DeliveryDate = DateTime.MinValue;
            this.OrderStatus = TaskStatus.Ordered;
   
        }

        public enum TaskStatus
        {
            Ordered,
            InProgress,
            InTransit,
            Delivered
        }

        public Guid ID {get; set;}
        public DateTime DeliveryDate {get;set;}

        public DateTime OrderDate {get; set;}

        public TaskStatus OrderStatus {get; set;}

        public int Quantity {get; set;}

        public int CustomerId {get; set;}
    }
