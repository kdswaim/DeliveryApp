using System;
using System.Collections.Generic;
using System.Linq;

    public class DeliveryManager
    {
        private IDeliveryRepository repository;
        private int _count = 0;
        public DeliveryManager(IDeliveryRepository repository)
        {
            this.repository = repository;
        }

        public int AddDelivery(DateTime deliveryDate, int quantity = 1)
        {
            var delivery = new Delivery (quantity);
            _count++;
            delivery.ID = _count;
            repository.AddDelivery(delivery);
            return delivery.ID;
        }

        public Delivery GetDelivery(int id)
        {
            return repository.GetDelivery(id);
        }

    public List<Delivery> GetPastDeliveries()
        {
            return repository.GetAllDeliveries().Where(d => d.DeliveryDate.Date < DateTime.Now.Date).OrderBy(d => d.DeliveryDate).ToList();
        }
        
        // public void ShowOrderStatus()
        // {
        //     return Delivery.TaskStatus;
        // }
    }
