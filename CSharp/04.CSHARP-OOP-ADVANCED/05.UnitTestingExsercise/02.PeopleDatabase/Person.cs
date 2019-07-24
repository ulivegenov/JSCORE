using System;
using System.Collections.Generic;
using System.Text;

namespace _02PeopleDatabase
{
    public class Person
    {
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username { get; private set; }

        public long Id { get; private set; }
    }
}
