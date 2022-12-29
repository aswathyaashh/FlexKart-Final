
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.infrastructure.RepositoryLayer;
using E_Commerce.core.DomainLayer.Entities;

namespace TestProject_Ecommerce
{
    public class LoginTest
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        public void loginCheck(LoginModel login)
        {
            //loginCheck tp = new loginCheck();
            Assert.AreEqual("admin@gmail.com",login.EmailId);
            Assert.AreEqual("Admin123", login.Password);

        }
    }
}