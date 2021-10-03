using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommunalApp_Winforms.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunalApp_Winforms.Model;

namespace CommunalApp_Winforms.Controller.Tests
{
    [TestClass()]
    public class GasControllerTests
    {
        [TestMethod()]
        public void GasControllerTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var price = 5.0;
            var volume = 100.0;
            var fromDate = DateTime.Parse("2021.09.01");
            var toDate = DateTime.Parse("2021.10.01");
            var gasController = new GasController();
            var gas = new Gas(price, volume, fromDate, toDate);
            // Act
            gasController.Add(gas);
            // Assert
            Assert.AreEqual(gas.ToDate, gasController.GasList.First().ToDate);
        }

        [TestMethod()]
        public void GetGasInfoTest()
        {
            //Arrange
            var price1 = 5.45;
            var volume1 = 100.0;
            var fromDate1 = DateTime.Parse("2021.02.01");
            var toDate1 = DateTime.Parse("2021.03.01");
            var gasController1 = new GasController();
            var gas1 = new Gas(price1, volume1, fromDate1, toDate1);

            // Act
            gasController1.Add(gas1);
            var getGasInfo = gasController1.GetGasInfo(fromDate1, toDate1);
            // Assert
            Assert.AreEqual(gas1.FromDate, getGasInfo.FromDate);
            Assert.AreEqual(gas1.ToDate, getGasInfo.ToDate);
        }
    }
}