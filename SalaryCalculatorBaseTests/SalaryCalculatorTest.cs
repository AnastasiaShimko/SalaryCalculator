using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SalaryCalculator;
using SalaryCalculatorBase;
using SalaryCalculatorBase.Helpers;
using SalaryCalculatorBase.Interfaces;
using SalaryCalculatorBase.Models;

namespace SalaryCalculatorBaseTests
{
    public class SalaryCalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetSalaryWithoutTaxes_Always_ReturnsExpectedResult()
        {
            // Arrange
            var calculatorHelper = CreateDefaultCalculatorHelper();
            double result;

            //Act
            result = calculatorHelper.GetSalaryWithoutTaxes(Convert.ToDouble(1000),Convert.ToDouble(0.1));
            
            //Assert
            Assert.That(result, Is.EqualTo(Convert.ToDouble(900)));
        }


        [Test]
        public void GetPercentBySum_WhenEqual_ReturnsSevenPercent()
        {
            // Arrange
            var calculatorHelper = CreateDefaultCalculatorHelper();
            Mock<ISalaryCalculator> mock = new Mock<ISalaryCalculator>();
            mock.Setup(m => m.GetActualSum(It.IsAny<List<Sale>>()))
                .Returns<double>(d => Convert.ToDouble(5000));

            var planSum = 5000;

            // Act
            var workerPercent = calculatorHelper.GetPercentBySum(planSum, mock.Object.GetActualSum(null));

            // Assert
            Assert.AreEqual(workerPercent, 0.07);

        }

        [Test]
        public void GetCongratulationsPhrase_WhenBig_ReturnsPhraseWithWow()
        {
            // Arrange
            var calculatorHelper = CreateDefaultCalculatorHelper();

            var bonusAmount = new Bonus() {Amount = 1500.0, CongratulationsPhrase = ""};

            Mock<ISalaryCalculator> mock = new Mock<ISalaryCalculator>();
            mock.Setup(m => m.GetSalaryFromSales(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<List<Sale>>())).Returns((Bonus)bonusAmount);
            
            // Act
            var actualBonus = calculatorHelper.FillCongratulationsPhrase(mock.Object.GetSalaryFromSales(0, 0, null));

            // Assert
            Assert.True(actualBonus.CongratulationsPhrase.Contains("���"));

        }

        //GetSalaryFromSales

        [Test]
        public void GetSalaryFromSales_Always_ReturnsCorrectAmount()
        {
            // Arrange
            var calculatorHelper = CreateDefaultCalculatorHelper();

            var sales = new List<Sale>();
            sales.Add(new Sale
            {
                Client = null,
                Amount = 100.0
            });
            sales.Add(new Sale
            {
                Client = null,
                Amount = 200.0
            });
            sales.Add(new Sale
            {
                Client = null,
                Amount = 300.0
            });

            // Act
            var bonusFromSales = calculatorHelper.GetSalaryFromSales(0.1, 10, sales);

            // Assert
            Assert.AreEqual(Convert.ToDouble(90), bonusFromSales.Amount);
        }

        [Test]
        public void GetPercentByMonth_InJanuary_ReturnsOne()
        {
            // Arrange
            var calculatorHelper = CreateDefaultCalculatorHelper();
            var staticClock = new StaticClock();

            // Act
            var percent = calculatorHelper.GetPercentByMonth(staticClock.Now.Month);

            // Assert
            Assert.AreEqual(0.1, percent);
        }
        private CalculatorHelper CreateDefaultCalculatorHelper()
        {
            return new CalculatorHelper();
        }
    }
}