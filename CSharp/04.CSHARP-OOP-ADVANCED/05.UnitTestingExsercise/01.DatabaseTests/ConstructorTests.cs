
using _01Database;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DatabaseTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void ConstructorCreatesArrayWithValidSize()
        {
            int[] input = { 1, 2, 3, 4, 5, 6 };

            Database<int> database = new Database<int>(input);

            Assert.That(database.Capacity == 16);
        }

        [Test]
        public void ConstructorWorksWithValidInputLenght()
        {
            int[] input = { 1, 2, 3, 4, 5, 6 };

            Type type = typeof(Database<int>);
            Database<int> database = (Database<int>)Activator.CreateInstance(type, new object[] { input });
            FieldInfo fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                    .FirstOrDefault(f => f.FieldType == typeof(int[]));
            int[] databaseElements = (int[])fields.GetValue(database);

            Assert.That(input.Sum(), Is.EqualTo(databaseElements.Sum()));
        }

        [Test]
        public void ConstructorThrowsExepstionWhitInvalidInputLenght()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.That(() => new Database<int>(input), Throws
                                                        .InvalidOperationException
                                                        .With
                                                        .Message
                                                        .EqualTo("Database Capacity Max Size is 16!"));
        }
    }
}
