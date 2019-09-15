using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffe.DataAccess.Model;

namespace WiredBrainCoffee.ShoppingTool
{
    internal class CoffeeShopCommandHandler : ICommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;
        private string line;

        public CoffeeShopCommandHandler(IEnumerable<CoffeeShop> coffeeShops, string line)
        {
            this.coffeeShops = coffeeShops;
            this.line = line;
        }

        public void HandleCommand()
        {
            var foundCoffeShops = coffeeShops
                                    .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                                    .ToList();

            if (foundCoffeShops.Count == 0)
            {
                Console.WriteLine($"Location '{line} 'not found");
            }
            else if (foundCoffeShops.Count == 1)
            {
                Console.WriteLine($"Location: {foundCoffeShops.First().Location}");
                Console.WriteLine($"Beans in stock: {foundCoffeShops.First().BeansInStockInKg} kg");
                Console.WriteLine($"Paper cups in stock: {foundCoffeShops.First().PaperCupsInStock}");
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