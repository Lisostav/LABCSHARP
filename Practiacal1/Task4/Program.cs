namespace Task4
{
    public class Program
    {
        static bool DoubleEqual(double x, double y, double epsilon = 1e-9)
        {
            return Math.Abs(x - y) < epsilon;
        }
        public static bool IsValidTriangle(double a, double b, double c)
        {
            return (a + b > c && b + c > a && a + c > b);
        }
        public static double GetPerimeter(double a, double b, double c)
        {
            return (a + b + c);
        }
        public static double GetArea(double a, double b, double c)
        {
            double p = GetPerimeter(a, b, c) / 2;
            return (Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }
        public static string GetTriangleType(double a, double b, double c)
        {
            if (DoubleEqual(a * a + b * b, c * c) || DoubleEqual(b * b + c * c, a * a) || DoubleEqual(a * a + c * c, b * b)) return "прямокутний";
            else if (DoubleEqual(a, b) && DoubleEqual(b, c)) return "рівносторонній";
            else if (DoubleEqual(a, c) || DoubleEqual(b, c) || DoubleEqual(a, b)) return "рівнобедрений";
            else return "довільний";
        }
        static double InputInt()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double enteredNumb) && enteredNumb > 0)
                {
                    return enteredNumb;
                }
                Console.WriteLine("Неправильний ввід");
            }
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введіть a");
            double a = InputInt();
            Console.WriteLine("Введіть b");
            double b = InputInt();
            Console.WriteLine("Введіть c");
            double c = InputInt();
            if (IsValidTriangle(a, b, c))
            {
                Console.WriteLine("Трикутник існує");
                Console.WriteLine("Периметр трикутника: " + GetPerimeter(a, b, c));
                Console.WriteLine("Площа трикутника: " + GetArea(a, b, c));
                Console.WriteLine("Тип трикутника: " + GetTriangleType(a, b, c));
            }
        }
    }
}