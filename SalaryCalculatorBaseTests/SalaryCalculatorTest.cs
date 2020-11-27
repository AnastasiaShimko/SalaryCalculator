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
            CalculatorHelper calculatorHelper = new CalculatorHelper();
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
            CalculatorHelper calculatorHelper = new CalculatorHelper();
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
            CalculatorHelper calculatorHelper = new CalculatorHelper();

            var bonusAmount = new Bonus() {Amount = 1500.0, CongratulationsPhrase = ""};

            Mock<ISalaryCalculator> mock = new Mock<ISalaryCalculator>();
            mock.Setup(m => m.GetSalaryFromSales(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<List<Sale>>())).Returns((Bonus)bonusAmount);
            
            // Act
            var actualBonus = calculatorHelper.GetCongratulationsPhrase(mock.Object.GetSalaryFromSales(0, 0, null));

            // Assert
            Assert.True(actualBonus.CongratulationsPhrase.Contains("Œ„Ó"));

        }
    }
}