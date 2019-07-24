using System;
using System.Collections.Generic;
using System.Text;

namespace _05IntegrationTests.Contracts
{
    public interface ICategory
    {
        string Name { get; }

        IList<IUser> SetOfUsers { get; }

        IList<ICategory> SetOfChildCategories { get; }
    }
}
