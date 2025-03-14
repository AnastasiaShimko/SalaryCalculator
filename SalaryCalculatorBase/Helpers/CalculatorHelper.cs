﻿using System;
using System.Collections.Generic;
using SalaryCalculator;
using SalaryCalculatorBase.Interfaces;
using SalaryCalculatorBase.Models;

namespace SalaryCalculatorBase.Helpers
{
    public class CalculatorHelper : ISalaryCalculator
    {
        public double GetSalaryWithoutTaxes(double fullSalary, double tax)
        {
            var result = fullSalary * (1 - tax);

            return result;
        }

        public double GetFullSalary(double salaryFromSales, double baseSalary)
        {
            return salaryFromSales + baseSalary;
        }

        public Bonus GetSalaryFromSales(double workerPercent, double eachSaleBonus, List<Sale> salesList)
        {
            Bonus result = new Bonus();
            foreach (var sum in salesList)
            {
                result.Amount += ((sum.Amount * workerPercent) + eachSaleBonus);
            }
            return result;
        }

        public double GetPercentBySum(double planSum, double actualSum)
        {
            double result;
            var donePercent = (actualSum / planSum) * 100;

            if (donePercent <= 79)
            {
                result = 0.01;
            }
            else if (donePercent <= 89)
            {
                result = 0.03;
            }
            else if (donePercent <= 99)
            {
                result = 0.05;
            }
            else
            {
                result = 0.07;
            }
            return result;
        }
        public double GetActualSum(List<Sale> salesList)
        {
            double result = 0;
            foreach (var sum in salesList)
            {
                result += sum.Amount;
            }
            return result;
        }

        public double GetBonusForEachSale(double planSales, double actualSales)
        {
            double result;
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

        public Bonus FillCongratulationsPhrase(Bonus bonus)
        {
            var result = new Bonus();
            result.Amount = bonus.Amount;

            if (bonus.Amount < 1000)
            {
                result.CongratulationsPhrase = $"Ваш бонус составляет всего лишь: {bonus.Amount} рублей.";

            } else
            {
                result.CongratulationsPhrase = $"Ого! Ваш бонус составляет: {bonus.Amount} рублей.";
            }
            return result;
        }

        public double GetPercentByMonth(int monthNumber)
        {
            var result = 0.1;

            switch (monthNumber)
            {
                case 1:
                    result = 0.1;
                    break;
                case 2:
                    result = 0.2;
                    break;
                case 3:
                    result = 0.3;
                    break;
                case 4:
                    result = 0.4;
                    break;
                case 5:
                    result = 0.5;
                    break;
                case 6:
                    result = 0.6;
                    break;
                case 7:
                    result = 0.7;
                    break;
                case 8:
                    result = 0.8;
                    break;
                case 9:
                    result = 0.9;
                    break;
                case 10:
                case 11:
                case 12:
                    result = 1.0;
                    break;
            }
            return result;
        }
    }
}
