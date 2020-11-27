using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator;

namespace SalaryCalculatorBase.Interfaces
{
    interface ISalaryCalculator
    {
        double GetSalaryWithoutTaxes(double fullSalary, double tax);
        double GetFullSalary(double salaryFromSales, double baseSalary);
        double GetSalaryFromSales(double workerPercent, double eachSaleBonus, List<Sale> salesList);
        double GetPercentBySum(double planSum, double actualSum);
        double GetActualSum(List<Sale> salesList);
        double GetBonusForEachSale(double planSales, double actualSales);
    }
}
