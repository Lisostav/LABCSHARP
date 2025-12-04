using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class MenuItem : IOrderable
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; private set; }

        public MenuItem(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public abstract string GetDetails();
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice > 0)
            {
                Price = newPrice;
            }
        }
    }
}