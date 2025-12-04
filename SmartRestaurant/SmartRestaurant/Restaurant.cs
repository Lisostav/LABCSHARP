using Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Restaurant
    {
        private List<MenuItem> _menu { get; set; }
        private List<Order> _activeOrders { get; set; }

        public Restaurant()
        {
            _menu = new List<MenuItem>();
            _activeOrders = new List<Order>();
        }
        public void AddToMenu(MenuItem item)
        {
            _menu.Add(item);
        }

        public void DisplayFullMenu()
        {
            Console.WriteLine("\n--- МЕНЮ РЕСТОРАНУ ---");
            foreach (var item in _menu)
            {
                Console.WriteLine($"* {item.Name} {item.GetDetails()}");
            }
            Console.WriteLine("-----------------------");
        }

        public IOrderable FindMenuItemByName(string name)
        {
            return _menu.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<MenuItem> FindMenuItemsByCategory(string category)
        {
            return _menu.Where(item => item.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public Order CreateNewOrder(int tableOrClientId)
        {
            Order newOrder = new Order(tableOrClientId);
            _activeOrders.Add(newOrder);
            return newOrder;
        }

        public void DisplayActiveOrders()
        {
            Console.WriteLine("\n--- АКТИВНІ ЗАМОВЛЕННЯ ---");
            if (_activeOrders.Count == 0)
            {
                Console.WriteLine("Немає активних замовлень.");
                return;
            }
            foreach (var order in _activeOrders)
            {
                Console.Write($"ID: {order.Id} | Стіл/Клієнт: #{order.TableOrClientId} | Статус: {order.Status} | ");
                order.DisplayCurrentTotal();
            }
            Console.WriteLine("---------------------------");
        }

        public Order FindOrderById(int id)
        {
            return _activeOrders.FirstOrDefault(o => o.Id == id);
        }
    }
}
