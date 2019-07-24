using _05IntegrationTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _05IntegrationTestsTests
{
   
    [TestFixture]
    public class UserTests
    {
        private User user;

        [SetUp]
        public void SetUp()
        {
            User userOne = new User("Petsata");

            this.user = userOne;
        }

        [Test]
        public void ConstructorSetsName()
        {
            Assert.That(this.user.Name, Is.EqualTo("Petsata"));
        }

        [Test]
        public void ConstructorCreateSetOfCategories()
        {
            PropertyInfo property = typeof(User).GetProperties()
                                                .FirstOrDefault(p => p.Name == "SetOfCategories");

            Assert.That(property, Is.Not.Null);
        }
    }
}
