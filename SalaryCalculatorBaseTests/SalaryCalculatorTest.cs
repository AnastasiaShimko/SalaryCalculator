using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SalaryCalculator;
using SalaryCalculatorBase;
using SalaryCalculatorBase.Helpers;

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
        public void GetPercentBySum_Always_ReturnsExpectedResult()
        {
            // Arrange
           
            //Act

            //Assert
           
        }
    }
}