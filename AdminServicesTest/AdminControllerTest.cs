using AdminService.Controllers;
using AdminService.DTOS;
using AdminService.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using AdminService.Models;
using Castle.Core.Resource;

namespace AdminServicesTest
{
    [TestFixture]
    public class AdminControllerTest
    {
        AdminController ac;
        [SetUp]
        public void Initialise()
        {

        }
        [Test]
        public void TestValidatePositive()
        {
            var mock = new Mock<IAdminService>();
            AdminLoginDTO a = new AdminLoginDTO { Email = "Gaurab@gmail.com", Password = "pass@123" };
            ac= new AdminController(mock.Object, null);
            mock.Setup(c => c.ValidateUser(It.IsAny<AdminLoginDTO>())).Returns(true);
            Assert.IsAssignableFrom<TokenResult>(ac.Validate(a));

        }
        [Test]
        public void TestVAlidatenegetive()
        {
            var mock=new Mock<IAdminService>();
            AdminLoginDTO a = new AdminLoginDTO { Email = "Gaurab@gmail.com", Password = "pass@123" };
            ac = new AdminController(mock.Object, null);
            mock.Setup(c => c.ValidateUser(It.IsAny<AdminLoginDTO>())).Returns(false);
            var result=ac.Validate(a);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);



        }
        [Test]
        public void TestPostPositive()
        {
            Admin c = new Admin() { Email = "anil@gmail.com", Name = "anil", PhoneNumber = "1234567890" ,password = "pass@123" };
            var mock = new Mock<IAdminService>();
            mock.Setup(m => m.CreateAdmin(It.IsAny<Admin>())).Returns(Task.FromResult(true));
            ac = new AdminController(mock.Object, null);
            Assert.IsAssignableFrom<OkObjectResult>(ac.Post(c));

        }
        [Test]
        public void TestPostNegative()
        {
            Admin c = new Admin() { Email = "anil@gmail.com", Name = "anil", PhoneNumber = "1234567890", password = "pass@123" }; // Provide valid Admin data
            var mock = new Mock<IAdminService>(); 
            ac = new AdminController(mock.Object, null);
            mock.Setup(m => m.CreateAdmin(It.IsAny<Admin>())).Returns(Task.FromResult(false));
            var result = ac.Post(c); 
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

    }
}