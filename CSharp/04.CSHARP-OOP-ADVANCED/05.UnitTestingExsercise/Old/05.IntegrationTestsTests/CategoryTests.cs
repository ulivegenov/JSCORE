using _05IntegrationTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _05IntegrationTestsTests
{
    [TestFixture]
    public class CategoryTests
    {
        private Category category;
        [SetUp]
        public void SetUp()
        {
            Category categoryOne = new Category("Incredible");

            this.category = categoryOne;
        }
        [Test]
        public void ConstructorSetsName()
        {
            Assert.That(this.category.Name, Is.EqualTo("Incredible"));
        }

        [Test]
        public void ConstructorCreateSetsOfUsers()
        {
            Type type = typeof(Category);
            PropertyInfo property = type.GetProperties()
                                            .FirstOrDefault(p => p.Name == "SetOfUsers");
            Assert.That(property, Is.Not.Null);
        }

        [Test]
        public void ConstructorCreateSetOfChildCategories()
        {
            Type type = typeof(Category);
            PropertyInfo property = type.GetProperties()
                                            .FirstOrDefault(p => p.Name == "SetOfChildCategories");
            Assert.That(property, Is.Not.Null);
        }

        [Test]
        public void CategoryAssaignChildCategory()
        {
            Category childCategory = new Category("Child");

            this.category.AssaignChildCategory(childCategory);

            Assert.That(this.category.SetOfChildCategories.Count > 0);
        }
    }
}
