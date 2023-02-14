using System;

namespace Database
{
    public class Database
    {
        private int[] _data;

        private int _count;

        public Database(params int[] data)
        {
            _data = new int[16];

            for (int i = 0; i < data.Length; i++)
            {
                Add(data[i]);
            }

            _count = data.Length;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Add(int element)
        {
            if (_count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            _data[_count] = element;
            _count++;
        }

        public void Remove()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            _count--;
            _data[_count] = 0;
        }

        public int[] Fetch()
        {
            int[] coppyArray = new int[_count];

            for (int i = 0; i < _count; i++)
            {
                coppyArray[i] = _data[i];
            }

            return coppyArray;
        }
    }
}
