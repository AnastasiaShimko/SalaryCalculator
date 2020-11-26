using SalaryCalculator;
using System.Collections.Generic;

namespace SalaryCalculatorBase.AppLogic
{
    public static class BusinessLogic
    {
        public static double CountSalary(int planSales, int actualSales, double planSum, List<Sale> salesList, double baseSalary, double tax )
        {
            var actualSum = GetActualSum(salesList);
            var workerPercent = GetPercentBySum(planSum, actualSum);
            var eachSaleBonus = GetBonusForEachSale(planSales, actualSales);
            var salaryFromSales = GetSalaryFromSales(workerPercent, eachSaleBonus, salesList);
            var fullSalary = GetFullSalary(salaryFromSales, baseSalary);
            var actualSalary = GetSalaryWithoutTaxes(fullSalary, tax);

            return actualSalary;
        }

        public static double GetSalaryWithoutTaxes(double fullSalary, double tax)
        {
            var result = fullSalary * (1 - tax);

            return result;
        }

        private static double GetFullSalary(double salaryFromSales, double baseSalary)
        {
            return salaryFromSales + baseSalary;
        }

        public static double GetSalaryFromSales(double workerPercent, double eachSaleBonus, List<Sale> salesList)
        {
            double result = 0;
            foreach (var sum in salesList)
            {
                result += (sum.Amount * workerPercent) + eachSaleBonus;
            }
            return result;
        }

        public static double GetPercentBySum(double planSum, double actualSum)
        {
            double result = 0;
            var donePercent = (actualSum / planSum) * 100;

            if (donePercent <= 79)
            {
                result = 0.01;
            } else if (donePercent <= 89)
            {
                result = 0.03;
            } else if (donePercent <= 99)
            {
                result = 0.05;
            }
            else
            {
                result = 0.07;
            }
            return result;
        }
        public static double GetActualSum(List<Sale> salesList)
        {
            double result = 0;
            foreach (var sum in salesList)
            {
                result += sum.Amount;
            }
            return result;
        }

        public static double GetBonusForEachSale(double planSales, double actualSales)
        {
            double result = 0;
            var donePercent = (actualSales / planSales) * 100;

            if (donePercent <= 49)
            {
                result = 15;
            }
            else if (donePercent <= 79)
            {
                result = 25;
            }
            else if (donePercent <= 99)
            {
                result = 40;
            }
            else
            {
                result = 70;
            }
            return result;
        }
    }
}
