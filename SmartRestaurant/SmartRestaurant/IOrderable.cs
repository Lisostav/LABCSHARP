using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IOrderable
    {
        string Name { get; }
        decimal Price { get; }
        string GetDetails();
    }
}
