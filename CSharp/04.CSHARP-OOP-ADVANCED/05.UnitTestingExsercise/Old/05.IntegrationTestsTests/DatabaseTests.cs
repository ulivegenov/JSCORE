using _05IntegrationTests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05IntegrationTestsTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Category categoryOne = new Category("Pro");
        private Category categoryTwo = new Category("SuperPro");
        private Category categoryThree = new Category("SemiPro");
        private Category categoryFour = new Category("Amateur");

        private Category childOne = new Category("ChildOne");
        private Category childTwo = new Category("ChildTwo");

        private User userOne = new User("Stamat");
        private User userTwo = new User("Petsata");
        private User userThree = new User("Micheto");
        private User userFour = new User("Siyka");

        private Database<Category> categories;

        [SetUp]
        public void SetUp()
        {
            Category[] input = { this.categoryOne, this.categoryTwo,
                                this.categoryThree, this.categoryFour };

            this.categories = new Database<Category>();
            this.categories.AddCategories(input);
        }

        [Test]
        public void AssaignUserToCategoryTest()
        {
            this.categories.AssaignUserToCategory(this.userOne, this.categoryOne);

            Assert.That(this.categoryOne.SetOfUsers.Contains(this.userOne));
        }

        [Test]
        public void UnsubscribeUserFromCategoryTest()
        {
            this.categories.AssaignUserToCategory(this.userOne, this.categoryFour);
            this.categories.AssaignUserToCategory(this.userThree, this.categoryFour);
            this.categories.UnsubscribeUserFromCategory(this.userThree, this.categoryFour);

            Assert.That(this.categoryFour.SetOfUsers.Contains(this.userThree), Is.False);
        }

        [Test]
        public void AssaignChildCategoryTest()
        {
            this.categories.AddCategories(childOne);
            this.categories.AssaignChildCategory(this.categoryOne, this.childOne);
            bool isChildAdd = false;

            foreach (var childCategory in this.categoryOne.SetOfChildCategories)
            {
                if (childCategory.Name == this.childOne.Name)
                {
                    isChildAdd = true;
                }
            }

            Assert.That(isChildAdd, Is.True);

        }

        [Test]
        public void MoveChildCategoryMovesToNewParent()
        {
            this.categories.AssaignChildCategory(this.categoryOne, this.childOne);
            this.categories.AssaignChildCategory(this.categoryTwo, this.childTwo);
            this.categories.AssaignUserToCategory(this.userFour, this.childOne);
            this.categories.AssaignUserToCategory(this.userThree, this.childOne);

            this.categories.MoveChildCategory(this.childOne, this.categoryOne, this.categoryTwo);

            bool isChildOneMovedToCategoryTwo = false;

            foreach (var childCategory in this.categoryTwo.SetOfChildCategories)
            {
                if (childCategory.Name == this.childOne.Name)
                {
                    isChildOneMovedToCategoryTwo = true;
                }
            }

            Assert.That(isChildOneMovedToCategoryTwo, Is.True);
        }

        [Test]
        public void MoveChildCategoryMovesToParentWithValues()
        {
            this.categories.AssaignUserToCategory(this.userFour, this.childOne);
            this.categories.AssaignUserToCategory(this.userTwo, this.childOne);
            this.categories.AssaignChildCategory(this.categoryOne, this.childOne);
            this.categories.AssaignChildCategory(this.categoryTwo, this.childTwo);
            this.categories.AssaignUserToCategory(this.userFour, this.childOne);
            this.categories.AssaignUserToCategory(this.userThree, this.childOne);

            this.categories.MoveChildCategory(this.childOne, this.categoryOne, this.categoryTwo);

            bool isUsersMoved = false;

            foreach (var child in this.categoryTwo.SetOfChildCategories
                                                  .Where(c=>c.Name == this.childOne.Name))
            {
                if (child.SetOfUsers.Contains(this.userFour) && 
                    child.SetOfUsers.Contains(this.userTwo))
                {
                    isUsersMoved = true;
                }
            }

            Assert.That(isUsersMoved, Is.True);
        }

        [Test]
        public void MoveChildCategoryRemovesConectionWithOldParent()
        {
            this.categories.AssaignChildCategory(this.categoryOne, this.childOne);
            this.categories.AssaignChildCategory(this.categoryTwo, this.childTwo);
            this.categories.AssaignUserToCategory(this.userFour, this.childOne);
            this.categories.AssaignUserToCategory(this.userThree, this.childOne);

            this.categories.MoveChildCategory(this.childOne, this.categoryOne, this.categoryTwo);

            bool isConectionRemoved = false;

            if (this.categoryOne.SetOfChildCategories.Count == 0)
            {
                isConectionRemoved = true;
            }

            Assert.That(isConectionRemoved, Is.True);
        }
    }
}
