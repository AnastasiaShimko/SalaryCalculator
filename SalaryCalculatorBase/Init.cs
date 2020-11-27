using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculatorBase.Helpers;

namespace SalaryCalculatorBase
{
    public static class Init
    {
        public static void StartUp()
        {
            Global.CalculatorHelper = new CalculatorHelper();
        }
    }
}
