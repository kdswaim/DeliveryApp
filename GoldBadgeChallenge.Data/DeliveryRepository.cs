using System;
using System.Collections.Generic;
using System.Linq;

    public class DeliveryRepository : IDeliveryRepository
    {
        private List<Delivery> deliveries = new List<Delivery>();
        public Delivery? GetDelivery(Guid id)
        {
            return deliveries.FirstOrDefault(d => d.ID == id);
        }
        public void AddDelivery(Delivery delivery)
        {
            deliveries.Add(delivery);
        }

        public List<Delivery> GetAllDeliveries()
        {
            return deliveries;
        }

        public void DeleteDelivery(Guid id)
        {
            var delivery = GetDelivery(id);
            if (delivery != null)
            {
                deliveries.Remove(delivery);
            }
        }
    }
