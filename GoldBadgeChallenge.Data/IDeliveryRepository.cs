using System;
using System.Collections.Generic;
    public interface IDeliveryRepository
    {
        Delivery GetDelivery(Guid id);
        void AddDelivery(Delivery delivery);
        List<Delivery> GetAllDeliveries();
        void DeleteDelivery(Guid id);
    }
