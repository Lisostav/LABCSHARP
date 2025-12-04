using Restaurant;
using Restaurant.RestaurantManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Restaurant restaurant = new Restaurant();

            restaurant.AddToMenu(new Dish("Борщ", 120.00m, "Перше"));
            restaurant.AddToMenu(new Dish("Салат Цезар", 150.00m, "Салат"));

            MenuItem coffeeItem = new Drink("Кава", 60.00m, 200, false);
            restaurant.AddToMenu(coffeeItem);

            restaurant.AddToMenu(new Drink("Сік апельсиновий", 70.00m, 250, false));
            restaurant.AddToMenu(new Drink("Вино червоне", 180.00m, 150, true));

            restaurant.DisplayFullMenu();

            Order order1 = restaurant.CreateNewOrder(5);

            IOrderable borsh = restaurant.FindMenuItemByName("Борщ");
            IOrderable coffee = restaurant.FindMenuItemByName("Кава");
            IOrderable wine = restaurant.FindMenuItemByName("Вино червоне");

            if (borsh != null) order1.AddItem(borsh);
            if (coffee != null) order1.AddItem(coffee);

            order1.RemoveItem("Кава");
            order1.AddItem(wine);

            Console.WriteLine($"Поточний статус: **{order1.Status}**");

            order1.ChangeStatus(OrderStatus.InProgress);
            order1.ChangeStatus(OrderStatus.Ready);

            Order order2 = restaurant.CreateNewOrder(12); 
            IOrderable salat = restaurant.FindMenuItemByName("Салат Цезар");
            if (salat != null) order2.AddItem(salat);
            order2.ChangeStatus(OrderStatus.InProgress);

            restaurant.DisplayActiveOrders();

            Console.WriteLine("\n--- ПОШУК ЗАМОВЛЕННЯ ---");
            Order foundOrder = restaurant.FindOrderById(101);
            if (foundOrder != null)
            {
                Console.WriteLine($"Знайдено замовлення ID: {foundOrder.Id}");
                foundOrder.ChangeStatus(OrderStatus.Paid);
            }

            var drinks = restaurant.FindMenuItemsByCategory("Напій");
            Console.WriteLine($"\nЗнайдено {drinks.Count} напоїв:");
            foreach (var d in drinks)
            {
                Console.WriteLine($"- {d.Name} {d.GetDetails()}");
            }

            Console.WriteLine("\n--- UPCAST / DOWNCAST ---");

            if (coffeeItem is Drink drinkItem)
            {
                Console.WriteLine($"Об'єкт '{drinkItem.Name}' перетворено до типу Drink.");
                Console.WriteLine($"Об'єм напою: {drinkItem.VolumeMl} мл");
                drinkItem.UpdatePrice(65.00m);
                Console.WriteLine($"Ціна оновлена: {drinkItem.Price:F2} грн");
            }
            Console.WriteLine("\n--- ФІНАЛЬНИЙ ВИВІД ЗАМОВЛЕННЯ 101 ---");
            foundOrder?.DisplayOrderInfo();
        }
    }
}
