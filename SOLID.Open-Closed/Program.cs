using SOLID.Open_Closed.DEMO2;
using System;
using System.Collections.Generic;

namespace SOLID.Open_Closed
{
    class Program
    {
        static void Main(string[] args)
        {
            //demo1
            var devCalculations = new List<BaseSalaryCalculator>
        {
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
            new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
        };
            //SalaryCalculator class is now closed for modification and opened for an extension, which is exactly what OCP states.
            var calculator = new SalaryCalculator(devCalculations);
            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");




            //demo2
            //old
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Red, Size.Large);

            Product[] products = { apple, tree, house };
            var productFilter = new ProductFilter();

            Console.WriteLine("Green products(Old): ");

            foreach (var product in productFilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {product.Name} is green");
            }

            //new
            var betterFilter = new BetterFilter();
            Console.WriteLine("Green products (new)");
            foreach (var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {product.Name} is green");
            }

            //filter with two specification
            Console.WriteLine("Large  red items");
            foreach (var product in betterFilter.Filter(
                products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Red),
                    new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($" - {product.Name} big and red");
            }

            Console.ReadLine();
        }
    }
}
