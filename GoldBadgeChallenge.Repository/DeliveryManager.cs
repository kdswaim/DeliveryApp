using System;

    public class DeliveryManager
    {
        private IDeliveryRepository repository;
        public DeliveryManager(IDeliveryRepository repository)
        {
            this.repository = repository;
        }

        public Guid AddDelivery(DateTime deliveryDate)
        {
            var delivery = new Delivery {ID = Guid.NewGuid(), DeliveryDate = deliveryDate, OrderDate = DateTime.Now};
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
