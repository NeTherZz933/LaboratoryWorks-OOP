using System;

namespace Lab3Variant23
{
    class Program
    {
        static double SumN(double x, int n)
        {
            double sum = 0;
            double term = -2 * x * x;
            sum = term;

            for (int i = 2; i <= n; i++)
            {
                term = term * (-1) * Math.Pow(2 * x, 2) / ((2 * i - 1) * (2 * i));
                sum += term;
            }
            return sum;
        }

        static double SumEps(double x, double eps)
        {
            double sum = 0;
            double term = -2 * x * x;
            int i = 1;

            while (Math.Abs(term) >= eps)
            {
                sum += term;
                i++;
                term = term * (-1) * Math.Pow(2 * x, 2) / ((2 * i - 1) * (2 * i));
            }
            return sum;
        }
        static void Main()
        {
            double a = 0.1;
            double b = 1.0;
            int k = 9;
            double step = (b - a) / k;
            int n = 15;
            double eps = 0.0001;

            Console.WriteLine("Вычисление функции y = 2(cos^2 x - 1)");
            Console.WriteLine(" X        SN              SE              Y");

            for (int i = 0; i <= k; i++)
            {
                double x = a + i * step;
                double y = 2 * (Math.Cos(x) * Math.Cos(x) - 1);
                double sn = SumN(x, n);
                double se = SumEps(x, eps);
                Console.WriteLine("{0:F2}\t{1:F6}\t{2:F6}\t{3:F6}", x, sn, se, y);
            }
        }
    }
}