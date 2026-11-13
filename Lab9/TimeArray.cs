using System;

namespace Lab9Variant7
{
    public class TimeArray
    {
        private Time[] _arr;

        public TimeArray()
        {
            _arr = new Time[0];
        }

        public TimeArray(int size)
        {
            if (size < 0)
                throw new ArgumentException("Размер не может быть отрицательным.");

            _arr = new Time[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                _arr[i] = new Time(rnd.Next(0, 24), rnd.Next(0, 60));
            }
        }

        public TimeArray(int size, Func<Time> reader)
        {
            if (size < 0)
                throw new ArgumentException("Размер не может быть отрицательным.");
            if (reader == null)
                throw new ArgumentNullException("reader");

            _arr = new Time[size];

            for (int i = 0; i < size; i++)
            {
                _arr[i] = reader();
            }
        }

        public TimeArray(Time[] items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            _arr = new Time[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                _arr[i] = items[i] == null ? new Time() : new Time(items[i]);
            }
        }

        public int Length
        {
            get { return _arr.Length; }
        }

        public Time this[int index]
        {
            get
            {
                if (index < 0 || index >= _arr.Length)
                    throw new ArgumentException("Индекс вне диапазона массива.");
                return _arr[index];
            }
            set
            {
                if (index < 0 || index >= _arr.Length)
                    throw new ArgumentException("Индекс вне диапазона массива.");
                if (value == null)
                    throw new ArgumentNullException("value");
                _arr[index] = value;
            }
        }

        public void Print()
        {
            if (_arr.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }

            for (int i = 0; i < _arr.Length; i++)
            {
                Console.WriteLine("[{0}] {1}", i, _arr[i]);
            }
        }
    }
}