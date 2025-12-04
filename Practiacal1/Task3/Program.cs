namespace Task3
{
    using System;
    public class Program
    {
        static int InputAge()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int enteredNumb))
                {
                    return enteredNumb;
                }
                Console.WriteLine("Неправильний ввід");
            }
        }
        public static string ClassifyAge(int age)
        {
            switch (age)
            {
                case int n when n < 0 || n > 120:
                    return ("Нереальний вік");
                case int n when n < 12:
                    return ("Ви дитина");
                case int n when n >= 12 && n <= 17:
                    return ("Підліток");
                case int n when n > 17 && n <= 59:
                    return ("Дорослий");
                default:
                    return ("Пенсіонер");

            }
        }
        static void Main()
        {
            Console.WriteLine("Введіть ваш вік");
            int age = InputAge();
            Console.WriteLine(ClassifyAge(age));
        }
    }
}
