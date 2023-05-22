using System;
using System.Collections.Generic;
using System.Linq;

    public class DeliveryRepository : IDeliveryRepository
    {
        private List<Delivery> deliveries = new List<Delivery>();
        private Queue<Delivery> deliveryqueue = new Queue<Delivery>();

        //FIFO!
        private int _count = 0;
        public Delivery? GetDelivery(int id)
        {
            return deliveries.FirstOrDefault(d => d.ID == id);
        }
        public bool AddDelivery(Delivery delivery)
        {
          if (delivery is null) {
            return false;
          } else {
            delivery.ID = ++_count;
            deliveries.Add(delivery);
            deliveryqueue.Enqueue(delivery);
            return true;
          }
          
        }

        public List<Delivery> GetAllDeliveries()
        {
            return deliveries;
        }

        public bool DeleteDelivery(int id)
        {
            var delivery = GetDelivery(id);
          
            return deliveries.Remove(delivery);
        }

    public bool UpdateStatus(Delivery delivery, Delivery.TaskStatus status)
    {
        var oldDelivery = GetDelivery(delivery.ID);
        if (oldDelivery!=null) {
            oldDelivery.OrderStatus = status;
            return true;
        } else {
            return false;
        }
    }
}
