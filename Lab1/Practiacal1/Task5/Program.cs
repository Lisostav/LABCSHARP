namespace Task5 {
public class Program
{

    static Random rnd = new Random();

    public static int[][] GenerateJaggedArr()
    {
        int[][] groups = new int[4][];
        for (int i = 0; i < groups.Length; i++)
        {
            int size = rnd.Next(10, 31);
            groups[i] = new int[size];
            for (int j = 0; j < size; j++)
            {
                groups[i][j] = rnd.Next(50, 101);
            }
        }
        return groups;
    }
    public static double GetAverage(int[] marks)
    {
        int sum = 0;
        foreach (int m in marks) sum += m;
        return (double)sum / marks.Length;
    }
    public static int GetMin(int[] marks)
    {
        int min = marks[0];
        foreach (int m in marks) if (m < min) min = m;
        return min;
    }
    public static int GetMax(int[] marks)
    {
        int max = marks[0];
        foreach (int m in marks) if (m > max) max = m;
        return max;
    }
    public static void PrintGroupStatistics(int[][] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            Console.WriteLine(
                $"Група {i + 1}: Середній = {Math.Round(GetAverage(groups[i]))}, " +
                $"Мінімальний = {GetMin(groups[i])}, " +
                $"Максимальний = {GetMax(groups[i])}"
            );
        }
    }
    static void Main()
    {
        int[][] groups = GenerateJaggedArr();
        PrintGroupStatistics(groups);
    }
}
}