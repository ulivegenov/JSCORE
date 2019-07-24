using _01Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DatabaseTests
{
    [TestFixture]
    public class AddMethodTests
    {
        [Test]
        public void AddMethodAddElementAtNextFreeCell()
        {
            int[] input = { 1, 2 };
            int elementToAdd = 2134;

            Type type = typeof(Database<int>);
            Database<int> database = (Database<int>)Activator.CreateInstance(type, new object[] { input });
            database.Add(elementToAdd);
            FieldInfo field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .FirstOrDefault(f => f.FieldType == typeof(int[]));
            int[] databaseElements = (int[])field.GetValue(database);                        

            Assert.That(databaseElements[2], Is.EqualTo(elementToAdd));
        }

        [Test]
        public void AddMethodThrowsExeptionIfThereIsNoFreeCell()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database<int> database = new Database<int>(input);
            int elementToAdd = 17;

            Assert.That(() => database.Add(elementToAdd), Throws.InvalidOperationException
                                                                .With
                                                                .Message
                                                                .EqualTo("Database is full!"));
        }
    }
}
