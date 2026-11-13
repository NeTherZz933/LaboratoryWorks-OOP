using System;

namespace Lab9Variant7
{
    public class Time
    {
        private int _hours;
        private int _minutes;
        private static int _createdCount;

        public Time() : this(0, 0) { }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            _createdCount++;
        }

        public Time(Time other) : this(other.Hours, other.Minutes) { }

        public static int CreatedCount
        {
            get { return _createdCount; }
        }

        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Часы не могут быть отрицательными.");
                _hours = value;
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("Минуты должны быть в диапазоне 0..59.");
                _minutes = value;
            }
        }

        public int TotalMinutes
        {
            get { return _hours * 60 + _minutes; }
        }

        public void AddMinutes(int minutes)
        {
            int total = TotalMinutes + minutes;
            if (total < 0)
                throw new ArgumentException("Время не может быть отрицательным.");
            _hours = total / 60;
            _minutes = total % 60;
        }

        // Часть 1: метод класса
        public Time Subtract(Time other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            int total = TotalMinutes - other.TotalMinutes;
            if (total < 0)
                throw new ArgumentException("Результат не может быть отрицательным.");

            return FromTotalMinutes(total);
        }

        // Часть 1: статическая функция
        public static Time Subtract(Time t1, Time t2)
        {
            if (t1 == null)
                throw new ArgumentNullException("t1");
            return t1.Subtract(t2);
        }

        private static Time FromTotalMinutes(int total)
        {
            if (total < 0)
                throw new ArgumentException("Время не может быть отрицательным.");
            return new Time(total / 60, total % 60);
        }

        // Часть 2: унарные операции
        public static Time operator ++(Time t)
        {
            if (t == null)
                throw new ArgumentNullException("t");
            t.AddMinutes(1);
            return t;
        }

        public static Time operator --(Time t)
        {
            if (t == null)
                throw new ArgumentNullException("t");
            t.AddMinutes(-1);
            return t;
        }

        // Часть 2: операции приведения типа
        public static implicit operator int(Time t)
        {
            if (t == null)
                throw new ArgumentNullException("t");
            return t.TotalMinutes;
        }

        public static explicit operator bool(Time t)
        {
            if (t == null)
                throw new ArgumentNullException("t");
            return t.Hours != 0 || t.Minutes != 0;
        }

        // Часть 2: бинарные операции
        public static bool operator <(Time t1, Time t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException();
            return t1.TotalMinutes < t2.TotalMinutes;
        }

        public static bool operator >(Time t1, Time t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException();
            return t1.TotalMinutes > t2.TotalMinutes;
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}", Hours, Minutes);
        }
    }
}