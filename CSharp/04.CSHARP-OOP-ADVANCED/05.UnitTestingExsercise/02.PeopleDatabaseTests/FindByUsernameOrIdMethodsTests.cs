using _02PeopleDatabase;
using NUnit.Framework;
using System;

namespace PeopleDatabaseTests
{
    [TestFixture]
    public class FindByUsernameOrIdMethodsTests
    {
        private Person pesho = new Person("Pesho", 928540956);
        private Person gosho = new Person("Gosho", 7065043560356);
        private Person dimitrichka = new Person("Dimitricka", 437503495);
        private Person palavataClasna = new Person("Palavata_Clasna", 493865);
        private Person chichoGosho = new Person("Chicho_Gosho", 37260);

        private Database<Person> database;
        [SetUp]
        public void SetUp()
        {
            Person[] input = { pesho, gosho, dimitrichka, palavataClasna, chichoGosho };
            database = new Database<Person>(input);
        }

        [Test]
        public void FindByIdReturnsThePersonWithSearchedId()
        {
            long searchedId = pesho.Id;
            Person searchedPerson = this.database.FindById(searchedId);

            Assert.That(searchedPerson, Is.EqualTo(pesho));
        }

        [Test]
        public void FindByIdThrowsExeptionWhenSearchedIdIsNegativeNumber()
        {
            long searchedId = -98723487560;

            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(searchedId), 
                                                        "Id must be a positive number!");                                                          
        }

        [Test]
        public void FindByIdThrowsExeptionIfThereNoSuchId()
        {
            long searchedId = 344444333333;

            Assert.That(() => this.database.FindById(searchedId), Throws
                                                                  .InvalidOperationException
                                                                  .With
                                                                  .Message
                                                                  .EqualTo("This Id doesn't exist!"));
        }

        [Test]
        public void FindByUsernameReturnsThePersonWithSearchedUsername()
        {
            string searchedUsername = pesho.Username;
            Person searchedPerson = this.database.FindByUsername(searchedUsername);

            Assert.That(searchedPerson, Is.EqualTo(pesho));
        }

        [Test]
        public void FindByUsernameThrowsExeptionIfSearchedUsernameIsNull()
        {
            string searchedUsername = null;

            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(searchedUsername),
                                                        ("You must enter a Username!"));
        }

        [Test]
        public void FindByUsernameThrowsExeptionIfThereNoSuchUsername()
        {
            string searchedName = "Mitko";

            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(searchedName),
                                                            ("This Username doesn't exist!"));
        }
    }
}
