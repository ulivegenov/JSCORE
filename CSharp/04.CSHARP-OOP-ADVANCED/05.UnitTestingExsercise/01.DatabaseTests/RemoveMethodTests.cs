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
    public class RemoveMethodTests
    {
        [Test]
        public void RemoveMethodRemoveLastElement()
        {
            int[] input = { 1, 2, 3, 4, 5 };

            Type type = typeof(Database<int>);
            Database<int> database = (Database<int>)Activator.CreateInstance(type, new object[] { input });
            database.Remove();
            FieldInfo field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                   .FirstOrDefault(f => f.FieldType == typeof(int[]));
            int[] databseElements = (int[])field.GetValue(database);
            int lastElementsDiff = input[input.Length - 1] - databseElements[input.Length - 1];

            Assert.That(lastElementsDiff, Is.EqualTo(input[input.Length - 1]));
        }

        [Test]
        public void RemoveTestThrowsExeptionIfDatabaseIsEmpty()
        {
            int[] input = new int[] { };
            Database<int> database = new Database<int>(input);

            Assert.That(() => database.Remove(), Throws.InvalidOperationException
                                                      .With
                                                      .Message
                                                      .EqualTo("Database is empty!"));
        }
    }
}
