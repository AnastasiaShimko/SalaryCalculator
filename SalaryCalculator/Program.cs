using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите количество продаж, необходимое для выполнения плана: ");
            var planSales = Console.ReadLine();

            Console.WriteLine("Введите количество ваших продаж: ");
            var ActualSales = Console.ReadLine();

            var salesList = new List<Sale>();

            for (int i = 1; i <= Convert.ToInt32(ActualSales); i++)
            {
                var sale = new Sale();

                Console.WriteLine($"Введите информацию по продаже №{i}. ");

                Console.WriteLine($"Введите сумму продажи №{i}: ");
                sale.Amount = Convert.ToDouble(Console.ReadLine().Replace('.',','));

                Console.WriteLine($"Введите клиента по продаже №{i}: ");
                sale.Client = Console.ReadLine();

                salesList.Add(sale);
            }

            
        }
    }

}
