using System;

namespace Lab5Variant23
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Лабораторная работа 5. Вариант 23 ===");
                Console.WriteLine("1. Работа с двумерными массивами");
                Console.WriteLine("2. Работа с рваными массивами");
                Console.WriteLine("3. Демонстрация рекурсии и перегрузки");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите пункт: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Work2D(); break;
                    case "2": WorkJagged(); break;
                    case "3": DemoRecursion(); break;
                    case "4": return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Pause();
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("Нажмите Enter...");
            Console.ReadLine();
        }


        static void Work2D()
        {
            int[,] arr = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Двумерный массив ===");
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Напечатать массив");
                Console.WriteLine("3. Добавить K столбцов, начиная со столбца N");
                Console.WriteLine("4. Очистить массив (Array.Clear)");
                Console.WriteLine("5. Назад");
                Console.Write("Выберите пункт: ");
                string ch = Console.ReadLine();

                switch (ch)
                {
                    case "1":
                        arr = Create2D();
                        break;

                    case "2":
                        if (arr == null) { Console.WriteLine("Массив пуст."); Pause(); }
                        else { PrintArray(arr); Pause(); }
                        break;

                    case "3":
                        if (arr == null) { Console.WriteLine("Массив пуст."); Pause(); break; }
                        try
                        {
                            Console.Write("K = ");
                            int k = int.Parse(Console.ReadLine());
                            Console.Write("N = ");
                            int n = int.Parse(Console.ReadLine());
                            arr = AddCols(arr, k, n);
                            Console.WriteLine("Столбцы добавлены. Новый массив:");
                            PrintArray(arr);
                        }
                        catch (Exception ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                        Pause();
                        break;

                    case "4":
                        if (arr == null) { Console.WriteLine("Массив пуст."); }
                        else
                        {
                            Array.Clear(arr, 0, arr.Length);
                            Console.WriteLine("Массив очищен (Array.Clear).");
                        }
                        Pause();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        Pause();
                        break;
                }
            }
        }

        static int[,] Create2D(bool randomFill = true)
        {
            try
            {
                Console.Write("Строк: ");
                int r = int.Parse(Console.ReadLine());
                Console.Write("Столбцов: ");
                int c = int.Parse(Console.ReadLine());
                if (r <= 0 || c <= 0)
                    throw new ArgumentException("Размеры должны быть положительными.");

                Console.Write("Способ (1 - вручную, 2 - случайно): ");
                string mode = Console.ReadLine();
                bool manual = (mode == "1");

                int[,] a = new int[r, c];
                Random rnd = new Random();

                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        if (manual)
                        {
                            Console.Write("a[" + i + "," + j + "] = ");
                            a[i, j] = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            a[i, j] = rnd.Next(-10, 11);
                        }
                    }
                }

                Console.WriteLine("Создан массив:");
                PrintArray(a);
                return a;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                return null;
            }
        }

        static void PrintArray(int[,] a)
        {
            int r = a.GetLength(0);
            int c = a.GetLength(1);
            Console.WriteLine("Размер: " + r + "x" + c + ", элементов: " + a.Length);
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    Console.Write("{0,5}", a[i, j]);
                Console.WriteLine();
            }
        }

        static int[,] AddCols(int[,] a, int k, int n)
        {
            if (k <= 0)
                throw new ArgumentException("K должно быть больше нуля.");
            int r = a.GetLength(0);
            int c = a.GetLength(1);
            if (n < 0 || n > c)
                throw new ArgumentException("N вне диапазона 0.." + c + ".");

            int[,] res = new int[r, c + k];
            Random rnd = new Random();

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < n; j++)
                    res[i, j] = a[i, j];

                for (int j = n; j < n + k; j++)
                    res[i, j] = rnd.Next(-10, 11);

                for (int j = n; j < c; j++)
                    res[i, j + k] = a[i, j];
            }
            return res;
        }


        static void WorkJagged()
        {
            int[][] arr = null;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Рваный массив ===");
                Console.WriteLine("1. Создать массив");
                Console.WriteLine("2. Напечатать массив");
                Console.WriteLine("3. Добавить строку с заданным номером");
                Console.WriteLine("4. Очистить строку (Array.Clear)");
                Console.WriteLine("5. Назад");
                Console.Write("Выберите пункт: ");
                string ch = Console.ReadLine();

                switch (ch)
                {
                    case "1":
                        arr = CreateJagged();
                        break;

                    case "2":
                        if (arr == null) { Console.WriteLine("Массив пуст."); Pause(); }
                        else { PrintArray(arr); Pause(); }
                        break;

                    case "3":
                        if (arr == null) { Console.WriteLine("Массив пуст."); Pause(); break; }
                        try
                        {
                            Console.Write("Номер строки (0.." + arr.Length + "): ");
                            int idx = int.Parse(Console.ReadLine());
                            Console.Write("Длина новой строки: ");
                            int len = int.Parse(Console.ReadLine());
                            arr = AddRow(arr, idx, len);
                            Console.WriteLine("Строка добавлена. Новый массив:");
                            PrintArray(arr);
                        }
                        catch (Exception ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                        Pause();
                        break;

                    case "4":
                        if (arr == null) { Console.WriteLine("Массив пуст."); }
                        else
                        {
                            try
                            {
                                Console.Write("Номер строки для очистки (0.." + (arr.Length - 1) + "): ");
                                int idx = int.Parse(Console.ReadLine());
                                if (idx < 0 || idx >= arr.Length)
                                    throw new ArgumentException("Индекс вне диапазона.");
                                Array.Clear(arr[idx], 0, arr[idx].Length);
                                Console.WriteLine("Строка " + idx + " очищена (Array.Clear).");
                            }
                            catch (Exception ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                        }
                        Pause();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        Pause();
                        break;
                }
            }
        }

        static int[][] CreateJagged()
        {
            try
            {
                Console.Write("Строк: ");
                int r = int.Parse(Console.ReadLine());
                if (r <= 0)
                    throw new ArgumentException("Число строк должно быть > 0.");

                Console.Write("Способ (1 - вручную, 2 - случайно): ");
                string mode = Console.ReadLine();
                bool manual = (mode == "1");

                int[][] a = new int[r][];
                Random rnd = new Random();

                for (int i = 0; i < r; i++)
                {
                    Console.Write("Длина строки " + i + ": ");
                    int len = int.Parse(Console.ReadLine());
                    if (len < 0)
                        throw new ArgumentException("Длина не может быть отрицательной.");
                    a[i] = new int[len];

                    for (int j = 0; j < len; j++)
                    {
                        if (manual)
                        {
                            Console.Write("a[" + i + "][" + j + "] = ");
                            a[i][j] = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            a[i][j] = rnd.Next(-10, 11);
                        }
                    }
                }

                Console.WriteLine("Создан массив:");
                PrintArray(a);
                return a;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                return null;
            }
        }

        static void PrintArray(int[][] a)
        {
            Console.WriteLine("Строк: " + a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Строка " + i + " (длина " + a[i].Length + "): ");
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write("{0,5}", a[i][j]);
                Console.WriteLine();
            }
        }

        static int[][] AddRow(int[][] a, int index, int len)
        {
            if (index < 0 || index > a.Length)
                throw new ArgumentException("Индекс вне диапазона 0.." + a.Length + ".");
            if (len < 0)
                throw new ArgumentException("Длина не может быть отрицательной.");

            int[][] res = new int[a.Length + 1][];

            for (int i = 0; i < index; i++)
                res[i] = a[i];

            Random rnd = new Random();
            res[index] = new int[len];
            for (int j = 0; j < len; j++)
                res[index][j] = rnd.Next(-10, 11);

            for (int i = index; i < a.Length; i++)
            {
                res[i + 1] = new int[a[i].Length];
                Array.Copy(a[i], res[i + 1], a[i].Length);
            }
            return res;
        }


        static void DemoRecursion()
        {
            Console.Clear();
            Console.WriteLine("=== Демонстрация рекурсии и перегрузки ===");
            Console.WriteLine("Факториал 5 = " + Factorial(5));
            Print("перегрузка Print(string)");
            Print(42);
            Pause();
        }

        static long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        static void Print(string s) { Console.WriteLine("Строка: " + s); }
        static void Print(int x) { Console.WriteLine("Число: " + x); }
    }
}