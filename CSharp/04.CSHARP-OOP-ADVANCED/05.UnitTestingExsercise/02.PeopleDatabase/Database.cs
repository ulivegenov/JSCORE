using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02PeopleDatabase
{
    public class Database<T>:IEnumerable<T> 
                  where T:Person
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
            if (input.Length > databaseMaxSize)
            {
                throw new InvalidOperationException($"Database Capacity Max Size is {databaseMaxSize}!");
            }

            bool validInput = ValidateInput(input);
            if (!validInput)
            {
                throw new InvalidOperationException("Invalid Input. All Usernames and Id's must be unique!");
            }

            this.data = new T[databaseMaxSize];
            inerCounter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                this.data[i] = input[i];
                this.inerCounter++;
            }
            return this.data;
        }

        public void Add(T elementToAdd)
        {
            if (this.inerCounter < this.Capacity)
            {
                T[] temp = new T[inerCounter];
                Array.Copy(this.data, temp, inerCounter);
                foreach (var person in temp)
                {
                    if (person.Username.CompareTo(elementToAdd.Username) == 0)
                    {
                        throw new InvalidOperationException("This Id or Username allreadyExist!");
                    }
                    if (person.Id == elementToAdd.Id)
                    {
                        throw new InvalidOperationException("This Id or Username allreadyExist!");
                    }
                }

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

        public T FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive number!");
            }

            T[] temp = new T[inerCounter];
            Array.Copy(this.data, temp, inerCounter);
            if (temp.Any(p=>p.Id == id))
            {
                return temp.First(p => p.Id == id);
            }
           
            throw new InvalidOperationException("This Id doesn't exist!");
        }

        public T FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("You must enter a Username!");
            }

            T[] temp = new T[inerCounter];
            Array.Copy(this.data, temp, inerCounter);

            if (temp.Any(p => p.Username == username))
            {
                return temp.First(p => p.Username == username);
            }

            throw new InvalidOperationException("This Username doesn't exist!");
        }

        private bool ValidateInput(T[] inputData)
        {
            for (int i = 0; i < inputData.Length - 1; i++)
            {
                for (int j = i+1; j < inputData.Length; j++)
                {
                    if ((inputData[i].Username.CompareTo(inputData[j].Username)) == 0)
                    {
                        return false;
                    }

                    if (inputData[i].Id == inputData[j].Id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
