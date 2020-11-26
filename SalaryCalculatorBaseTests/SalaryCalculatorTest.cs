using System;
using NUnit.Framework;

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
            var result = SalaryCalculatorBase.AppLogic.BusinessLogic.GetSalaryWithoutTaxes(Convert.ToDouble(1000),Convert.ToDouble(0.1));
            Assert.That(result, Is.EqualTo(Convert.ToDouble(900)));
        }
    }
}