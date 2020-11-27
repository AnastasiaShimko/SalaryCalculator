using SalaryCalculator;
using System.Collections.Generic;

namespace SalaryCalculatorBase.AppLogic
{
    public static class BusinessLogic
    {
        public static double CountSalary(int planSales, int actualSales, double planSum, List<Sale> salesList, double baseSalary, double tax )
        {
            // Получаем сумму всех продаж
            var actualSum = Global.CalculatorHelper.GetActualSum(salesList);

            // Какой процент получит работник от продаж
            var workerPercent = Global.CalculatorHelper.GetPercentBySum(planSum, actualSum);

            // Какой бонус получит за каждую продажу
            var eachSaleBonus = Global.CalculatorHelper.GetBonusForEachSale(planSales, actualSales);

            // Получаем общую прибавку к окладу
            var salaryFromSales = Global.CalculatorHelper.GetSalaryFromSales(workerPercent, eachSaleBonus, salesList);
            
            // Суммируем оклад и прибавку
            var fullSalary = Global.CalculatorHelper.GetFullSalary(salaryFromSales.Amount, baseSalary);

            // Вычитаем налоги из полной зарплаты
            var actualSalary = Global.CalculatorHelper.GetSalaryWithoutTaxes(fullSalary, tax);

            return actualSalary;
        }
    }
}
