using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTriangleAreaCalculator
{
    internal class Program
    {
        static async Task Main()
        {
            SetConsoleLanguage("uk-UA");
            Console.WriteLine("Введіть сторони трикутника:");

            Console.Write("Сторона A: ");
            double sideA = double.Parse(Console.ReadLine());

            Console.Write("Сторона B: ");
            double sideB = double.Parse(Console.ReadLine());

            Console.Write("Сторона C: ");
            double sideC = double.Parse(Console.ReadLine());

            try
            {
                double area = await CalculateTriangleAreaAsync(sideA, sideB, sideC);

                Console.WriteLine($"Площа трикутника: {area:F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.ReadLine();
        }

        static Task<double> CalculateTriangleAreaAsync(double a, double b, double c)
        {
            return Task.Run(() => CalculateTriangleArea(a, b, c));
        }

        static double CalculateTriangleArea(double a, double b, double c)
        {
            // Перевірка на існування трикутника за нерівністю трикутника
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Трикутник з такими сторонами не існує.");
            }

            // Розрахунок площі за формулою Герона
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        static void SetConsoleLanguage(string cultureName)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при зміні мови консолі: {ex.Message}");
            }
        }
    }
}
