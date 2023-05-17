    public class Delivery
    {
        public Delivery()
        {
            
        }
        public Delivery(int quantity, int customerId = 1) 
        {
            this.Quantity = quantity;
            this.CustomerId = customerId;
            this.OrderStatus = TaskStatus.Ordered;
        }

        public enum TaskStatus
        {
            Ordered,
            InProgress,
            InTransit,
            Delivered
        } //Nesting together is questionable

        public int ID {get; set;}
        public DateTime DeliveryDate
        {
            get 
            {
               return OrderDate.AddDays(7);
            }
            set 
            {
                value = OverrideDeliveryDate();
            }
        }
        public DateTime OrderDate {get; set;} = DateTime.Now;

        public TaskStatus OrderStatus {get; set;}

        public int Quantity {get; set;}

        public int CustomerId {get; set;}

        private DateTime OverrideDeliveryDate(int modDays = 3) 
        {
            return OrderDate.AddDays(modDays);
        }
    }
