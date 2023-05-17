using System;
using System.Collections.Generic;
    public interface IDeliveryRepository
    {
        Delivery GetDelivery(int id);
        bool AddDelivery(Delivery delivery);
        List<Delivery> GetAllDeliveries();
        bool DeleteDelivery(int id);
    }
