using System;
using System.Collections.Generic;
using System.Text;

namespace _05IntegrationTests.Contracts
{
    public interface IUser
    {
        string Name { get; }

        IList<ICategory> SetOfCategories { get; }
    }
}
