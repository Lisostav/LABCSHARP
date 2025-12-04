namespace Task2
{
    using System;

    public class Program
    {
        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            int[] numbers = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(min, max);
            }
            return numbers;
        }
        public static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int i in numbers)
            {
                sum += i;
            }
            return sum;
        }
        public static double GetAverage(int[] numbers)
        {
            double avg = (double)GetSum(numbers) / numbers.Length;
            return avg;
        }
        public static int GetMin(int[] numbers)
        {
            int min = int.MaxValue;
            foreach (int i in numbers)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }
        public static int GetMax(int[] numbers)
        {
            int max = int.MinValue;
            foreach (int i in numbers)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }
        static int InputInt()
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
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть довжину масиву: ");
            int size = InputInt();

            Console.Write("Введіть мінімальне значення: ");
            int min = InputInt();

            Console.Write("Введіть максимальне значення: ");
            int max = InputInt();
            int[] arr = GenerateRandomArray(size, min, max);
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine("Сума масива: " + GetSum(arr));
            Console.WriteLine("Середньє значення масива: " + GetAverage(arr));
            Console.WriteLine("Найменьше значення масива : " + GetMin(arr));
            Console.WriteLine("Найбільше значення масива: " + GetMax(arr));
        }
    }
}