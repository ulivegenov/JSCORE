using _05IntegrationTests.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05IntegrationTests.Models
{
    public class User : IUser
    {
        public User(string name)
        {
            this.Name = name;
            this.SetOfCategories = new List<ICategory>();
        }

        public string Name { get; private set; }

        public IList<ICategory> SetOfCategories { get; private set; }
    }
}
