using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//instalamos el paquete nuget Microsoft.AspNetCore.Mvc.Core, para pdoer hacer uso
//de los métodos que se devuelven en los controladores: Ok() NotFound() etc etc.
namespace Lil.Customers.Tests
{
    [TestClass]
    public class CustomersTests
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            var customersProvider = new CustomersProvider();
            var customerController = new CustomersController(customersProvider);

            var result = customerController.Get("1").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]//siempre es bueno probar un escenario negativo y positivo
        public void GetAsyncReturnsNotFound()
        {
            var customersProvider = new CustomersProvider();
            var customerController = new CustomersController(customersProvider);

            var result = customerController.Get("99").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
