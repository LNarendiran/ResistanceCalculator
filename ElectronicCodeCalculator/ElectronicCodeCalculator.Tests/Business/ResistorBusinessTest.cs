using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicCodeCalculator.Business;
using ElectronicCodeCalculator.Core.Models;

namespace ElectronicCodeCalculator.Tests.Business
{
    [TestClass]
    public class ResistorBusinessTest
    {       
        [TestMethod]
        public void TestNullResistance()
        {
            //Arrange
            ResistorBusiness objResitorBusiness = new ResistorBusiness();
            string strExpectedMinResistance = null;
            string strExpectedNormalResistance = null;
            string strExpectedMaxResistance = null;

            //Act
            Resistance objActualResult = objResitorBusiness.CalculateOhmValue(null,null,null,null);

            //Assert
            Assert.AreEqual(strExpectedMinResistance, objActualResult.MinResistance);
            Assert.AreEqual(strExpectedNormalResistance, objActualResult.NormalResistance);
            Assert.AreEqual(strExpectedMaxResistance, objActualResult.MaxResistance);
        }

        [TestMethod]
        public void TestEmptyStringResistance()
        {
            //Arrange
            ResistorBusiness objResitorBusiness = new ResistorBusiness();
            string strExpectedMinResistance = null;
            string strExpectedNormalResistance = null;
            string strExpectedMaxResistance = null;

            //Act
            Resistance objActualResult = objResitorBusiness.CalculateOhmValue(string.Empty, string.Empty, string.Empty, string.Empty);

            //Assert
            Assert.AreEqual(strExpectedMinResistance, objActualResult.MinResistance);
            Assert.AreEqual(strExpectedNormalResistance, objActualResult.NormalResistance);
            Assert.AreEqual(strExpectedMaxResistance, objActualResult.MaxResistance);
        }

        [TestMethod]
        public void TestInvalidInputResistance()
        {
            //Arrange
            ResistorBusiness objResitorBusiness = new ResistorBusiness();
            string strExpectedMinResistance = "0";
            string strExpectedNormalResistance = "0";
            string strExpectedMaxResistance = "0";

            //Act
            Resistance objActualResult = objResitorBusiness.CalculateOhmValue("123","3er^7","*(()","5679$");

            //Assert
            Assert.AreEqual(strExpectedMinResistance, objActualResult.MinResistance);
            Assert.AreEqual(strExpectedNormalResistance, objActualResult.NormalResistance);
            Assert.AreEqual(strExpectedMaxResistance, objActualResult.MaxResistance);
        }

        [TestMethod]
        public void TestLargeResistance()
        {
            //Arrange
            ResistorBusiness objResitorBusiness = new ResistorBusiness();
            string strExpectedMinResistance = "89,100M";
            string strExpectedNormalResistance = "99,000M";
            string strExpectedMaxResistance = "108,900M";

            //Act
            Resistance objActualResult = objResitorBusiness.CalculateOhmValue("white", "white", "white", "silver");

            //Assert
            Assert.AreEqual(strExpectedMinResistance, objActualResult.MinResistance);
            Assert.AreEqual(strExpectedNormalResistance, objActualResult.NormalResistance);
            Assert.AreEqual(strExpectedMaxResistance, objActualResult.MaxResistance);
        }

        [TestMethod]
        public void TestSmallResistance()
        {
            //Arrange
            ResistorBusiness objResitorBusiness = new ResistorBusiness();
            string strExpectedMinResistance = "0.009999";
            string strExpectedNormalResistance = "0.01";
            string strExpectedMaxResistance = "0.010001";

            //Act
            Resistance objActualResult = objResitorBusiness.CalculateOhmValue("brown", "black", "pink", "gray");

            //Assert
            Assert.AreEqual(strExpectedMinResistance, objActualResult.MinResistance);
            Assert.AreEqual(strExpectedNormalResistance, objActualResult.NormalResistance);
            Assert.AreEqual(strExpectedMaxResistance, objActualResult.MaxResistance);
        }
    }
}
