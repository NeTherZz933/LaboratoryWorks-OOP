using System;

namespace Lab9Variant7
{
    public static class ConsoleUI
    {
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                int value;

                if (int.TryParse(s, out value))
                    return value;

                Console.WriteLine("Ошибка: введите целое число.");
            }
        }

        public static Time ReadTime(string title)
        {
            while (true)
            {
                Console.WriteLine(title);
                int h = ReadInt("Часы: ");
                int m = ReadInt("Минуты: ");

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

        public static TimeArray CreateRandom()
        {
            int n = ReadInt("Количество элементов: ");
            return new TimeArray(n);
        }

        public static TimeArray CreateManual()
        {
            int n = ReadInt("Количество элементов: ");
            return new TimeArray(n, () => ReadTime("Ввод элемента"));
        }

        public static void PrintArray(TimeArray arr)
        {
            arr.Print();
        }
    }
}