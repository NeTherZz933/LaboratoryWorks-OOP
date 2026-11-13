using System;

namespace Lab9Variant7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Лабораторная работа 9. Вариант 7");

            Console.WriteLine();
            Console.WriteLine("Часть 1. Класс Time, вычитание времени");
            DemoPart1();

            Console.WriteLine();
            Console.WriteLine("Часть 2. Перегруженные операции");
            DemoPart2();

            Console.WriteLine();
            Console.WriteLine("Часть 3. Коллекция TimeArray, максимальное значение");
            DemoPart3();

            Console.WriteLine();
            Console.WriteLine("Всего создано объектов Time: " + Time.CreatedCount);
        }

        // ================== ЧАСТЬ 1: ИНТЕРАКТИВНОЕ ВЫЧИТАНИЕ ==================

        static void DemoPart1()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("--- Проверка вычитания времени ---");
                Console.WriteLine("1 - ввести два времени и вычесть");
                Console.WriteLine("2 - перейти к следующей части");

                int choice = ConsoleUI.ReadInt("Выбор: ");

                if (choice == 2)
                    break;

                if (choice != 1)
                {
                    Console.WriteLine("Неверный выбор.");
                    continue;
                }

                Time t1 = ReadTimeSafe("Введите уменьшаемое t1:");
                Time t2 = ReadTimeSafe("Введите вычитаемое t2:");

                Console.WriteLine("t1 = " + t1 + ", t2 = " + t2);

                try
                {
                    Time r1 = t1.Subtract(t2);
                    Console.WriteLine("Метод класса: t1.Subtract(t2) = " + r1);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Метод класса: ошибка — " + ex.Message);
                }

                try
                {
                    Time r2 = Time.Subtract(t1, t2);
                    Console.WriteLine("Статический метод: Time.Subtract(t1, t2) = " + r2);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Статический метод: ошибка — " + ex.Message);
                }
            }
        }

        static Time ReadTimeSafe(string title)
        {
            while (true)
            {
                Console.WriteLine(title);
                int h = ConsoleUI.ReadInt("Часы: ");
                int m = ConsoleUI.ReadInt("Минуты: ");

                try
                {
                    return new Time(h, m);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }

        // ================== ЧАСТЬ 2 ==================

        static void DemoPart2()
        {
            Time t = new Time(10, 59);
            Console.WriteLine("Исходное t = " + t);

            t++;
            Console.WriteLine("После t++: " + t);

            t--;
            Console.WriteLine("После t--: " + t);

            int mins = t;
            Console.WriteLine("Неявное int (минуты): " + mins);

            bool notZero = (bool)t;
            Console.WriteLine("Явное bool (не ноль): " + notZero);

            Time a = new Time(1, 20);
            Time b = new Time(2, 10);

            Console.WriteLine("a = " + a + ", b = " + b);
            Console.WriteLine("a < b: " + (a < b));
            Console.WriteLine("a > b: " + (a > b));
        }

        // ================== ЧАСТЬ 3 ==================

        static void DemoPart3()
        {
            Console.WriteLine("1 - случайное заполнение, 2 - ручное заполнение");
            int mode = ConsoleUI.ReadInt("Выбор: ");

            TimeArray arr;

            if (mode == 1)
                arr = ConsoleUI.CreateRandom();
            else
                arr = ConsoleUI.CreateManual();

            Console.WriteLine("Массив:");
            ConsoleUI.PrintArray(arr);

            try
            {
                Time max = FindMax(arr);
                Console.WriteLine("Максимальное значение: " + max);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            // ---- НОВОЕ: вывод элемента по индексу ----
            if (arr.Length > 0)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вывести элемент по индексу? 1 - да, 2 - нет");
                    int answer = ConsoleUI.ReadInt("Выбор: ");

                    if (answer == 2)
                        break;

                    if (answer != 1)
                    {
                        Console.WriteLine("Неверный выбор.");
                        continue;
                    }

                    int index = ConsoleUI.ReadInt("Введите индекс (0.." + (arr.Length - 1) + "): ");

                    try
                    {
                        Time item = arr[index];
                        Console.WriteLine("Элемент [" + index + "] = " + item);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        static Time FindMax(TimeArray arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Массив пуст.");

            Time max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }

            return max;
        }
    }
}