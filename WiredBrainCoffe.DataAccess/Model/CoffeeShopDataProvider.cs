using System;
using System.Collections.Generic;
using System.Text;

namespace WiredBrainCoffe.DataAccess.Model
{
    public class CoffeeShopDataProvider
    {
        public IEnumerable<CoffeeShop> LoadCoffeeShops()
        {
            yield return new CoffeeShop { Location = "Palatka", BeansInStockInKg = 100, PaperCupsInStock = 123 };
            yield return new CoffeeShop { Location = "Orlando", BeansInStockInKg = 50, PaperCupsInStock = 23 };
            yield return new CoffeeShop { Location = "Miami", BeansInStockInKg = 75, PaperCupsInStock = 1345 };
        }
    }
}
