using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonWay.Controllers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using NSubstitute;
using System.IO;
using System.Text;

namespace LemonWay.Tests.Controllers
{
    [TestClass]
    public class MathControllerTestcs
    {

        [TestMethod]
        public void TestFibo()
        {
            //Arrange
            string res = "";
            MathController ctrl = new MathController();
            ctrl.Request = new HttpRequestMessage();
            ctrl.Configuration = new HttpConfiguration();
            //Act
            HttpResponseMessage httpResponseMessage = ctrl.Fibonacci(10);
            httpResponseMessage.TryGetContentValue<string>(out res);
            //Assert
            Assert.AreEqual("55", res);
        }
    }
}
