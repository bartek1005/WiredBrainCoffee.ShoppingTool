using System;
using System.Linq;
using WiredBrainCoffe.DataAccess.Model;

namespace WiredBrainCoffee.ShoppingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Write 'help' to display available coffee shops," + " write 'quit' to close application");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                    break;

                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shops");
                    foreach (var c in coffeeShops)
                    {
                        Console.WriteLine($"> " + c.Location);
                    }
                }
                else
                {
                    var foundCoffeShops = coffeeShops
                        .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if(foundCoffeShops.Count == 0)
                    {
                        Console.WriteLine($"Location '{line} 'not found");
                    }
                    else if (foundCoffeShops.Count == 1)
                    {
                        Console.WriteLine($"Location: {foundCoffeShops.First().Location}");
                        Console.WriteLine($"Beans in stock: {foundCoffeShops.First().BeansInStockInKg} kg");
                    }
                    else
                    {
                        Console.WriteLine("Multiple shops found");
                        short i = 1;
                        foreach (var cs in foundCoffeShops)
                        {
                            Console.WriteLine($" {i}. {cs.Location}");
                            i++;
                        }
                    }
                }

            }
        }
    }
}
