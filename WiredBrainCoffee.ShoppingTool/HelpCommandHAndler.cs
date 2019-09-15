using System;
using System.Collections.Generic;
using WiredBrainCoffe.DataAccess.Model;

namespace WiredBrainCoffee.ShoppingTool
{
    internal class HelpCommandHAndler : ICommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;

        public HelpCommandHAndler(IEnumerable<CoffeeShop> coffeeShops)
        {
            this.coffeeShops = coffeeShops;
        }

        public void HandleCommand()
        {
            Console.WriteLine("> Available coffee shops");
            foreach (var c in coffeeShops)
            {
                Console.WriteLine($"> " + c.Location);
            }
        }
    }
}