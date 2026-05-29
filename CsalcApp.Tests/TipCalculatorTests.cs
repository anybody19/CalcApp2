using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalcApp;

namespace CalcApp.Tests
{
    [TestClass]
    public class TipCalculatorTests
    {
        [TestMethod]
        public void CalculateTotal_ValidData_ReturnsCorrectValue()
        {
            double result = TipCalculator.CalculateTotal(1000, 2, 10);

            Assert.AreEqual(1100, result, 0.01);
        }

        [TestMethod]
        public void CalculatePerPerson_ValidData_ReturnsCorrectValue()
        {
            double result = TipCalculator.CalculatePerPerson(1200, 3);

            Assert.AreEqual(400, result, 0.01);
        }

        [TestMethod]
        public void CalculateTotal_ZeroBill_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TipCalculator.CalculateTotal(0, 2, 10);
            });
        }

        [TestMethod]
        public void CalculateTotal_NegativeBill_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TipCalculator.CalculateTotal(-100, 2, 10);
            });
        }

        [TestMethod]
        public void CalculatePerPerson_ZeroGuests_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TipCalculator.CalculatePerPerson(1000, 0);
            });
        }

        [TestMethod]
        public void CalculateTotal_NoTips_ReturnsCorrectValue()
        {
            double result = TipCalculator.CalculateTotal(1000, 2, 0);

            Assert.AreEqual(1000, result, 0.01);
        }

        [TestMethod]
        public void CalculateTotal_ResultNotEqual()
        {
            double result = TipCalculator.CalculateTotal(1000, 2, 5);

            Assert.AreNotEqual(2000, result);
        }

        [TestMethod]
        public void CalculateTotal_IsTrue()
        {
            double result = TipCalculator.CalculateTotal(1000, 2, 15);

            Assert.IsTrue(result > 1000);
        }

        [TestMethod]
        public void CalculateTotal_IsFalse()
        {
            double result = TipCalculator.CalculateTotal(1000, 2, 0);

            Assert.IsFalse(result > 2000);
        }

        [TestMethod]
        public void CalculatePerPerson_OneGuest()
        {
            double result = TipCalculator.CalculatePerPerson(500, 1);

            Assert.AreEqual(500, result, 0.01);
        }
    }
}
