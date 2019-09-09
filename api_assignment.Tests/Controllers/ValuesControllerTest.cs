using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using api_assignment;
using api_assignment.Controllers;

namespace api_assignment.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ManagersController controller = new ManagersController();

            // Act
            object result = controller.Get();

            // Assert
            
            Assert.AreEqual(result,result);
           
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ManagersController controller = new ManagersController();
            
            // Act
            ManagersController.Manager result = controller.Get(5);

            // Assert
            Assert.AreEqual(result, result);
        }

        

        
    }
}
