using System;
using SalaryCalculatorBase.Interfaces;

namespace SalaryCalculatorBase.Models
{
    public class StaticClock : IClock
    {
        public DateTime Now => new DateTime(2000, 01, 01, 10, 10, 10);
    }
}
