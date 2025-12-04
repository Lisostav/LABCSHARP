using Restaurant;
using Restaurant.RestaurantManagementSystem;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Order
    {
        private static int _nextId = 101;
        public int Id { get; private set; }
        public int TableOrClientId { get; private set; }
        public OrderStatus Status { get; private set; }
        private List<IOrderable> _items { get; set; }

        public Order(int tableOrClientId)
        {
            Id = _nextId++;
            TableOrClientId = tableOrClientId;
            Status = OrderStatus.New;
            _items = new List<IOrderable>();
            Console.WriteLine($"Створено нове замовлення | ID: {Id} | Об'єкт: #{tableOrClientId}");
        }
        public void AddItem(IOrderable item)
        {
            _items.Add(item);
            Console.WriteLine($"Додано позицію: **{item.Name}**");
            DisplayCurrentTotal();
        }
        public bool RemoveItem(string name)
        {
            IOrderable itemToRemove = _items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                Console.WriteLine($"Видалено позицію: **{itemToRemove.Name}**");
                DisplayCurrentTotal();
                return true;
            }
            Console.WriteLine($"Позицію '{name}' не знайдено в замовленні.");
            return false;
        }
        public decimal CalculateTotal()
        {
            return _items.Sum(item => item.Price);
        }
        public void ChangeStatus(OrderStatus newStatus)
        {
            Console.WriteLine($"> Змінено статус: {Status} → **{newStatus}**");
            Status = newStatus;
        }

        public void DisplayCurrentTotal()
        {
            Console.WriteLine($"Поточна сума: **{CalculateTotal():F2} грн**");
        }

        public void DisplayOrderInfo()
        {
            Console.WriteLine($"ID: {Id} | Об'єкт: #{TableOrClientId} | Статус: {Status} | Сума: {CalculateTotal():F2} грн");
            Console.WriteLine("--- Позиції ---");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.Name} {item.GetDetails()}");
            }
            Console.WriteLine("----------------");
        }
    }
}
