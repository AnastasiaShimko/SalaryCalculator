using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator;
using SalaryCalculatorBase.Models;

namespace SalaryCalculatorBase.Interfaces
{
     public interface ISalaryCalculator
    {
        double GetSalaryWithoutTaxes(double fullSalary, double tax);
        double GetFullSalary(double salaryFromSales, double baseSalary);
        Bonus GetSalaryFromSales(double workerPercent, double eachSaleBonus, List<Sale> salesList);
        double GetPercentBySum(double planSum, double actualSum);
        double GetActualSum(List<Sale> salesList);
        double GetBonusForEachSale(double planSales, double actualSales);
        Bonus GetCongratulationsPhrase(Bonus bonus);
    }
}
