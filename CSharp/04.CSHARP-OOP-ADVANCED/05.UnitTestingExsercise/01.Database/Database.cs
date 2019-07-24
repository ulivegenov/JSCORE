using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01Database
{
    public class Database<T>:IEnumerable<T>
    {
        private const int databaseMaxSize = 16;
        private T[] data;
        private int inerCounter;

        public Database(params T[] data)
        {
            this.data = Create(data);
            this.Capacity = databaseMaxSize;
        }

        public int Capacity { get; private set; }

        private T[] Create(params T[] input)
        {
            T[] temp = new T[databaseMaxSize];
            inerCounter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i >= databaseMaxSize)
                {
                    throw new InvalidOperationException($"Database Capacity Max Size is {databaseMaxSize}!");
                }
                temp[i] = input[i];
                this.inerCounter++;
            }
            return temp;
        }

        public void Add(T elementToAdd)
        {
            if (inerCounter < this.Capacity)
            {
                this.data[this.inerCounter] = elementToAdd;
                this.inerCounter++;
            }
            else
            {
                throw new InvalidOperationException("Database is full!");
            }
        }

        public void Remove()
        {
            if (this.inerCounter == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }
            this.data[this.inerCounter - 1] = default(T);
            inerCounter--;
        }

        public T[] Fetch()
        {
            T[] temp = new T[this.inerCounter];
            Array.Copy(this.data, temp, this.inerCounter);

            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                yield return this.data[i];
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
