using Restaurant;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Drink : MenuItem
    {
        public int VolumeMl { get; private set; }
        public bool IsAlcoholic { get; private set; }

        public Drink(string name, decimal price, int volumeMl, bool isAlcoholic)
            : base(name, price, "Напій")
        {
            this.VolumeMl = volumeMl;
            this.IsAlcoholic = isAlcoholic;
        }

        public override string GetDetails()
        {
            string alcoholStatus = IsAlcoholic ? "алкоголь" : "без алкоголю";
            return $"({VolumeMl} мл, {alcoholStatus}) - {Price:F2} грн";
        }
    }
}
