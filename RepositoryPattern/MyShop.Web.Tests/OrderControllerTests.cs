using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using MyShop.Web.Controllers;
using MyShop.Web.Models;

namespace MyShop.Web.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void CanCreateOrderWithCorrectModel()
        {
            var orderRepository = new Mock<IRepository<Order>>();
            var productRepository = new Mock<IRepository<Product>>();

            var orderController = new OrderController(
                orderRepository.Object,
                productRepository.Object
                );

            var createOrderModel = new CreateOrderModel
            {
                Customer = new CustomerModel
                {
                    Name = "Filip Ekberg",
                    ShippingAddress = "Test address",
                    City = "Gothenburg",
                    PostalCode = "445623",
                    Country = "Sweden"
                },
                LineItems = new[]
                {
                    new LineItemModel { ProductId = System.Guid.NewGuid(), Quantity = 2 },
                    new LineItemModel {ProductId = System.Guid.NewGuid(), Quantity = 12 }
                }
            };

            orderController.Create(createOrderModel);

            orderRepository.Verify(repository => repository.Add(It.IsAny<Order>()), Times.AtMostOnce());
        }
    }
}
