using Restaurant;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Dish : MenuItem
    {
        public string DishType { get; private set; }

        public Dish(string name, decimal price, string dishType)
            : base(name, price, "Страва")
        {
            this.DishType = dishType;
        }

        public override string GetDetails()
        {
            return $"({DishType}) - {Price:F2} грн";
        }
    }
}
