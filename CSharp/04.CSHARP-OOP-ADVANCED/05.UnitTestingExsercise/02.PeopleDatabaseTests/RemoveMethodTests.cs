using _02PeopleDatabase;
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
        private Person pesho = new Person("Pesho", 928540956);
        private Person gosho = new Person("Gosho", 7065043560356);
        private Person dimitrichka = new Person("Dimitricka", 437503495);
        private Person palavataClasna = new Person("Palavata_Clasna", 493865);
        private Person chichoGosho = new Person("Chicho_Gosho", 37260);

        [Test]
        public void RemoveMethodRemoveLastElement()
        {
            Person[] input = { pesho, gosho, dimitrichka, palavataClasna, chichoGosho };

            Type type = typeof(Database<Person>);
            Database<Person> database = (Database<Person>)Activator.CreateInstance(type, new object[] { input });
            database.Remove();
            FieldInfo field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                   .FirstOrDefault(f => f.FieldType == typeof(Person[]));
            Person[] databseElements = (Person[])field.GetValue(database);

            Assert.That(databseElements[input.Length - 1] != input[input.Length - 1]);
        }

        [Test]
        public void RemoveTestThrowsExeptionIfDatabaseIsEmpty()
        {
            Person[] input = new Person[] { };
            Database<Person> database = new Database<Person>(input);

            Assert.That(() => database.Remove(), Throws.InvalidOperationException
                                                      .With
                                                      .Message
                                                      .EqualTo("Database is empty!"));
        }
    }
}
