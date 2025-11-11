namespace Task1
{
    using System;

    public class Program
    {
        public static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
        public static string GetMessage(int x)
        {
            if (IsEven(x))
            {
                return "Двері відкриваються!";
            }
            return "Двері зачинені...";
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (int.TryParse(Console.ReadLine(), out int enteredNumb))
            {
                Console.WriteLine(GetMessage(enteredNumb));
            }
            else
            {
                Console.WriteLine("Неправильний ввід");
            }
        }
    }
}