using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicCodeCalculator;
using ElectronicCodeCalculator.Controllers;
using NSubstitute;
using ElectronicCodeCalculator.Core.Interfaces;
using ElectronicCodeCalculator.Core.Models;
using ElectronicCodeCalculator.Core.Constants;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace ElectronicCodeCalculator.Tests.Controllers
{
    [TestClass]
    public class ResistorControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            var objResistanceCalculator = Substitute.For<IResistanceCalculator>();
            ResistorController objResistorController = new ResistorController(objResistanceCalculator);

            // Act
            ViewResult result = objResistorController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestNullInputResistor()
        {
            // Arrange
            var objResistanceCalculator = Substitute.For<IResistanceCalculator>();
            ResistorController objResistorController = new ResistorController(objResistanceCalculator);
            Resistor objResistor = new Resistor();

            // Act
           ActionResult result = objResistorController.CalculateOhmValue(objResistor);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestReceivedAllInput()
        {
            // Arrange
            var objResistanceCalculator = Substitute.For<IResistanceCalculator>();           
            ResistorController objResistorController = new ResistorController(objResistanceCalculator);
            Resistor objResistor = new Resistor("orange", "yellow", "white", "silver");
         
            //Resistance objExpectedResult = new Resistance("30,600M", "34,000M", "37,400M");

            // Act
            objResistorController.CalculateOhmValue(objResistor);


            //Assert
            //Received call with these args "orange", "yellow", "white", "silver".
            //So, the inputs are correctly passed on to the Business Layer.
            objResistanceCalculator.Received().CalculateOhmValue("orange", "yellow", "white", "silver");    
        }

        [TestMethod]
        public void TestDidNotReceiveAllInput()
        {
            // Arrange
            var objResistanceCalculator = Substitute.For<IResistanceCalculator>();
            ResistorController objResistorController = new ResistorController(objResistanceCalculator);
            Resistor objResistor = new Resistor("orange", "yellow", "white", "silver");           

            // Act
            objResistorController.CalculateOhmValue(objResistor);

            //Assert
            //Received call with these args "orange", "yellow", "white", "silver"
            //Did not Receive call with "white" as four params. So the below statement completes successfully.
            objResistanceCalculator.DidNotReceive().CalculateOhmValue("white", "white", "white", "white");
        }

        [TestMethod]
        public void TestReceivedCallsException()
        {
            // Arrange
            var objResistanceCalculator = Substitute.For<IResistanceCalculator>();
            ResistorController objResistorController = new ResistorController(objResistanceCalculator);
            Resistor objResistor = new Resistor("orange", "yellow", "white", "silver");

            // Act
            objResistorController.CalculateOhmValue(objResistor);

            //Assert
            //Received call with these args "orange", "yellow", "white", "silver"
            //Did not Receive call with "white" as four params. So the below statement fails successfully & throws a ReceivedCallsException
            //This test ensures controller layer just passes the inputs received from UI to Business Layer.
            try
            {
                objResistanceCalculator.Received().CalculateOhmValue("white", "white", "white", "white");
            }
            catch (Exception ex)
            {
                //Successful exceution of the below Assert if the caught exception is ReceivedCallsException.
                Assert.AreEqual(ex.GetType().ToString(), "NSubstitute.Exceptions.ReceivedCallsException");
            }
           
        }

        

        //[TestMethod]
        //public void TestArgumentNullException()
        //{
        //    //Arrange
        //    HomeController hController = new HomeController();

        //    //Act
        //    JsonResult result = (JsonResult)hController.getResistanceValue(null, null, null, null);
        //    //convert JSON to string
        //    string stringResult = new JavaScriptSerializer().Serialize(result.Data);
        //    //parse json string
        //    JObject joResponse = JObject.Parse(stringResult);
        //    //get error
        //    string error = (string)joResponse["error"];

        //    //Assert
        //    Assert.AreEqual("Exception ocurred while calculating resistance value: Value cannot be null.\r\nParameter name: key", error);
        //}

    }
}
