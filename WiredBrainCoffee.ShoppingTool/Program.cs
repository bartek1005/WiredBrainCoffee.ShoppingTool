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
                var commandHandler =
                    string.Equals("help", line, StringComparison.OrdinalIgnoreCase)
                    ? new HelpCommandHAndler(coffeeShops) as ICommandHandler
                    : new CoffeeShopCommandHandler(coffeeShops, line);

                commandHandler.HandleCommand();

            }
        }
    }
}
