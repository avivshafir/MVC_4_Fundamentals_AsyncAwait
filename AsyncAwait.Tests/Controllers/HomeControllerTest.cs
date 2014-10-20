using System.Threading.Tasks;
using System.Web.Mvc;
using AsyncAwait.Controllers;
using AsyncAwait.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncAwait.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task Index_Produces_Model()
        {
            var controller = new HomeController();
            var result = (ViewResult)await controller.Index();
            var model = result.Model;
            
            Assert.IsNotNull(model as HomePageViewModel);
        }
    }
}


