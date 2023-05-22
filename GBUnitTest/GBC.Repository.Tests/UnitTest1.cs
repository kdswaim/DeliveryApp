using Xunit;

namespace GBC.Repository.Tests
{
    public class DeliveryRepositoryTest
    {
        private DeliveryRepository _repository;
        public DeliveryRepositoryTest()
        {
            _repository = new DeliveryRepository();

            Delivery del1 = new Delivery(1, 2);
            Delivery del2 = new Delivery(5, 2);
            Delivery del3 = new Delivery(10);

            _repository.AddDelivery(del1);
            _repository.AddDelivery(del2);
            _repository.AddDelivery(del3);

        }
        [Fact]
        public void CanAddDelivery_ShouldReturnTrue()
        {
            //Arrange
            var deliveryA = new Delivery(1, 2);

            //Act
            bool isSuccessful = _repository.AddDelivery(deliveryA);

            //Assert
            Assert.True(isSuccessful);
        }       
        
        [Fact]
        public void CanGetAllDeliveries_ShouldReturnCorrectCount()
        {
            //Arrange
            

            //Act
            int expectedCount = 3;
            int actualCount = _repository.GetAllDeliveries().Count;

            //Assert
            Assert.Equal(expectedCount, actualCount);
            
        }

        [Fact]
        public void CanUpdateDeliveryStatus()
        {
            //Arrange
            var delivery = _repository.GetAllDeliveries().FirstOrDefault();
            var deliveryId = delivery.ID;

            var deliveryStatus = Delivery.TaskStatus.InTransit;
            //Act
            _repository.UpdateStatus(delivery, deliveryStatus);
            var updatedDelivery = _repository.GetDelivery(deliveryId);
            //Assert
            Assert.Equal(Delivery.TaskStatus.InTransit, updatedDelivery.OrderStatus);
        }

        [Fact]
        public void CanCancelDelivery()
        {



        }

        [Fact]
        public void CanGetNextOrder()
        {

        }


    }
}
