using Castle.Core.Resource;
using DishService.Controllers;
using DishService.Models;
using DishService.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DishServiceTest
{
    public class DishServiceTest
    {
        DishController cu;
        [SetUp]
        public void Initialise()
        {
        }
        [Test]
        public void TestRegisterPositive()
        {
            Dish c = new Dish() { Code="Coder",DishName="Periperi Burger",Category="Non-Veg",RestaurentName="FoodBites By Empire",Price="335",DishImage="chiuhi",AvaliableTime="12:50",Description="Khaka batata hoon",IsDisable="huifhir"};
            var mock = new Mock<IDishServices>();
            mock.Setup(m => m.CreateDish(It.IsAny<Dish>())).Returns(true);
            cu = new DishController(mock.Object);
            Assert.IsAssignableFrom<OkObjectResult>(cu.Post(c));
        }
        [Test]
        public void TestRegisterCustomerNull()
        {
            var mock = new Mock<IDishServices>();
            // mock.Setup(m => m.RegisterCustomer(It.IsAny<Customer>())).Returns(true);
            cu = new DishController(mock.Object);
            Assert.IsAssignableFrom<BadRequestObjectResult>(cu.Post(null));
        }


    }
}