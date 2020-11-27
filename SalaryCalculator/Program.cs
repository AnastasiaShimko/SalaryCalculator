using System;
using System.Collections.Generic;
using SalaryCalculatorBase;

namespace SalaryCalculator
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            Init.StartUp();

            Console.WriteLine("Введите ваш оклад: ");
            var baseSalary = Convert.ToDouble(Console.ReadLine()?.Replace('.', ','));

            Console.WriteLine("Введите какой процент от зарплаты составляют налоги: ");
            var tax = Convert.ToDouble(Console.ReadLine())/100;

            Console.WriteLine("Введите количество продаж, необходимое для выполнения плана: ");
            var planSales = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество ваших продаж: ");
            var actualSales = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите сумму необходимую для выполнения плана: ");
            var planSum = Convert.ToDouble(Console.ReadLine());
            
            var salesList = new List<Sale>();

            for (int i = 1; i <= Convert.ToInt32(actualSales); i++)
            {
                var sale = new Sale();

                //Console.WriteLine($"Введите информацию по продаже №{i}. ");

                Console.WriteLine($"Введите сумму продажи №{i}: ");
                sale.Amount = Convert.ToDouble(Console.ReadLine()?.Replace('.',','));

                //Console.WriteLine($"Введите клиента по продаже №{i}: ");
                //sale.Client = Console.ReadLine();

                salesList.Add(sale);
            }
            
            var actualSalary = SalaryCalculatorBase.AppLogic.BusinessLogic.CountSalary(planSales,actualSales,planSum, salesList,baseSalary,tax);

            Console.WriteLine($"Ваша зарплата: {actualSalary}");
            Console.ReadLine();
        }
    }

}
