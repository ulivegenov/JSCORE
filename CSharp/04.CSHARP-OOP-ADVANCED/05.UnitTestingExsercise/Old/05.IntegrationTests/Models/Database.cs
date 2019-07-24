using _05IntegrationTests.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _05IntegrationTests.Models
{
    public class Database<T> : IEnumerable<T> where T : Category
    {
        private List<T> categories;
        private int inerCounter;

        public Database()
        {
            this.categories = new List<T>();
            this.inerCounter = 0;
            this.Capacity = this.categories.Count;
        }

        public int Capacity { get; private set; }


        public void AddCategories(params T[] categoriesToAdd)
        {
            for (int i = 0; i < categoriesToAdd.Length; i++)
            {
                this.categories.Add(categoriesToAdd[i]);
                this.inerCounter++;
            }    
        }

        public void RemoveCategories(params T[] categories)
        {
            if (this.inerCounter == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            foreach (var category in categories)
            {
                if ((category.SetOfUsers.Count > 0) &&(category.SetOfChildCategories.Count > 0))
                {
                    foreach (var user in category.SetOfUsers)
                    {
                        this.UnsubscribeUserFromCategory(user, category);
                        this.AssaignUserToCategory(user, category.SetOfChildCategories.First());
                    }

                    T[] temp = new T[category.SetOfChildCategories.Count];
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = (T)category.SetOfChildCategories[i];
                    }
                    this.AddCategories(temp);
                }

                this.categories.Remove(category);
                inerCounter--;
            }
        }

        public void AssaignChildCategory(ICategory parentCategory, ICategory childCategory)
        {
            parentCategory.SetOfChildCategories.Add(childCategory);
        }

        public void MoveChildCategory(ICategory childCategoryToMove, ICategory parentCategory, ICategory newParentCategory)
        {
            ICategory newChildCategory = new Category(childCategoryToMove.Name);
            PropertyInfo property = typeof(ICategory).GetProperties()
                                                      .FirstOrDefault(p => p.Name == "SetOfUsers");
            List<IUser> newPropertyValues = (List<IUser>)property.GetValue(childCategoryToMove);
            foreach (var item in newPropertyValues)
            {
                newChildCategory.SetOfUsers.Add(item);
            }
            PropertyInfo propertyTwo = typeof(ICategory).GetProperties()
                                                      .FirstOrDefault(p => p.Name == "SetOfChildCategories");
            List<ICategory> newPropertyTwoValues = (List<ICategory>)propertyTwo.GetValue(childCategoryToMove);
            foreach (var item in newPropertyTwoValues)
            {
                newChildCategory.SetOfChildCategories.Add(item);
            }

            parentCategory.SetOfChildCategories.Remove(childCategoryToMove);
            newParentCategory.SetOfChildCategories.Add(newChildCategory);
        }

        public void AssaignUserToCategory(IUser user, ICategory category)
        {
            user.SetOfCategories.Add(category);
            category.SetOfUsers.Add(user);
        }

        public void UnsubscribeUserFromCategory(IUser user,ICategory category)
        {
            category.SetOfUsers.Remove(user);
            user.SetOfCategories.Remove(category);
        }

        public List<T> Fetch()
        {
            List<T> temp = new List<T>();
            foreach (var item in this.categories)
            {
                temp.Add(item);
            }

            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.categories.Count; i++)
            {
                yield return this.categories[i];
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
