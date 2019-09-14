using System;
using WiredBrainCoffe.DataAccess.Model;

namespace WiredBrainCoffee.ShoppingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Write 'help' to display data");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();
                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shops");
                    foreach (var c in coffeeShops)
                    {
                        Console.WriteLine($"> " + c.Location);
                    }
                }

            }
        }
    }
}
