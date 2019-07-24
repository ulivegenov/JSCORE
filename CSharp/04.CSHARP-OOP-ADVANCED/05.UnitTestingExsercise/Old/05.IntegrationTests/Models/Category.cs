using _05IntegrationTests.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05IntegrationTests.Models
{
    public class Category : ICategory
    {
        public Category(string name)
        {
            this.Name = name;
            this.SetOfUsers = new List<IUser>();
            this.SetOfChildCategories = new List<ICategory>();
        }

        public string Name { get; private set; }

        public IList<IUser> SetOfUsers { get; private set; }

        public IList<ICategory> SetOfChildCategories { get; private set; }

        public void AssaignChildCategory(ICategory childCategory)
        {
            this.SetOfChildCategories.Add(childCategory);
        }
    }
}
