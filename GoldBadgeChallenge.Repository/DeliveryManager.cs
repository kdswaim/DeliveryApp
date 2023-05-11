using System;
using System.Collections.Generic;
using System.Linq;

    public class DeliveryManager
    {
        private IDeliveryRepository repository;
        public DeliveryManager(IDeliveryRepository repository)
        {
            this.repository = repository;
        }

        public Guid AddDelivery(DateTime deliveryDate, int quantity = 1)
        {
            var delivery = new Delivery (Guid.NewGuid(), DateTime.Now, quantity) {DeliveryDate = deliveryDate};
            repository.AddDelivery(delivery);
            return delivery.ID;
        }

        public Delivery GetDelivery(Guid id)
        {
            return repository.GetDelivery(id);
        }

        public List<Delivery> GetPastDeliveries()
        {
            return repository.GetAllDeliveries().Where(d => d.DeliveryDate.Date < DateTime.Now.Date).OrderBy(d => d.DeliveryDate).ToList();
        }
    }
